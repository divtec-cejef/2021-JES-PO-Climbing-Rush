using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class P2_MovePlayer : MonoBehaviour
{
    private const int MAX_PRESS_BUTTON_BEFORE_FALL = 2;
    
    // Variable pour les boutons pressoirs
    private PlayerControls controls;


    //public MoveIndicator moveIndicator;
    //public FlashIndicator flashIndicator;
    public P2_ScoreScript scoreScript;
    public P2_IkControl ikControl;
    public P2_EffectBeamIndicator effectBeamIndicator;
    public P2_ProgressiveCircular progressiveCircular;
    public DisplayPopUpText displayPopUpText;
    public StartCountDownTimer startCountDownTimer;
    public P2_GainPoint gainPoint;
        
    
    private bool dropPlayer = false;
    private bool waitWhileCoroutine = false;
    private int wrongButtonPressTwice = 0;

    private Coroutine stopPlayerClimb;

    private bool isFirstHold = true;

    private bool gameIsFinishAndStuckPlayer = false;


    void Awake()
    {
        
        controls = new PlayerControls();
        
        // Les cinq boutons à contrôler
        controls.Gameplay.P2_RedButton.performed += ctx => correctCircle(Color.red);
        controls.Gameplay.P2_BlueButton.performed += ctx => correctCircle(Color.blue);
        controls.Gameplay.P2_GreenButton.performed += ctx => correctCircle(Color.green);
        controls.Gameplay.P2_YellowButton.performed += ctx => correctCircle(Color.yellow);
        controls.Gameplay.P2_PurpleButton.performed += ctx => correctCircle(Color.magenta);
        
    }

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }


    /// <summary>
    /// Vérifie si le bouton appuyé correspondant avec la couleur du cercle courrant
    /// </summary>
    /// <param name="colorButton"> La couleur du bouton qui est appuyé </param>
    private void correctCircle(Color colorButton)
    {

        
        
        if (startCountDownTimer.getcountDownTimerIsFinished() && !gameIsFinishAndStuckPlayer)
        {
            gainPoint.stopCoroutineGainPointTimed();
           
            print("BENKS P2 couleurBouton : " + colorButton);
            print("BENKS P2 couleur de l'indicateur : " + progressiveCircular.getCurrentColorIndicator());
            
            if (colorButton.Equals(progressiveCircular.getCurrentColorIndicator()))
            {
                print("BENKS P2 passer le truc des couleurs");
                
                scoreScript.setButtonPressedTooFast(true);
                scoreScript.setIsGoodButton(true);


                // Le joueur n'a pas appuyé deux fois sur le mauvais bouton
                wrongButtonPressTwice = 0;


                // On dit que le joueur n'est pas tombé ou qu'il remonte
                ikControl.setDoFallPlayer(false);
                ikControl.setNotYetFallen(true);
                ikControl.setForGetCurrentNumberHold(true);
                ikControl.setFallPlayerInARow(false);

                // Le joueur ne doit pas être bloqué
                dropPlayer = false;

                // Le joueur n'est pas tombé
                progressiveCircular.setFellPlayer(false);

                

                print("avant de monter !");



                // Vérifie si le joueur est redescendu jusqu'à la première
                if (progressiveCircular.getCurrentNumberOfHoldOnIndicator() == 1)
                {
                    isFirstHold = true;
                    ikControl.setIsFirstHold(true);
                }

                // Vérifie que le joueur puisse monter et qu'il ne doit pas être bloqué (appuyé sur le mauvais bouton)
                // ikControl.getCanClimb() && <- je l'ai enlevé, il ne sert plus à rien (je crois)
                //if (!waitWhileCoroutine)
                //{

                    print("monte !");


                    // Vérifie si le joueur est tombé alors on fait pour que la prochaine prise soit prise avec la bonne main
                    //&& ikControl.getNumberOfHoldCurrent() != 1
                    if (ikControl.getFellPlayer())
                    {
                        if (ikControl.getIsHoldRight() && progressiveCircular.getCurrentNumberOfHoldOnIndicator() != 1)
                        {
                            ikControl.setGoodHandForClimb(true, false);
                        }
                        else
                        {
                            ikControl.setGoodHandForClimb(false, true);
                        }
                    }




                    // Joue un effet autour de l'indicateur quand on attrape la prise
                    effectBeamIndicator.playEffectBeam(progressiveCircular.getCurrentColorIndicator());


                    // Ajout de points pour le score du joueur
                    scoreScript.setButtonPressedTooFast(false);

                    // Déplace l'indicateur à la prochaine prise
                    progressiveCircular.setButtonPressed(true);
                    progressiveCircular.stopProgressCircularBarCoroutine();
                    progressiveCircular.setDefaultProgressCircularBarUI();
                    progressiveCircular.moveNextIndicator();

                    // L'indicateur n'est plus le même, donc faux
                    scoreScript.setIsTheSameCircle(false);

                    // Il a monté au moins une prise donc ce n'est plus la première
                    isFirstHold = false;


                    // Fais bouger le joueur à la prochaine prise
                    ikControl.animationClimbingPlayer();
                //}
            }
            else
            {
                // Le bouton pressé est faux et on imagine qu'il a été pressé trop rapidement, si ce n'est pas le cas
                // alors on annule ce dernier.
                scoreScript.setIsGoodButton(false);
                //scoreScript.setButtonPressedTooFast(true);
                scoreScript.setButtonPressedTooFast(false);

                /*
                if (ikControl.getCanClimb())
                {
                    scoreScript.setButtonPressedTooFast(false);
                }
                */

                // Le joueur doit être bloqué
                dropPlayer = true;

                // Le joueur doit descendre d'une prise si wrongButtonPressTwice = 2
                //wrongButtonPressTwice++;
            }


            // Calcule les points
            /*
            if (!waitWhileCoroutine)
            {
                scoreScript.calculatePoints();
            }
            */

            // Vérifie si le joueur est redescendu jusqu'à la première
            if (progressiveCircular.getCurrentNumberOfHoldOnIndicator() == 1)
            {
                isFirstHold = true;
            }
            
            scoreScript.calculatePoints();

            // Descends le joueur d'une prise
            if (dropPlayer && !isFirstHold)
            {
                print("le joueur doit tomber");
                wrongButtonPressTwice = 0;

                ikControl.setDoFallPlayer(true);
                progressiveCircular.setFellPlayer(true);
                effectBeamIndicator.substractOneTarget();

                if (ikControl.getFallPlayerOne())
                {
                    ikControl.setFallPlayerInARow(true);
                }


                if (ikControl.getIsHoldRight())
                {
                    print("ouais 1");
                    ikControl.setGoodHandForClimb(false, true);
                }
                else
                {
                    print("ouais 2");
                    ikControl.setGoodHandForClimb(true, false);
                }




                // Déplace l'indicateur
                progressiveCircular.setButtonPressed(true);
                progressiveCircular.stopProgressCircularBarCoroutine();
                progressiveCircular.setDefaultProgressCircularBarUI();
                progressiveCircular.moveNextIndicator();
            }
            /*
            // Bloque le joueur pendant 2 secondes
            else if (dropPlayer)
            {
                stopPlayerClimb = StartCoroutine(StopPlayerClimbFor2Seconds());
            }
            */
        }

    }

    
    IEnumerator StopPlayerClimbFor2Seconds()
    {
        // Le joueur est bloqué pendant 2 secondes
        displayPopUpText.setBlocked(true);
        print("BLOQUÉ");
        waitWhileCoroutine = true;
        yield return new WaitForSeconds(2f);
        
        waitWhileCoroutine = false;

        StopCoroutine(stopPlayerClimb);
        displayPopUpText.setBlocked(false);
        print("la coroutine est stope !");
    }

    /// <summary>
    /// Change la valeur à vrai si le jeu est fini et doit bloquer le joueur sinon faux
    /// </summary>
    /// <param name="isFinish">Booléen à vrai si le jeu est fini sinon faux</param>
    public void isGameIsFinishAndStuckPlayer(bool isFinish)
    {
        gameIsFinishAndStuckPlayer = isFinish;
    }


    // Fonctions qui permettent aux boutons de s'activer
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }  

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}