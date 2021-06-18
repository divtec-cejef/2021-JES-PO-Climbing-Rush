using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{

    public ShrinkIndicator shrinkIndicator;

    public bool isGoodButton;
    
    public static int scoreValue = 0;

    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        score.text = "Score : " + scoreValue;

    }

    public void calculatePoints()
    {
        float counter = shrinkIndicator.getValueX();
        
        print("ouais dans le ScoreSript, valeur du button : " + getIsGoodButton());

        if (getIsGoodButton())
        {

            if (counter > 0.75f)
            {
                scoreValue += 50;
            }else if (counter > 0.55f)
            {
                scoreValue += 150;
            }else if (counter > 0.4f)
            {
                scoreValue += 500;
            }

        }else if (scoreValue < 10)
        {
            scoreValue = 0;
        }
        else
        {
            scoreValue -= 10;

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