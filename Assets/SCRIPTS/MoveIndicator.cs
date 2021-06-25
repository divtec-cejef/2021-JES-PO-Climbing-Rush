using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MoveIndicator : MonoBehaviour
{
    public ShrinkIndicator shrinkIndicator;
    public GameObject rightCircle;
    public GameObject leftCircle;
    public FlashIndicator flashIndicator;

    private bool moveIndicatorRight = true;

    private List<Color> listColorIndicator = new List<Color>();
    
    private Renderer circleColorRight;
    private Renderer circleColorLeft;

    private Color nextColorIndicator;
    private Color firstColorIndicator;
    private Color currentColorIndicator;

    private int previousRandomNumber = 0;

    private Vector3 positionNextHoldRight;
    private Vector3 positionNextHoldLeft;

    private int numberOfTarget;

    public Slider progressBar; 


    void Start()
    {
        // Permet de récupérer le matériau des indicateurs afin de leurs ajouter par la suite des couleurs
        circleColorRight = rightCircle.GetComponent<Renderer>();
        circleColorLeft = leftCircle.GetComponent<Renderer>();

        numberOfTarget = 1;
        
        // Prends les coordonnées de la première et deuxième prise
        positionNextHoldRight = GameObject.Find("prise " + numberOfTarget).transform.position;
        positionNextHoldLeft = GameObject.Find("prise " + numberOfTarget + 1).transform.position;


        // Liste des couleurs des indicateurs
        listColorIndicator.AddRange(new List<Color>()
            {Color.red, Color.blue, Color.green, Color.yellow, Color.magenta});

        // Initialise les couleurs des deux premiers indicateurs au démarrage du jeu;
        circleColorRight.material.SetColor("_Color", getRandomColor());
        circleColorLeft.material.SetColor("_Color", getRandomColor());

        // Récupère le couleur du premier indicateur 
        currentColorIndicator = circleColorRight.GetComponent<Renderer>().material.color;
    }


    
    /// <summary>
    /// Retourne les couleurs des indicateurs contenues dans une liste
    /// </summary>
    /// <returns> Une liste de couleur </returns>
    public List<Color> getColorIndicator()
    {
        return listColorIndicator;
    }

    private void Update()
    {
        progressBar.value = numberOfTarget - 1;
    }


    /// <summary>
    /// Change de place un des indicateurs de prises et change sa couleur aléatoirement
    /// </summary>
    public void moveNextIndicator()
    {
        // Stop le rétrécissement de l'indicateur courant
        //shrinkIndicator.stopShrinkIndicator();

        numberOfTarget++;

        // L'indicateur droit se déplace à la prochaine prise et change de couleur
        if (moveIndicatorRight)
        {
            try
            {
                // Prends la position de la prochaine prise
                positionNextHoldRight = GameObject.Find("prise " + (numberOfTarget + 1)).transform.position;
                
                // Déplace l'indicateur gauche à la prochaine prise gauche
                rightCircle.transform.position = new Vector3(positionNextHoldRight.x,
                    positionNextHoldRight.y, positionNextHoldRight.z - 0.01f);
            }
            catch
            {
            }

            // Récupération de la couleur de la prise courante 
            currentColorIndicator = circleColorLeft.GetComponent<Renderer>().material.color;

            // Ajoute une couleur random sur cet indicateur
            circleColorRight.material.SetColor("_Color", getRandomColor());

            moveIndicatorRight = false;
            
        }
        // L'indicateur gauche se déplace à la prochaine prise et change de couleur
        else
        {
            try
            {
                // Prends la position de la prochaine prise
                positionNextHoldLeft = GameObject.Find("prise " + (numberOfTarget + 1)).transform.position;

                // Déplace l'indicateur gauche à la prochaine prise gauche
                leftCircle.transform.position = new Vector3(positionNextHoldLeft.x,
                    positionNextHoldLeft.y, positionNextHoldLeft.z - 0.01f);

            }
            catch
            {
            }
            
            // Récupération de la couleur de la prise courante 
            currentColorIndicator = circleColorRight.GetComponent<Renderer>().material.color;

            // Ajoute une couleur random sur cet indicateur
            circleColorLeft.material.SetColor("_Color", getRandomColor());

            moveIndicatorRight = true;
            
        }
        
        // Remets la taille par défaut de l'indicateur qui s'est fait rétrécir
        shrinkIndicator.setDefaultSizeIndicator();
        
        // Rétrécis l'indicateur courant
        //shrinkIndicator.shrinkCurrentIndicator();
        
        // Fais clignoter l'indicateur courant
        flashIndicator.flashCurrentIndicator();
    }
    
    /// <summary>
    /// Retourne une couleur aléatoire (rouge, bleu, vert, jaune ou violet)
    /// </summary>
    /// <returns>une couleur aléatoire</returns>
    private Color getRandomColor()
    {
        int randomNumber = 0;
        do
        {
            randomNumber = Random.Range(0, 5);
            
        } while (randomNumber == previousRandomNumber);

        previousRandomNumber = randomNumber;
        nextColorIndicator = listColorIndicator[randomNumber];

        return nextColorIndicator;
    }

    
    
    /// <summary>
    /// Retourne la couleur de l'incateur courant
    /// </summary>
    /// <returns>la couleur de l'incateur courant</returns>
    public Color getCurrentColorIndicator()
    {
        return currentColorIndicator;
    }
}