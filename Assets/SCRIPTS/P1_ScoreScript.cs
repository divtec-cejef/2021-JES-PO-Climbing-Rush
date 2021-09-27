using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class P1_ScoreScript : MonoBehaviour
{

    // Points possibles
    private const int MAX_POINT = 80;
    private const int MEDIUM_POINT = 40;
    private const int LOW_POINT = 20;
    private const int MIN_POINT = 10;
    private const int POINT_LOSS = 100;
    
    public P1_ProgressiveCircular progressiveCircular;

    private int currentScore;

    public TextMeshProUGUI score;
    public P1_GainPoint gainPoint;
    
    private bool isGoodButton;
    private bool isButtonPressedTooFast = false;
    
    private int scoreValue = 0;

    private int counterFullProgressionCircle = 0;

    private bool isTheSameCircle = true;

    private float oldValueOfProgressBar = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score : 0000";
    }

    private void Update()
    {
        float progressionCircle = progressiveCircular.getProgressionCircularBar();

        if (progressionCircle < 1f && oldValueOfProgressBar == 1f)
        {
            // c'est un nouveau rond qui commence
            counterFullProgressionCircle++;
        }

        oldValueOfProgressBar = progressionCircle;
        
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
                    scoreValue += MAX_POINT;
                    gainPoint.displayGainPoint(MAX_POINT, true);
                }
                else if (counterFullProgressionCircle <= 2)
                {
                    scoreValue += MEDIUM_POINT;
                    gainPoint.displayGainPoint(MEDIUM_POINT, true);

                }

                else if (counterFullProgressionCircle > 2)
                {
                    scoreValue += MIN_POINT;
                    gainPoint.displayGainPoint(MIN_POINT, true);

                }
                
                counterFullProgressionCircle = 0;

                setIsTheSameCircle(true);
            }
            else
            {
                if (scoreValue < POINT_LOSS)
                {
                    scoreValue = 0;
                    gainPoint.displayGainPoint(POINT_LOSS, false);

                }
                else
                {
                    scoreValue -= POINT_LOSS;
                    gainPoint.displayGainPoint(POINT_LOSS, false);

                }
                
                counterFullProgressionCircle = 0;
            }
        }

        if (scoreValue == 0)
        {
            score.text = "Score : 0000"; 
        }
        else if (scoreValue < 10)
        {
            score.text = "Score : 000" + scoreValue;
        }
        else if (scoreValue < 100)
        {
            score.text = "Score : 00" + scoreValue;
        }
        else if (scoreValue < 1000)
        {
            score.text = "Score : 0" + scoreValue;
        }
        else if (scoreValue > 1000)
        {
            score.text = "Score : " + scoreValue;
        }
        
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


    /// <summary>
    /// Ajoute des points si le timer n'est pas à 00:00
    /// </summary>
    /// <param name="timeValueRemaining"></param>
    public void addRemainingPointsOfTimer(float timeValueRemaining)
    {

        if (timeValueRemaining > 1)
        {
            int timeCastToPoints = (int)(timeValueRemaining * 60);

            gainPoint.displayGainPoint(timeCastToPoints, true);

            scoreValue += timeCastToPoints;
            
            score.text = "Score : " + scoreValue;
        }
        
        
    }


    /// <returns>Retourne le score du joueur 1</returns>
    public int getScoreValue()
    {
        return scoreValue;
    }
}