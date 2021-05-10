using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,   //gauche & droite
            moveSpeed*Input.GetAxis("Jump")*Time.deltaTime,                         // monter
            moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);                    // haut & bas
    }
}
