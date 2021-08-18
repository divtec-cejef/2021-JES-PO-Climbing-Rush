using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
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

    private Coroutine stopPlayerClimb;


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
            
            if (ikControl.getCanClimb() && !stuckPlayer)
            {
                
                print("peut grimper !");

                // Joue un effet autour de l'indicateur quand on attrape la prise
                effectBeamIndicator.playEffectBeam(progressiveCircular.getCurrentColorIndicator());
                
                
                // Ajout de points pour le score du joueur
                scoreScript.setButtonPressedTooFast(false);

                // Déplace l'indicateur à la prochaine prise
                progressiveCircular.setButtonPressed(true);
                progressiveCircular.stopProgressCircularBarCoroutine();
                progressiveCircular.setDefaultProgressCircularBarUI();
                progressiveCircular.moveNextIndicator();
                
                scoreScript.setIsTheSameCircle(false);


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
            
            
            
            stuckPlayer = true;
        }


        // Calcule les points
        scoreScript.calculatePoints();
        
        
        // Bloque le joueur pendant 2 secondes
        if (stuckPlayer) {
            stopPlayerClimb = StartCoroutine(StopPlayerClimbFor2Seconds());
        }
        
        
    }

    IEnumerator StopPlayerClimbFor2Seconds()
    {
        // Le joueur est bloqué pendant 2 secondes
        displayPopUpText.setBlocked(true);
        print("BLOQUÉ");
        stuckPlayer = true;
        yield return new WaitForSeconds(2f);
        
        stuckPlayer = false;

        StopCoroutine(stopPlayerClimb);
        displayPopUpText.setBlocked(false);
        print("la coroutine est stope !");
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