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
  

    public ProgressiveCircular progressiveCircular;




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
         
        print("du coup la couleur c'est : " + progressiveCircular.getCurrentColorIndicator());
        
        
       if (colorButton.Equals(progressiveCircular.getCurrentColorIndicator()))
        {

            scoreScript.setIsGoodButton(true);
            
            // Déplace l'indicateur à la prochaine prise
            progressiveCircular.setButtonPressed(true);
            progressiveCircular.stopProgressCircularBarCoroutine();
            progressiveCircular.setDefaultProgressCircularBarUI();
            progressiveCircular.moveNextIndicator();


            // Fais bouger le joueur à la prochaine prise
            ikControl.animationClimbingPlayer();
            

        }
        else
        {
            scoreScript.setIsGoodButton(false);
        }
       
       // Calcule les points
       scoreScript.calculatePoints();

        
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