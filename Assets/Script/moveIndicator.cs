using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHold : MonoBehaviour
{
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

    void Start()
    {
        moveSpeed = 10;

        listHoldRightCoordinateX.AddRange(new List<int>() {17, 10, 1, 21, 19, 12, 3});
        listHoldLeftCoordinateX.AddRange(new List<int>() {-3, -15, -11, -2, 0, -14, -21});
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
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
    }
}