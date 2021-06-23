using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{

    public ProgressiveCircular progressiveCircular;
    public Text score;
    
    private bool isGoodButton;
    
    private int scoreValue = 0;

    // Update is called once per frame
    void Update()
    {
        
        score.text = "Score : " + scoreValue;
    }

    public void calculatePoints()
    {
        float counter = progressiveCircular.getProgressionCircularBar();
        //float counter = 0;
        
        print("en fait je sais pas ce que ça retourne alors : " + counter);
        
        print("ouais dans le ScoreSript, valeur du button : " + getIsGoodButton());

        if (getIsGoodButton())
        {
            if (counter <= 0.3f)
            {
                scoreValue += 50;
            }else if (counter <= 0.6f)
            {
                scoreValue += 150;
            }else if (counter <= 0.9f)
            {
                scoreValue += 300;
            } else if (counter == 1)
            {
                scoreValue += 500;
            }
        }
        else
        {
            if (scoreValue !< 0)
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
}