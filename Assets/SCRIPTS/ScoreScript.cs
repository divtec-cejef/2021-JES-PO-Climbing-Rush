using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public ProgressiveCircular progressiveCircular;
    //public TextMeshProUGUI score;

    private int currentScore;

    private Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        calculatePoints();
    }

    private bool isGoodButton;

    private int scoreValue = 0;


    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + scoreValue;
    }

    public void calculatePoints()
    {
        //float counter = shrinkIndicator.getValueX();

        //float counter = progressiveCircular.getProgressionCircularBar();
        //float counter = 0;

        //print("en fait je sais pas ce que ça retourne alors : " + counter);

        //print("ouais dans le ScoreSript, valeur du button : " + getIsGoodButton());


        float counter = 0;

        if (getIsGoodButton())
        {
            if (counter <= 0.3f)
            {
                currentScore += 50;
            }
            else if (counter <= 0.6f)
            {
                scoreValue += 150;
            }
            else if (counter <= 0.9f)
            {
                scoreValue += 300;
            }
            else if (counter == 1)
            {
                currentScore += 500;
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

    public int getScore()
    {
        return currentScore;
    }


    private void displayScore()
    {
        print("LA VALEUR DU SCORE :" + getScore());
        score.text = "Score : " + getScore();
    }
}