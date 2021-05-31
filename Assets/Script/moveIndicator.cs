using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MoveIndicator : MonoBehaviour
{
    private const int INDICATOR_AXE_Z = 199;


    public GameObject rightCircle;
    public GameObject leftCircle;

    private bool moveIndicatorRight = true;

    private List<int> listHoldRightCoordinateX = new List<int>();
    private List<int> listHoldLeftCoordinateX = new List<int>();
    private List<Color> listColorIndicator = new List<Color>();

    private int indexCoordinateRightHold = 0;
    private int indexCoordinateLeftHold = 0;
    private int holdAxeY = 75;
    private int indexListOfColorIndicator = 0;

    private Renderer circleColorRight;
    private Renderer circleColorLeft;

    private Color nextColorIndcator;
    private Color firstColorIndicator;
    private Color currentColorIndicator;

    private int previousRandomNumber = 0;

    public ShrinkIndicator shrinkIndicator;


    void Start()
    {
        // Permet de récupérer le matériau des indicateurs
        circleColorRight = rightCircle.GetComponent<Renderer>();
        circleColorLeft = leftCircle.GetComponent<Renderer>();


        // Liste des coordonnées des prises sur l'axe X 
        listHoldRightCoordinateX.AddRange(new List<int>() {10, 1, 21, 19, 12, 3});
        listHoldLeftCoordinateX.AddRange(new List<int>() {-15, -11, -2, 0, -14, -21});

        // Liste des couleurs des indicateurs
        listColorIndicator.AddRange(new List<Color>()
            {Color.red, Color.blue, Color.green, Color.yellow, Color.magenta});


        // Initialise les couleurs des deux premiers indicateurs au démarrage du jeu;
        circleColorRight.material.SetColor("_Color", getRandomColor());
        circleColorLeft.material.SetColor("_Color", getRandomColor());
        indexListOfColorIndicator += 2;

        // Récupère le couleur du premier indicateur 
        currentColorIndicator = circleColorRight.GetComponent<Renderer>().material.color;

        // Rétrécis le premier indicator jusqu'à la limite
        shrinkIndicator.shrinkCurrentIndicator(rightCircle);
    }


    /// <summary>
    /// Retourne les couleurs des indicateurs contenues dans une liste
    /// </summary>
    /// <returns> Une liste de couleur </returns>
    public List<Color> getColorIndicator()
    {
        return listColorIndicator;
    }


    /// <summary>
    /// Fais bouger les deux indicateurs de prises et change leur couleur non aléatoirement
    /// </summary>
    public void moveNextIndicator()
    {
        // L'indicateur droit se déplace à la prochaine prise et change de couleur
        if (moveIndicatorRight)
        {
            try
            {
                shrinkIndicator.correctButtonPressed = true;
                rightCircle.transform.position = new Vector3(listHoldRightCoordinateX[indexCoordinateRightHold],
                    holdAxeY, INDICATOR_AXE_Z);
                shrinkIndicator.defaultSizeIndicator(rightCircle);
                shrinkIndicator.shrinkCurrentIndicator(leftCircle);
            }
            catch
            {
            }


            // Récupération de la prise courante
            currentColorIndicator = circleColorLeft.GetComponent<Renderer>().material.color;

            circleColorRight.material.SetColor("_Color", getRandomColor());

            holdAxeY += 25;
            moveIndicatorRight = false;
            indexCoordinateRightHold++;
            indexListOfColorIndicator++;

            // Vérifie si les couleurs ont été déjà toutes faites et si c'est le cas
            // on recommence avec la première couleur, qui permet de refaire n prises.
            if (indexListOfColorIndicator >= listColorIndicator.Count)
            {
                indexListOfColorIndicator = 0;
            }
        }
        // L'indicateur gauche se déplace à la prochaine prise et change de couleur
        else
        {
            try
            {
                print("passer dans le try deuxième");
                shrinkIndicator.correctButtonPressed = true;
                leftCircle.transform.position = new Vector3(listHoldLeftCoordinateX[indexCoordinateLeftHold], holdAxeY,
                    INDICATOR_AXE_Z);
                shrinkIndicator.defaultSizeIndicator(leftCircle);
                shrinkIndicator.shrinkCurrentIndicator(rightCircle);
            }
            catch
            {
            }

            // Récupération de la prise courante
            currentColorIndicator = circleColorRight.GetComponent<Renderer>().material.color;

            circleColorLeft.material.SetColor("_Color", getRandomColor());

            holdAxeY += 25;
            moveIndicatorRight = true;
            indexCoordinateLeftHold++;
            indexListOfColorIndicator++;

            // Vérifie si les couleurs ont été déjà toutes faites et si c'est le cas
            // on recommence avec la première couleur, qui permet de refaire n prises.
            if (indexListOfColorIndicator >= listColorIndicator.Count)
            {
                indexListOfColorIndicator = 0;
            }
        }
    }

    /// <summary>
    /// Retourne une couleur aléatoire (soit rouge, bleu, vert, jaune ou violet)
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
        nextColorIndcator = listColorIndicator[randomNumber];

        return nextColorIndcator;
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