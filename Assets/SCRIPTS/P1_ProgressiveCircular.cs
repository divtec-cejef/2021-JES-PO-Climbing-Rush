using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using UnityEditor;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class P1_ProgressiveCircular : MonoBehaviour
{
    private int FIRST_HOLD = 1;

    public float speed = 0.001f;

    [SerializeField]
    private Image progressCircle;
    [SerializeField]
    private Canvas canvasIndicatorUI;
    [SerializeField]
    private Slider progressBar;
    
    public StartCountDownTimer startCountDownTimer;

    private Coroutine progressCircularBarUICoroutine;

    private bool isWait = false;

    private Color currentColorIndicator;
    private Vector3 positionNextHold;
    private Vector3 positionIndicatorUI;

    private int numberOfTarget;

    private List<Color> listColorIndicator = new List<Color>();
    private Color nextColorIndicator;
    
    private int previousRandomNumber = 0;

    private bool isButtonPressed = false;
    
    private float progressionCircularBar;
    
    public float intensity = 2;
    
    private Material spriteOutline;

    private bool fellPlayer = false;
    private bool isFirstHold = true;
    
    // Classe qui stocke les données du JSON (à modifier pour ajouter des données)
    private CircleProgressData loadedCircleProgressData;
    
    // Chemin du fichier JSON
    private string pathJsonFile;


    private void Start()
    {
        // Lecture du fichier JSON
        // Récupère le chemin du fichier json
        //string pathJsonFile = File.ReadAllText("C:/Users/Utilisateur/Desktop/data.json");
        pathJsonFile = File.ReadAllText("C:/data.json");
        
        // Stock dans la classe "CircleProgressData" les données du JSON
        loadedCircleProgressData = JsonUtility.FromJson<CircleProgressData>(pathJsonFile);
        
        
        // Initialise à zéro le bar de progression circulaire
        setDefaultProgressCircularBarUI();
        
        spriteOutline = progressCircle.GetComponent<Image>().material;
        

        // Liste des couleurs des indicateurs
        listColorIndicator.AddRange(new List<Color>()
            {Color.red, Color.blue, Color.green, Color.yellow, Color.magenta});


        // Ajout d'une couleur aléatoire à l'indicateur
        progressCircle.GetComponent<Image>().color = getRandomColor();
        //progressCircle.GetComponent<Image>().color = Color.cyan;
        currentColorIndicator = progressCircle.GetComponent<Image>().color;
        print("c'est quoi la couleur indicateur P1 : " + currentColorIndicator);
        
        
        // Initialise à 1 parce qu'on commence avec la prise 1
        numberOfTarget = FIRST_HOLD;

        // Téléporte le canvas qui contient l'indicateurUI pour être autour de la prise 1
        //canvasIndicatorUI.transform.position = GameObject.Find("prise " + numberOfTarget).transform.position;
        
        Vector3 currentPositionHold = GameObject.Find("P1_prise " + numberOfTarget).transform.position;
        //currentPositionHold.z -= 1.5f;
        currentPositionHold.z -= 0.8f;
        currentPositionHold.y += 0.25f;
        canvasIndicatorUI.transform.position = currentPositionHold;


        // Commence la progression de l'indicateur
        //launchProgressCircularBarUI();
    }

    private class CircleProgressData
    {
        public float speedIndicatorProgress;
        public float waitTimeProgress;
        public float portUSB;
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

        if (startCountDownTimer.getcountDownTimerIsFinished() && isFirstHold)
        {
            isFirstHold = false;
            launchProgressCircularBarUI();
        }
        
        progressBar.value = numberOfTarget - 1;
        progressionCircularBar = progressCircle.fillAmount;

        // Stock dans la classe "CircleProgressData" les données du JSON
        //loadedCircleProgressData = JsonUtility.FromJson<CircleProgressData>(pathJsonFile);

    }


    /// <summary>
    /// Change de place un des indicateurs de prises et change sa couleur aléatoirement
    /// </summary>
    public void moveNextIndicator()
    {

        // Si le joueur tombe on redescend d'une prise l'indicateur, sinon on le monte
        if (fellPlayer)
        {
            if (numberOfTarget != 1)
            {
                numberOfTarget--;
            }
        }
        else
        {
            numberOfTarget++;
        }
        
        print(".. numberOfTarget : " + numberOfTarget );
        

        
        // Téléporte le canvas qui contient l'indicateurUI pour être autour de la prochaine prise
        //canvasIndicatorUI.transform.position = GameObject.Find("prise " + numberOfTarget).transform.position;
        Vector3 currentPositionHold = GameObject.Find("P1_prise " + numberOfTarget).transform.position;
        //currentPositionHold.z -= 1.5f;
        //currentPositionHold.z -= 1f;
        currentPositionHold.z -= 0.8f;
        currentPositionHold.y += 0.2f;
        canvasIndicatorUI.transform.position = currentPositionHold;
        
        // Ajoute une couleur random sur cet indicateur si le joueur n'est pas tombé
        if (!fellPlayer)
        {
            progressCircle.GetComponent<Image>().color = getRandomColor();
        }
        
        
        // Récupération de la couleur de la prise courante 
        currentColorIndicator = progressCircle.GetComponent<Image>().color;
        
        // Affecte à faux pour que la progression circulaire recommence
        setButtonPressed(false);
        
        // Démarre la progression de l'indicateur
        launchProgressCircularBarUI();
        
    }


    /// <summary>
    /// Lance la coroutine qui augmentera la bar de progression circulaire
    /// </summary>
    public void launchProgressCircularBarUI()
    {
        progressCircularBarUICoroutine = StartCoroutine(ProgressCircularIndicatorUI());
    }

    
    
    IEnumerator ProgressCircularIndicatorUI()
    {
        
        while (!isButtonPressed)
        {
            
            // Augmente la barre de progression circulaire
            // Plus on rajoute des zéro après la virgule plus ça sera rapie (pour la fluidité du rétrécissement)
            progressCircle.fillAmount += loadedCircleProgressData.speedIndicatorProgress;
            //yield return new WaitForSeconds(0.001f);
            yield return new WaitForSeconds(loadedCircleProgressData.waitTimeProgress);
            

            // Attends 2 secondes lorsque la bar de progression circulaire est à 100%, et la remet à zéro après ces 2 secondes
            if (progressCircle.fillAmount == 1f)
            {
                yield return new WaitForSeconds(1f);
                
                // Remets à zéro la bar de progression circulaire
                progressCircle.fillAmount = 0f;
            }

        }
        
        yield return null;
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
        
       
        // Ajoute un effet de brillance autour de l'indicateur
        float factor = Mathf.Pow(2, intensity);
        
        float r = nextColorIndicator.r;
        float g = nextColorIndicator.g;
        float b = nextColorIndicator.b;
            
       Color colorGlow = new Color(r * factor, g * factor, b * factor);
       spriteOutline.SetColor(ShaderUtilities.ID_OutlineColor, colorGlow);
       

        return nextColorIndicator;
    }


    
    /// <summary>
    /// Retourne la couleur de l'incateur courrant
    /// </summary>
    /// <returns>la couleur de l'incateur courrant</returns>
    public Color getCurrentColorIndicator()
    {
        return currentColorIndicator;
    }


    public void setButtonPressed(bool isPressed)
    {
        isButtonPressed = isPressed;
    }

    

    /// <summary>
    /// On arrête la progression de la bar circulaire et on affecte à la variable son état
    /// </summary>
    public void stopProgressCircularBarCoroutine()
    {
        progressionCircularBar = progressCircle.fillAmount;
        StopCoroutine(progressCircularBarUICoroutine);
    }

    
    // Remets à zéro, la progression de la bar circulaire
    public void setDefaultProgressCircularBarUI()
    {
        progressCircle.fillAmount = 0;
    }


    /// <summary>
    /// Change à vrai si le joueur tombe sinon faux
    /// </summary>
    /// <param name="fell">Si le joueur est tombé ou non</param>
    public void setFellPlayer(bool fell)
    {
        fellPlayer = fell;
    }


    // Retourne la progression de la bare circulaire 
    public float getProgressionCircularBar()
    {
        return progressionCircularBar;
    }


    /// <summary>
    /// </summary>
    /// <returns>Retourne le numéro de la prise sur laquelle se trouve l'indicateur</returns>
    public int getCurrentNumberOfHoldOnIndicator()
    {
        return numberOfTarget;
    }
}