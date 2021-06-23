using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FlashIndicator : MonoBehaviour
{
    private Renderer currenIndicator;
    private Coroutine flashIndicator;
    public MoveIndicator moveIndicator;
    public ShrinkIndicator shrinkIndicator;
    public GameObject rightIndicator;
    public GameObject leftIndicator;
    private bool isRightIndicatorCurrent = true;
    private bool continueFlash = true;
    
    private bool hasShrinkBegan;

    public ScoreScript scoreScript;
    
    private GameObject indicatorCurrent;

    private Renderer colorIndicatorCurrent;

    private int counter;

    private void Start()
    {
        flashCurrentIndicator();
    }

    /// <summary>
    /// Appelle la fonction qui fera clignoter les indicateurs
    /// </summary>
    /// <param name="indicatorCurrent"></param>
    public void flashCurrentIndicator()
    {
        
        scoreScript.setHasShrinkBegan(false);
        
        // Test de qui est l'indicateur courrant     
        if (isRightIndicatorCurrent)
        {
            indicatorCurrent = rightIndicator;
            isRightIndicatorCurrent = false;
        }
        else
        {
            indicatorCurrent = leftIndicator;
            isRightIndicatorCurrent = true;
        }
        
        
        Color currentColor = moveIndicator.getCurrentColorIndicator();

        colorIndicatorCurrent = indicatorCurrent.GetComponent<Renderer>();
        
        flashIndicator = StartCoroutine(FlashCurrentIndicator(currentColor));
    }

    /// <summary>
    /// Fais clignoter l'indicateur courant
    /// </summary>
    /// <param name="currentColor"></param>
    /// <returns></returns>
    IEnumerator FlashCurrentIndicator(Color currentColor)
    {
        
        counter = 0;
        continueFlash = true;

        Color transparentColor = currentColor;
        transparentColor.a = 0.4f;
        
        while (continueFlash)
        {
            
            yield return new WaitForSeconds(0.2f);
            colorIndicatorCurrent.material.SetColor("_Color", currentColor);
            
            yield return new WaitForSeconds(0.3f);
            colorIndicatorCurrent.material.SetColor("_Color", transparentColor);
            
            if (counter >= 3)
            {
                colorIndicatorCurrent.material.SetColor("_Color", currentColor);
                continueFlash = false;
                stopFlashCurrentIndicator();
                shrinkIndicator.shrinkCurrentIndicator();

            }
            counter++;
        }

        yield return null;

    }
    /// <summary>
    /// Arrete le clignotement
    /// </summary>
    public void stopFlashCurrentIndicator()
    {
        StopCoroutine(flashIndicator);
    }
    
}