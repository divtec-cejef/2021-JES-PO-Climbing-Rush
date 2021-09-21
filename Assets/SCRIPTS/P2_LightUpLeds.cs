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


    private List<Color> listColorIndicator = new List<Color>();
    private List<Color> listColorIndicatorTmp = new List<Color>();

    private int countUp = 0;
    private bool isGoodColorAssignButton = false;
    private int buttonNumberOfGoodColor = 0;
    private bool hasFindIndexColorIndicator = false;


    public static SerialPort dataStream = new SerialPort("COM5", 9600);
    //private SerialPort dataStream = AnimationLEDs.dataStream;


    // Start is called before the first frame update
    void Start()
    {
        
        // Initialise le flux de série
        dataStream.Open();
        dataStream.WriteLine("ggg");

        previousColor = Color.white;
        
        // Liste des couleurs des indicateurs
        listColorIndicator.AddRange(new List<Color>()
            {Color.red, Color.blue, Color.green, Color.yellow});
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

        
        /*----------------------------------------------------------------------------------------
         -----------------------------------------------------------------------------------------
                         CODE CI-DESSOUS MARCHE SEULEMENT POUR UN ANNEAU LUMINEUX
         -----------------------------------------------------------------------------------------
         -----------------------------------------------------------------------------------------*/
        /*
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
        */
        
        
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
            print("laurent on rénitialise tout");
        }


        Color colorRandom = Color.black;
        int indexRandom = 0;


        if (numberOfButton != buttonNumberOfGoodColor)
        {
            indexRandom = Random.Range(0, listColorIndicatorTmp.Count);
            print("laurent indexRandom tirer : " + indexRandom);
    
            colorRandom = listColorIndicatorTmp[indexRandom];
            print("laurent couleur random : " + colorRandom);
            
            // Enlève la couleur qui a été tirée
            listColorIndicatorTmp.RemoveAt(indexRandom);
        }
        
        
        
        if (buttonNumberOfGoodColor == numberOfButton)
        {
            colorRandom = getColorOfIndicator();
            print("laurent couleur random 11: " + colorRandom);
        }

        print("Mymy nbr button + couleur : " + numberOfButton + " " + colorRandom);

        /*---------------------------------------------------------------------------
         ----------------------------------------------------------------------------
                        ACTIVER CE CODE QUAND L'ARDUINO EST CONNECTÉ AU PC     
        -----------------------------------------------------------------------------
        -----------------------------------------------------------------------------*/
        
        // Envoie le numéro du bouton ainsi que sa couleur à l'arduino
        if (colorRandom.Equals(Color.red))
        {
            print("bouton N°" + numberOfButton + ", couleur : " + colorRandom);
            //P1_LightUpLeds.dataStream.WriteLine(numberOfButton + "," + COLOR_RED);
            dataStream.WriteLine(numberOfButton + "," + COLOR_RED);
        }
        else if (colorRandom.Equals(Color.blue))
        {
            print("bouton N°" + numberOfButton + ", couleur : " + colorRandom);
            //P1_LightUpLeds.dataStream.WriteLine(numberOfButton + "," + COLOR_BLUE);
            dataStream.WriteLine(numberOfButton + "," + COLOR_BLUE);
        } 
        else if (colorRandom.Equals(Color.green))
        {
            print("bouton N°" + numberOfButton + ", couleur : " + colorRandom);
            //P1_LightUpLeds.dataStream.WriteLine(numberOfButton + "," + COLOR_GREEN);
            dataStream.WriteLine(numberOfButton + "," + COLOR_GREEN);
        }
        else if (colorRandom.Equals(Color.yellow))
        {
            print("bouton N°" + numberOfButton + ", couleur : " + colorRandom);
            //P1_LightUpLeds.dataStream.WriteLine(numberOfButton + "," + COLOR_YELLOW);
            dataStream.WriteLine(numberOfButton + "," + COLOR_YELLOW);
        }
        /*-----------------------------------------------------------------------------*/
        
        previousColor = getColorOfIndicator();

        // Renvoie aux boutons "virtuels" leurs couleurs
        return colorRandom;
    }
    
    
    /// <returns>Renvoie un numéro de button de 1 à 5</returns>
    private int randomNumberButton()
    {
        return Random.Range(5, 9);
    }

    
}