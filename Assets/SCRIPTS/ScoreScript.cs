using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{

    public ShrinkIndicator shrinkIndicator;

    public bool isGoodButton;
    
    public static int scoreValue = 0;
    
    private int currentScore;

    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        calculatePoints();

    }

    // Update is called once per frame
    void Update()
    {
        
        displayScore();

    }

    public void calculatePoints()
    {
        float counter = shrinkIndicator.getValueX();

        if (getIsGoodButton())
        {

            if (counter > 0.75f)
            {
                currentScore += 50;
            }else if (counter > 0.55f)
            {
                currentScore += 150;
            }else if (counter > 0.4f)
            {
                currentScore += 500;
            }

        }else if (currentScore < 10)
        {
            currentScore = 0;
        }
        else
        {
            currentScore -= 10;

        }

        currentScore = 100;
        print("LA VALEUR DANS LE CALCULATE : " + getScore());
        
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