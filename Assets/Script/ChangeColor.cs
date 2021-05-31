using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material[] Materials;
    public int x;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = Materials[x];
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = Materials[x];
    }

    public void NextColor()
    {
        if (x < 2)
        {
            x++;
        }
        else
        {
            x = 0;
        }
    }
}