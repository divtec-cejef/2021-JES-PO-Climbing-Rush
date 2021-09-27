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


    public P2_ScoreScript scoreScript;
    public P2_IkControl ikControl;
    public P2_EffectBeamIndicator effectBeamIndicator;
    public P2_ProgressiveCircular progressiveCircular;
    public DisplayPopUpText displayPopUpText;
    public StartCountDownTimer startCountDownTimer;
    public P2_GainPoint gainPoint;
    public P2_LightUpLeds lightUpLeds;

    
    private bool dropPlayer = false;
    private bool waitWhileCoroutine = false;
    private int wrongButtonPressTwice = 0;

    private Coroutine stopPlayerClimb;

    private bool isFirstHold = true;
    private bool gameIsFinishAndStuckPlayer = false;
    
    private Color colorButton5 = Color.white;
    private Color colorButton6 = Color.white;
    private Color colorButton7 = Color.white;
    private Color colorButton8 = Color.white;
    private Color previousColorIndicator = Color.white;
    
    private bool isSameColorIndicator = false;
    

    void Awake()
    {
        
        controls = new PlayerControls();
        
        // Les cinq boutons à contrôler
        /*
        controls.Gameplay.P2_RedButton.performed += ctx => correctCircle(Color.red);
        controls.Gameplay.P2_BlueButton.performed += ctx => correctCircle(Color.blue);
        controls.Gameplay.P2_GreenButton.performed += ctx => correctCircle(Color.green);
        controls.Gameplay.P2_YellowButton.performed += ctx => correctCircle(Color.yellow);
        //controls.Gameplay.P2_PurpleButton.performed += ctx => correctCircle(Color.magenta);
        */
        
        
        /*-------------------------------------------------------------------------------------
                            CODE CI-DESSOUS POUR LES BOUTONS AVEC LES LEDs
         --------------------------------------------------------------------------------------*/
        
        controls.Gameplay.P2_RedButton.performed += ctx => correctCircle(colorButton5);
        controls.Gameplay.P2_BlueButton.performed += ctx => correctCircle(colorButton6);
        controls.Gameplay.P2_GreenButton.performed    += ctx => correctCircle(colorButton7);
        controls.Gameplay.P2_YellowButton.performed += ctx => correctCircle(colorButton8);
        //controls.Gameplay.P1_PurpleButton.performed += ctx => correctCircle(Color.magenta);

    }

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }


    private void Update()
    {
        /*----------------------------------------------------------------------------------------------------------------
                        ACTIVER LE CODE CI-DESSOUS SEULEMENT SI ON FAIT AVEC LES BOUTONS LUMINEUX (LEDs)
         -----------------------------------------------------------------------------------------------------------------*/
        
        
        if (!isSameColorIndicator && !previousColorIndicator.Equals(progressiveCircular.getCurrentColorIndicator()))
        {
            colorButton5= lightUpLeds.sendColorsOfButtonAndRings(5); 
            colorButton6 = lightUpLeds.sendColorsOfButtonAndRings(6); 
            colorButton7 = lightUpLeds.sendColorsOfButtonAndRings(7);
            colorButton8 = lightUpLeds.sendColorsOfButtonAndRings(8);
            previousColorIndicator = progressiveCircular.getCurrentColorIndicator();

            isSameColorIndicator = true;
        }
        
        
        // Mets à false lorsque l'anneau de LEDs doit changer de couleur
        if (isSameColorIndicator && previousColorIndicator.Equals(progressiveCircular.getCurrentColorIndicator()))
        {
            isSameColorIndicator = false;
        }
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
           
            
            if (colorButton.Equals(progressiveCircular.getCurrentColorIndicator()))
            {
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
                

                // Vérifie si le joueur est redescendu jusqu'à la première
                if (progressiveCircular.getCurrentNumberOfHoldOnIndicator() == 1)
                {
                    isFirstHold = true;
                    ikControl.setIsFirstHold(true);
                }

                // Vérifie que le joueur puisse monter et qu'il ne doit pas être bloqué (appuyé sur le mauvais bouton)
                // Vérifie si le joueur est tombé alors on fait pour que la prochaine prise soit prise avec la bonne main
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
                
            }
            else
            {
                // Le bouton pressé est faux et on imagine qu'il a été pressé trop rapidement, si ce n'est pas le cas
                // alors on annule ce dernier.
                scoreScript.setIsGoodButton(false);
                scoreScript.setButtonPressedTooFast(false);
                
                // Le joueur doit être bloqué
                dropPlayer = true;

            }
            

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
                    ikControl.setGoodHandForClimb(false, true);
                }
                else
                {
                    ikControl.setGoodHandForClimb(true, false);
                }

                // Déplace l'indicateur
                progressiveCircular.setButtonPressed(true);
                progressiveCircular.stopProgressCircularBarCoroutine();
                progressiveCircular.setDefaultProgressCircularBarUI();
                progressiveCircular.moveNextIndicator();
            }
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