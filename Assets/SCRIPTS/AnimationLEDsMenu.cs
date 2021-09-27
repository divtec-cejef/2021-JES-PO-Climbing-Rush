using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class AnimationLEDsMenu : MonoBehaviour
{
    private SerialPort dataStream = new SerialPort("COM5", 9600);
    void Start()
    {
        // Initialise le flux de série
        dataStream.Open();
        dataStream.WriteLine("mmm");
    }

}
