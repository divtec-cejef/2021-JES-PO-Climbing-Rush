using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    // Variables pour les boutons et les indicateurs
    private PlayerControls controls;
    private List<char> listColorCircleIndicator = new List<char>();
    private int indexListColorCircle = 0;
    
    
    // Variables pour le déplacement du joueur
    private const int HOLD_AXE_Z = 190;

    public GameObject handRight; 
    public GameObject handLeft;
    private bool grabRightHand = true;
    
    public float moveSpeed;

    private List<int> listHoldRightCoordinateX = new List<int>();
    private List<int> listHoldLeftCoordinateX = new List<int>();

 
    private int indexCoRight = 0;
    private int indexCoLeft = 0;
    private int holdAxeY = 25;
    private int playerAxeY = 0;

    private void Start()
    {
        listColorCircleIndicator.AddRange(new List<char>(){'R', 'B', 'G', 'Y', 'P'});
     
        listHoldRightCoordinateX.AddRange(new List<int>() {17, 10, 1, 21, 19, 12, 3});
        listHoldLeftCoordinateX.AddRange(new List<int>() {-3, -15, -11, -2, 0, -14, -21});
    }

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.RedButton.performed += ctx => CorrectCircle('R');
        controls.Gameplay.BlueButton.performed += ctx => CorrectCircle('B');
        controls.Gameplay.GreenButton.performed += ctx => CorrectCircle('G');
        controls.Gameplay.YellowButton.performed += ctx => CorrectCircle('Y');
        controls.Gameplay.PurpleButton.performed += ctx => CorrectCircle('P');
    }

    // Vérifie si le bouton appuyé correspondant avec la couleur du cercle courrant
    void CorrectCircle(char colorButton)
    {
        if (colorButton == listColorCircleIndicator[indexListColorCircle])
        {
            print("bouton " + colorButton);
            
            indexListColorCircle++;
            
            if (indexListColorCircle >= listColorCircleIndicator.Count)
            {
                indexListColorCircle = 0;
            }

            // Fais bouger le joueur à la prochaine prise
            MovePlayerToGrab();
        }
    }

    void MovePlayerToGrab()
    {
        // Prends la prise de la main droite
        if (grabRightHand)
        {
            handRight.transform.position = new Vector3(listHoldRightCoordinateX[indexCoRight], holdAxeY, HOLD_AXE_Z);

            holdAxeY += 25;
            grabRightHand = false;
            indexCoRight++;
        } 
        // Prends la prise de la main gauche
        else
        {
            handLeft.transform.position = new Vector3(listHoldLeftCoordinateX[indexCoLeft], holdAxeY, HOLD_AXE_Z);
            holdAxeY += 25;
            grabRightHand = true;
            indexCoLeft++;
        }
            
        // Monte le joueur
        this.transform.position = new Vector3(0, playerAxeY, HOLD_AXE_Z);

        playerAxeY += 25;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
