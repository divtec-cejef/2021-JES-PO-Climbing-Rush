using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveIndicator : MonoBehaviour
{
    private const int HOLD_AXE_Z = 199;
    
    public GameObject handRight; 
    public GameObject handLeft;

    private bool grabRightHand = true;
    
    public float moveSpeed;

    private List<int> listHoldRightCoordinateX = new List<int>();
    private List<int> listHoldLeftCoordinateX = new List<int>();
    private List<Color> listColor = new List<Color>();

    private int indexCoRight = 0;
    private int indexCoLeft = 0;
    private int holdAxeY = 75;
    private int countColor = 0;
    private int nombreAleatoire = 0;


    void Start()
    {
        moveSpeed = 10;

        listHoldRightCoordinateX.AddRange(new List<int>() {10, 1, 21, 19, 12, 3});
        listHoldLeftCoordinateX.AddRange(new List<int>() {-15, -11, -2, 0, -14, -21});
        listColor.AddRange(new List<Color>() {Color.green, Color.yellow, Color.magenta, Color.red, Color.blue });
        
        var circleColorLeft = handLeft.GetComponent<Renderer>();
        var circleColorRight = handRight.GetComponent<Renderer>();
        
        circleColorLeft.material.SetColor("_Color",Color.blue);
        circleColorRight.material.SetColor("_Color",Color.red);
    }

    void Update()
    {
        
        var circleColorLeft = handLeft.GetComponent<Renderer>();
        var circleColorRight = handRight.GetComponent<Renderer>();
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            nombreAleatoire = Random.Range(0, 4);

            
            // Prends la prise de la main droite
            if (grabRightHand)
            {
                handRight.transform.position = new Vector3(listHoldRightCoordinateX[indexCoRight], holdAxeY, HOLD_AXE_Z);
                circleColorRight.material.SetColor("_Color",listColor[countColor]);

                holdAxeY += 25;
                grabRightHand = false;
                indexCoRight++;
                countColor++;

                if (countColor > 4)
                {
                    countColor = 0;
                }
                
            } 
            // Prends la prise de la main gauche
            else
            {
                handLeft.transform.position = new Vector3(listHoldLeftCoordinateX[indexCoLeft], holdAxeY, HOLD_AXE_Z);
                circleColorLeft.material.SetColor("_Color",listColor[countColor]);

                holdAxeY += 25;
                grabRightHand = true;
                indexCoLeft++;
                countColor++;

                if (countColor > 4)
                {
                    countColor = 0;
                }
            }
        }
    }
}