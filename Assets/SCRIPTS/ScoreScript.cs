using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public ProgressiveCircular progressiveCircular;

    private int currentScore;

    public TextMeshProUGUI score;
    
    private bool isGoodButton;
    private bool isButtonPressedTooFast = false;
    
    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score : " + scoreValue;
    }

    
    

    /// <summary>
    /// Calcule les points gagnés dépendant à quel moment on prend la prise, et les affiche sur HUD
    /// </summary>
    public void calculatePoints()
    {

        float counter = progressiveCircular.getProgressionCircularBar();


        
        print("est-ce que le bouton a été pressé trop vite : " + getButtonIsPressedToFast());
        print("est-ce que c'est le bon bouton qui a été pressé : " + getIsGoodButton());
        
        print("est-ce que le counter : " + counter);
        
        
        if (!getButtonIsPressedToFast())
        {
            
            if (getIsGoodButton())
            {
                if (counter <= 0.3f)
                {
                    scoreValue += 50;
                }
                else if (counter <= 0.6f)
                {
                    scoreValue += 150;
                }
                else if (counter <= 0.9f)
                {
                    scoreValue += 300;
                }
                else if (counter == 1f)
                {
                    scoreValue += 500;
                }
            }
            else
            {
                if (scoreValue < 75)
                {
                    scoreValue = 0;
                }
                else
                {
                    scoreValue -= 75;
                }
            }
            
        }
        
        score.text = "Score : " + scoreValue;
    }
    
    
    /// <summary>
    /// recupere la valeur du booléen
    /// </summary>
    /// <returns></returns>
    public bool getIsGoodButton()
    {
        return isGoodButton;
    }

    /// <summary>
    /// Modifie la valeur du boolean
    /// </summary>
    /// <param name="isGoodButton"></param>
    public void setIsGoodButton(bool isGoodButton)
    {
        this.isGoodButton = isGoodButton;
    }



    /// <summary>
    /// Retourne la valeur si le bouton a été pressé trop rapidement ou non
    /// </summary>
    /// <returns></returns>
    public bool getButtonIsPressedToFast()
    {
        return isButtonPressedTooFast;
    }

    
    /// <summary>
    /// Change la valeur du booléen, vrai si le bouton est appuyé trop rapidement sinon faux
    /// </summary>
    /// <param name="tooFast">Si le bouton a été appuyé trop rapidement</param>
    public void setButtonPressedTooFast(bool tooFast)
    {
        isButtonPressedTooFast = tooFast;
    }
    
    
    
    
    public int getScore()
    {
        return currentScore;
    }


}