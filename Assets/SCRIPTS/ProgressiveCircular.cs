using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class ProgressiveCircular : MonoBehaviour
{
    private int FIRST_HOLD = 1;

    public Image progressCircle;
    public float speed = 0.001f;
    public Canvas canvasIndicatorUI;
    public Slider progressBar;

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


    private void Start()
    {
        // Initialise à zéro le bar de progression circulaire
        setDefaultProgressCircularBarUI();
        
        spriteOutline = progressCircle.GetComponent<Image>().material;

        // Liste des couleurs des indicateurs
        listColorIndicator.AddRange(new List<Color>()
            {Color.red, Color.blue, Color.green, Color.yellow, Color.magenta});


        // Ajout d'une couleur aléatoire à l'indicateur
        progressCircle.GetComponent<Image>().color = getRandomColor();
        currentColorIndicator = progressCircle.GetComponent<Image>().color;
        
        // Initialise à 1 parce qu'on commence avec la prise 1
        numberOfTarget = FIRST_HOLD;

        // Téléporte le canvas qui contient l'indicateurUI pour être autour de la prise 1
        canvasIndicatorUI.transform.position = GameObject.Find("prise " + numberOfTarget).transform.position;

        // Commence la progression de l'indicateur
        launchProgressCircularBarUI();
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
        numberOfTarget++;

        
        // Téléporte le canvas qui contient l'indicateurUI pour être autour de la prochaine prise
        canvasIndicatorUI.transform.position = GameObject.Find("prise " + numberOfTarget).transform.position;
        
        // Ajoute une couleur random sur cet indicateur
        progressCircle.GetComponent<Image>().color = getRandomColor();
        
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
            // Plus on rajoute des zéro plus ça sera lent
            progressCircle.fillAmount += speed;
            yield return new WaitForSeconds(0.001f);

            print("fillAmount : " + progressCircle.fillAmount);

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

    
    
    // Retourne la progression de la bare circulaire 
    public float getProgressionCircularBar()
    {
        return progressionCircularBar;
    }
    
}