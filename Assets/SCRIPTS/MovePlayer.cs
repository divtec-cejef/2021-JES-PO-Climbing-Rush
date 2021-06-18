using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    private const int NBRE_PRISES = 14;

    // Variable pour les boutons et les indicateurs de couleurs
    private PlayerControls controls;
    
    public MoveIndicator moveIndicator;
    public ShrinkIndicator shrinkIndicator;
    public FlashIndicator flashIndicator;
    public ScoreScript scoreScript;
    public IkControl ikControl;


    // Variables pour le déplacement du joueur
    private const int HOLD_AXE_Z = 190;

    // Des objets du jeu avec lesquels ont doit interagir par programmation
    //public GameObject handRight;
    //public GameObject handLeft;
    //public GameObject headAndBody;
    
    private bool grabRightHand = true;

    // Liste des coordonnées des prises droites et gauches
    private List<int> listHoldRightCoordinateX = new List<int>();
    private List<int> listHoldLeftCoordinateX = new List<int>();

    private int indexCoordinateRightHold = 0;
    private int indexCoordinateLeftHold = 0;
    private int holdAxeY = 25;
    private int playerAxeY = 0;
    
    // Liste de couleurs
    private List<Color> listColorIndicator = new List<Color>();
    private int indexListColorIndicator = 0;

    private int comptorNbrHolds = 1;
    
    private void Start()
    {
        // shrinkIndicator.setIsPressed(false);
        // Reprends depuis la classe _MoveIndicator_ les couleurs des indicateurs
        listColorIndicator = moveIndicator.getColorIndicator();
        
        // Liste des coordonnées sur l'axe X des prises
        listHoldRightCoordinateX.AddRange(new List<int>() {17, 10, 1, 21, 19, 12, 3});
        listHoldLeftCoordinateX.AddRange(new List<int>() {-3, -15, -11, -2, 0, -14, -21});
    }

    
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
        if (colorButton.Equals(moveIndicator.getCurrentColorIndicator()))
        {

            print("coucou");
            
            //scoreScript.setIsGoodButton(true);
            
            // Stop le clignotement de l'indicateur courant
            flashIndicator.stopFlashCurrentIndicator();
            
            // Déplace l'indicateur à la prochaine prise
            moveIndicator.moveNextIndicator();

            // Fais bouger le joueur à la prochaine prise
            ikControl.animationClimbingPlayer();
            

            comptorNbrHolds++;
            indexListColorIndicator++;


            // Si l'index de la liste des couleurs de l'indicateur est fini alors on recommence à zéro
            // pour continuer sur n prises.
            if (indexListColorIndicator >= listColorIndicator.Count)
            {
                indexListColorIndicator = 0;
            }
        }
        else
        {
            scoreScript.setIsGoodButton(false);
            print("LA VALEUR DU BOUTON = " + scoreScript.getIsGoodButton());
            
        }
        scoreScript.calculatePoints();

        
    }
    
    /*
    
    /// <summary>
    /// Déplace le joueur sur la prochaine prise
    /// </summary>
    void grabNextHold()
    {
        // Prends la prise de la main droite
        if (grabRightHand)
        {
            handRight.transform.position =
                new Vector3(listHoldRightCoordinateX[indexCoordinateRightHold], holdAxeY, HOLD_AXE_Z);

            holdAxeY += 25;
            grabRightHand = false;
            indexCoordinateRightHold++;
        }
        // Prends la prise de la main gauche
        else
        {
            handLeft.transform.position =
                new Vector3(listHoldLeftCoordinateX[indexCoordinateLeftHold], holdAxeY, HOLD_AXE_Z);

            holdAxeY += 25;
            grabRightHand = true;
            indexCoordinateLeftHold++;
        }

        // Monte le joueur
        headAndBody.transform.position = new Vector3(0, playerAxeY, HOLD_AXE_Z);

        playerAxeY += 25;
    }
    */

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