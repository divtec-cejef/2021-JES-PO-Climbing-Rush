using System.Collections.Generic;
using UnityEngine;
public class Display2Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Premet de changé la taille de la fenetre
        for (int i  = 0; i < Display.displays.Length;i++)
        {
            Display.displays[i].Activate(1080,1920,60);
        }
        
    }
}