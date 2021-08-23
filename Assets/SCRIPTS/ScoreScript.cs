using System;
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

    private int counterFullProgressionCircle = 0;

    private bool isTheSameCircle = true;

    private int counterALittleBitHigher = 1;
    private float oldValueOfProgressBar = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score : " + scoreValue;
    }

    private void Update()
    {
        float progressionCircle = progressiveCircular.getProgressionCircularBar();

        print("progressionCircle avant : " + progressionCircle);

        
        if (progressionCircle < 1f && oldValueOfProgressBar == 1f)
        {
            // c'est un nouveau rond qui commence
            counterFullProgressionCircle++;
            print("léo bouffe moi le cul : " + counterFullProgressionCircle);

        }

        oldValueOfProgressBar = progressionCircle;
        
        print("progressionCircle après : " + progressionCircle);
        print("COUNTER DE TA MERE LA PUTE : " + counterFullProgressionCircle);

        /*
        if (progressionCircle <= 1  && getIsTheSameCircle() && counterFullProgressionCircle < counterALittleBitHigher)
        {
            counterFullProgressionCircle++;
        }
        */
    }
    
    /// <summary>
    /// Calcule les points gagnés dépendant à quel moment on prend la prise, et les affiche sur HUD
    /// </summary>
    public void calculatePoints()
    {
        
        if (!getButtonIsPressedToFast())
        {
            
            if (getIsGoodButton())
            {
                if (counterFullProgressionCircle <= 1)
                {
                    scoreValue += 50;
                }
                else if (counterFullProgressionCircle <= 2)
                {
                    scoreValue += 20;
                }
                else if (counterFullProgressionCircle <= 3)
                {
                    scoreValue += 10;
                }
                else if (counterFullProgressionCircle > 3)
                {
                    scoreValue += 5;
                }
                
                counterFullProgressionCircle = 0;
                counterALittleBitHigher = 1;

                setIsTheSameCircle(true);
            }
            else
            {
                if (scoreValue < 15)
                {
                    scoreValue = 0;
                }
                else
                {
                    scoreValue -= 15;
                }
                
                counterFullProgressionCircle = 0;
            }
        }
        
        score.text = "Score : " + scoreValue;

    }

    public bool getIsTheSameCircle()
    {
        return isTheSameCircle;
    }
    
    public void setIsTheSameCircle(bool isTheSame)
    {
        isTheSameCircle = isTheSame;
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

}