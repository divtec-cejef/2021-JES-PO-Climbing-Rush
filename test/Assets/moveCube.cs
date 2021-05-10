using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCube : MonoBehaviour

{

    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("Monte le joueur");
            this.transform.Translate(Vector3.up * 2);
        }

 

        // Descends le joueur sur l'axe Y
        if (Input.GetKey(KeyCode.DownArrow))
        {
            print("Monte le joueur");
            this.transform.Translate(Vector3.down * 2);
        }

 

        // Fais aller le joueur sur la gauche
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Fais aller le joueur à gauche");
            this.transform.Translate(Vector3.left * 2);
        }

 

        // Fais aller le joueur sur la droite
        if (Input.GetKey(KeyCode.RightArrow))
        {
            print("Fais aller le joueur à droite");
            this.transform.Translate(Vector3.right * 2);
        }
        
        if (Input.GetKey(KeyCode.G))
        {


            transform.position = new Vector3(1, 2, 1);

        }
        
        if (Input.GetKey(KeyCode.F))
        {

            transform.position = new Vector3(3, 2, 1);

        }

    }
    
}