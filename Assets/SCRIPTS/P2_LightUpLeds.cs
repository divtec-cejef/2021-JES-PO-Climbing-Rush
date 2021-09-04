using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.IO.Ports;
using TMPro;

public class P2_LightUpLeds : MonoBehaviour
{
    private const int MAX_COUNT_DOWN = 3;

    public P2_ProgressiveCircular progressiveCircular;


    private const string COLOR_RED = "r";
    private const string COLOR_BLUE = "b";
    private const string COLOR_GREEN = "g";
    private const string COLOR_YELLOW = "y";
    private const string COLOR_MAGENTA = "m";


    private bool sameColorIndicator = false;
    private bool isFirstColor = true;

    private Color currentColor;
    private Color previousColor;
    private Color tmpColor;

    private int counterDown = 0;

    private bool isChangedColorRing = false;


    // Chemin du fichier JSON
    private string pathJsonFile;

    private SerialPort dataStream = new SerialPort("COM3", 9600);


    // Start is called before the first frame update
    void Start()
    {
        // Initialise le flux de série
        dataStream.Open();

        previousColor = Color.white;
    }


    // Update is called once per frame
    void Update()
    {
       
        currentColor = progressiveCircular.getCurrentColorIndicator();
        

        /*
        do
        {
            // Couleur rouge
            if (currentColor.Equals(Color.red))
            {
                dataStream.WriteLine("1," + COLOR_RED);
                isChangedColorRing = true;
                print("changement de couleur");
            }

            // Couleur bleu
            if (currentColor.Equals(Color.blue))
            {
                dataStream.WriteLine("1," + COLOR_BLUE);
                isChangedColorRing = true;
                print("changement de couleur");
            }

            // Couleur vert
            if (currentColor.Equals(Color.green))
            {
                dataStream.WriteLine("1," + COLOR_GREEN);
                isChangedColorRing = true;
                print("changement de couleur");
            }

            // Couleur jaune
            if (currentColor.Equals(Color.yellow))
            {
                dataStream.WriteLine("1," + COLOR_YELLOW);
                isChangedColorRing = true;
                print("changement de couleur");
            }

            // Couleur magenta
            if (currentColor.Equals(Color.magenta))
            {
                dataStream.WriteLine("1," + COLOR_MAGENTA);
                isChangedColorRing = true;
                print("changement de couleur");
            }

            counterDown++;
        } while (counterDown < 3);
        */

        
        // Le premier if permet de ne pas surcharger l'arduino qui fera crash le jeu
        // Change la couleur des LEDs
        if (!isChangedColorRing && !currentColor.Equals(previousColor))
        {
            // Couleur rouge
            if (currentColor.Equals(Color.red))
            {
                dataStream.WriteLine("1," + COLOR_RED);
                dataStream.WriteLine("1," + COLOR_RED);
                //dataStream.WriteLine("1," + COLOR_RED);
                isChangedColorRing = true;
                print("changement de couleur");
            }

            // Couleur bleu
            if (currentColor.Equals(Color.blue))
            {
                dataStream.WriteLine("1," + COLOR_BLUE);
                dataStream.WriteLine("1," + COLOR_BLUE);
                //dataStream.WriteLine("1," + COLOR_BLUE);
                isChangedColorRing = true;
                print("changement de couleur");
            }

            // Couleur vert
            if (currentColor.Equals(Color.green))
            {
                dataStream.WriteLine("1," + COLOR_GREEN);
                dataStream.WriteLine("1," + COLOR_GREEN);
                //dataStream.WriteLine("1," + COLOR_GREEN);
                isChangedColorRing = true;
                print("changement de couleur");
            }

            // Couleur jaune
            if (currentColor.Equals(Color.yellow))
            {
                dataStream.WriteLine("1," + COLOR_YELLOW);
                dataStream.WriteLine("1," + COLOR_YELLOW);
                //dataStream.WriteLine("1," + COLOR_YELLOW);
                isChangedColorRing = true;
                print("changement de couleur");
            }

            // Couleur magenta
            if (currentColor.Equals(Color.magenta))
            {
                dataStream.WriteLine("1," + COLOR_MAGENTA);
                dataStream.WriteLine("1," + COLOR_MAGENTA);
                //dataStream.WriteLine("1," + COLOR_MAGENTA);
                isChangedColorRing = true;
                print("changement de couleur");
            }

            previousColor = currentColor;
        }


        // Mets à false lorsque l'anneau de LEDs doit changer de couleur
        if (isChangedColorRing && currentColor.Equals(previousColor))
        {
            isChangedColorRing = false;
        }
        
    }
}