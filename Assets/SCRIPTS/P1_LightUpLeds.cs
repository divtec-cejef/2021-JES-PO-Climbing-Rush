using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.IO.Ports;
using TMPro;

public class P1_LightUpLeds : MonoBehaviour
{
    private const int MAX_COUNT_DOWN = 3;

    public P1_ProgressiveCircular progressiveCircular;


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
    private int buttonNumberOfGoodColor = 0;
    private int countUp = 0;
    private int indexColorIndicator = 0;

    private bool isChangedColorRing = false;
    private bool isGoodColorAssignButton = false;
    private bool hasFindIndexColorIndicator = false;


    private List<Color> listColorIndicator = new List<Color>();
    private List<Color> listColorIndicatorTmp = new List<Color>();

    //private SerialPort dataStream = AnimationLEDs.dataStream;
    

    // Chemin du fichier JSON
    private string pathJsonFile;

    //public static SerialPort dataStream = new SerialPort("COM5", 9600);


    // Start is called before the first frame update
    void Start()
    {
        // Initialise le flux de série
        //dataStream.Open();
        //dataStream.WriteLine("g");
        P2_LightUpLeds.dataStream.WriteLine("ggg");


        previousColor = Color.white;

        // Liste des couleurs des indicateurs
        listColorIndicator.AddRange(new List<Color>()
            {Color.red, Color.blue, Color.green, Color.yellow});
        
       }


    // Update is called once per frame
    void Update()
    {
        currentColor = progressiveCircular.getCurrentColorIndicator();
    }


    /// <returns>La couleur de l'indicateur</returns>
    private Color getColorOfIndicator()
    {
        return progressiveCircular.getCurrentColorIndicator();
    }


    /// <summary>
    /// Envoie la couleur que les boutons auront ainsi qu'aux anneaux LEDs correspondant
    /// </summary>
    public Color sendColorsOfButtonAndRings(int numberOfButton)
    {
        countUp++;


        if (!isGoodColorAssignButton)
        {
            isGoodColorAssignButton = true;
            listColorIndicatorTmp.AddRange(new List<Color>()
                {Color.red, Color.blue, Color.green, Color.yellow});

            listColorIndicatorTmp.Remove(getColorOfIndicator());
            
            buttonNumberOfGoodColor = randomNumberButton();
        }
        
        
        if (countUp == 4)
        {
            countUp = 0;
            isGoodColorAssignButton = false;
            hasFindIndexColorIndicator = false;
        }


        Color colorRandom = Color.black;
        int indexRandom = 0;


        if (numberOfButton != buttonNumberOfGoodColor)
        {
            indexRandom = Random.Range(0, listColorIndicatorTmp.Count);
    
            colorRandom = listColorIndicatorTmp[indexRandom];
            
            // Enlève la couleur qui a été tirée
            listColorIndicatorTmp.RemoveAt(indexRandom);
        }
        
        
        
        if (buttonNumberOfGoodColor == numberOfButton)
        {
            colorRandom = getColorOfIndicator();
        }


        /*---------------------------------------------------------------------------
         ----------------------------------------------------------------------------
                        ACTIVER CE CODE QUAND L'ARDUINO EST CONNECTÉ AU PC     
        -----------------------------------------------------------------------------
        -----------------------------------------------------------------------------*/
        
        // Envoie le numéro du bouton ainsi que sa couleur à l'arduino
        if (colorRandom.Equals(Color.red))
        {
            print("bouton N°" + numberOfButton + ", couleur : " + colorRandom);
            //dataStream.WriteLine(numberOfButton + "," + COLOR_RED);
            P2_LightUpLeds.dataStream.WriteLine(numberOfButton + "," + COLOR_RED);
        }
        else if (colorRandom.Equals(Color.blue))
        {
            print("bouton N°" + numberOfButton + ", couleur : " + colorRandom);
            //dataStream.WriteLine(numberOfButton + "," + COLOR_BLUE);
            P2_LightUpLeds.dataStream.WriteLine(numberOfButton + "," + COLOR_BLUE);
        } 
        else if (colorRandom.Equals(Color.green))
        {
            print("bouton N°" + numberOfButton + ", couleur : " + colorRandom);
            //dataStream.WriteLine(numberOfButton + "," + COLOR_GREEN);
            P2_LightUpLeds.dataStream.WriteLine(numberOfButton + "," + COLOR_GREEN);
        }
        else if (colorRandom.Equals(Color.yellow))
        {
            print("bouton N°" + numberOfButton + ", couleur : " + colorRandom);
           // dataStream.WriteLine(numberOfButton + "," + COLOR_YELLOW);
            P2_LightUpLeds.dataStream.WriteLine(numberOfButton + "," + COLOR_YELLOW);
        }
        /*-----------------------------------------------------------------------------*/
        
        previousColor = getColorOfIndicator();

        // Renvoie aux boutons "virtuels" leurs couleurs
        return colorRandom;
    }


    /// <returns>Renvoie un numéro de button de 1 à 5</returns>
    private int randomNumberButton()
    {
        return Random.Range(1, 5);
    }
}