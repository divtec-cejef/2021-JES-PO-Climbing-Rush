using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public ShrinkIndicator shrinkIndicator;

    public bool isGoodButton;

    public FlashIndicator flashIndicator;

    public static int scoreValue = 0;

    private bool hasShrinkBegan = true;

    private float counter;

    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score : " + scoreValue;
    }

    public void calculatePoints()
    {
        counter = shrinkIndicator.getSizeValueCircle();
        print("scoreScript counter : " + counter);

        print("ici c'est le coutner dans le scoreScript : " + counter);

        if (isGoodButton)
        {
            if (counter == 0)
            {
                counter = 0.8f;
            }

            if (counter <= 0.5f)
            {
                scoreValue += 10;
            }
            else if (counter <= 0.65f)
            {
                scoreValue += 150;
            }
            else
            {
                scoreValue += 500;
            }
        }


        score.text = "Score : " + scoreValue;
    }

    /// <summary>
    /// recupere la valeur du booleen
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

    public void setHasShrinkBegan(bool hasShrinkBegan)
    {
        this.hasShrinkBegan = hasShrinkBegan;
    }

    public float getCounter()
    {
        return counter;
    }

    public void setCounter(float counter)
    {
        this.counter = counter;
    }

    public void setWrongButton()
    {
        if (scoreValue <= 75)
        {
            scoreValue = 0;
        }
        else
        {
            scoreValue -= 75;
        }

        score.text = "Score : " + scoreValue;
    }
    
    public void losePointEverySecond()
    {
        if (scoreValue <= 10)
        {
            scoreValue = 0;
        }
        else
        {
            scoreValue -= 10;
        }

        score.text = "Score : " + scoreValue;
    }

}