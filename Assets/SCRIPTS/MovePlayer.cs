using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class MovePlayer : MonoBehaviour
{
    private const int MAX_PRESS_BUTTON_BEFORE_FALL = 2;
    
    // Variable pour les boutons pressoirs
    private PlayerControls controls;


    public MoveIndicator moveIndicator;
    public FlashIndicator flashIndicator;
    public ScoreScript scoreScript;
    public IkControl ikControl;
    public EffectBeamIndicator effectBeamIndicator;
    public ProgressiveCircular progressiveCircular;
    public DisplayPopUpText displayPopUpText;
        
    
    private bool stuckPlayer = false;
    private bool waitWhileCoroutine = false;
    private int wrongButtonPressTwice = 0;

    private Coroutine stopPlayerClimb;

    private bool isFirstHold = true;
    private bool fellPlayer = false;



    void Awake()
    {
        controls = new PlayerControls();

        // Les cinq boutons à contrôler
        controls.Gameplay.RedButton.performed += ctx => correctCircle(Color.red);
        controls.Gameplay.BlueButton.performed += ctx => correctCircle(Color.blue);
        controls.Gameplay.GreenButton.performed += ctx => correctCircle(Color.green);
        controls.Gameplay.YellowButton.performed += ctx => correctCircle(Color.yellow);
        controls.Gameplay.PurpleButton.performed += ctx => correctCircle(Color.magenta);
    }


    /// <summary>
    /// Vérifie si le bouton appuyé correspondant avec la couleur du cercle courrant
    /// </summary>
    /// <param name="colorButton"> La couleur du bouton qui est appuyé </param>
    public void correctCircle(Color colorButton)
    {
        if (colorButton.Equals(progressiveCircular.getCurrentColorIndicator()))
        {
            scoreScript.setButtonPressedTooFast(true);
            scoreScript.setIsGoodButton(true);
            
            
            // Le joueur n'a pas appuyé deux fois sur le mauvais bouton
            wrongButtonPressTwice = 0;
            
            
            // On dit que le joueur n'est pas tombé ou qu'il remonte
            ikControl.setDoFallPlayer(false);

            
            // Le joueur ne doit pas être bloqué
            stuckPlayer = false;

            
            print("avant de monter !");
            
            
            // Vérifie que le joueur puisse monter et qu'il ne doit pas être bloqué (appuyé sur le mauvais bouton)
            if (ikControl.getCanClimb() && !waitWhileCoroutine)
            {
                
                print("monte !");
                
                
                // Vérifie si le joueur est tombé alors on fait pour que la prochaine prise soit prise avec la bonne main
                if (ikControl.getFellPlayer() && ikControl.getNumberOfHoldCurrent() != 1)
                {
                    if (ikControl.getIsHoldRight())
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
        }
        else
        { 
            // Le bouton pressé est faux et on imagine qu'il a été pressé trop rapidement, si ce n'est pas le cas
            // alors on annule ce dernier.
            scoreScript.setIsGoodButton(false);
            scoreScript.setButtonPressedTooFast(true);

            if (ikControl.getCanClimb())
            {
                scoreScript.setButtonPressedTooFast(false);
            }
            
            // Le joueur doit être bloqué
            stuckPlayer = true;
            
            // Le joueur doit descendre d'une prise si wrongButtonPressTwice = 2
            wrongButtonPressTwice++;
        }


        // Calcule les points
        scoreScript.calculatePoints();

        
        // Descends le joueur d'une prise
        if (stuckPlayer && wrongButtonPressTwice >= 2 && !isFirstHold)
        {
            print("le joueur doit tomber");
            
            ikControl.setDoFallPlayer(true);
        }
        // Bloque le joueur pendant 2 secondes
        else if (stuckPlayer) {
            stopPlayerClimb = StartCoroutine(StopPlayerClimbFor2Seconds());
        }

        
        // Vérifie qu'on est pas redescendu juqu'à la première prise
        if (!isFirstHold && ikControl.getNumberOfHoldCurrent() == 0)
        {
            isFirstHold = true;
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
    /// </summary>
    /// <returns>Retourne si vrai si le joueur est tombé sinon faux</returns>
    public bool getFellPlayer()
    {
        return fellPlayer;
    }


    /// <summary>
    /// Change à vrai si le joueur est tombé et vice versa
    /// </summary>
    /// <param name="fell">Si le joueur est tombé alors vrai sinon faux</param>
    public void setFellPlayer(bool fell)
    {
        fellPlayer = fell;
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