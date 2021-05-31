using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        // Monte le joueur sur l'axe Y
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.Translate(Vector3.up * moveSpeed);
        }

        // Descends le joueur sur l'axe Y
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(Vector3.down * moveSpeed);
        }

        // Fais aller le joueur sur la gauche
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * moveSpeed);
        }

        // Fais aller le joueur sur la droite
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * moveSpeed);
        }

        // Fais aller le joueur en avant
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * moveSpeed);
        }

        // Fais aller le joueur à reculon
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * moveSpeed);
        }
    }
}