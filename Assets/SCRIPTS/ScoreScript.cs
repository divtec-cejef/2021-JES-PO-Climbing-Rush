using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{

    public ShrinkIndicator shrinkIndicator;

    public bool isGoodButton;

    public FlashIndicator flashIndicator;
    
    public static int scoreValue = 0;

    private bool hasShrinkBegan;
    
    
    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "Score : " + scoreValue;

    }



    public void calculatePoints()
    {
        float counter = shrinkIndicator.getSizeValueCircle();
        


        if (getIsGoodButton())
        {
            
            if (getHasShrinkBegan() == false)
            {
                scoreValue += 500;
            }else if (counter > 0.65f && counter < 0.75f)
            {
                scoreValue += 150;
            }else if (counter > 0.5f && counter < 0.5f)
            {
                scoreValue += 100;
            }else if(counter <= 0.5f){
                scoreValue += 10;
            }

        }else if (scoreValue < 200)
        {
            scoreValue = 0;
        }
        else
        {
            scoreValue -= 200;

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

    public bool getHasShrinkBegan()
    {
        return hasShrinkBegan;
    }

}