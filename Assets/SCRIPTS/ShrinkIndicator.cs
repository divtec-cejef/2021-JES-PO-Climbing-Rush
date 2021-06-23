using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;


public class ShrinkIndicator : MonoBehaviour
{
    private const float MIN_DIAMETER_INDICATOR = 0.5f;

    public GameObject rightIndicator;
    public GameObject leftIndicator;
    
    public FlashIndicator flashIndicator;
    private bool isRightIndicatorCurrent;
    private Coroutine coroutineShrinkIndicator;
    private Vector3 scaleCircleIndicator;
    private GameObject indicatorCurrent;
    public ScoreScript scoreScript;

    private float valueX;
    private float sizeValueCircle;
    
    private bool isFirstEnterInFunctionStopShrink;
    private bool isFirstTimeToPressButton;


    private void Start()
    {
        isRightIndicatorCurrent = true;
        // Rétrécis le premier indicator jusqu'à la limite
        coroutineShrinkIndicator = StartCoroutine(ScaleToTargetCoroutine(indicatorCurrent));
        stopShrinkIndicator();
        
        isFirstEnterInFunctionStopShrink = true;
        isFirstTimeToPressButton = true;
    }


    /// <summary>
    /// Rétrécis l'indicateur courrant à l'aide de la fonction StartCoroutine (qui permet de
    /// de rétrécir l'indicateur avec fluidité et non que l'indicateur se rétrécit immédiatement) 
    /// </summary>
    public void shrinkCurrentIndicator()
    {
        
        if (isFirstEnterInFunctionStopShrink)
        {
            indicatorCurrent = rightIndicator;
            isRightIndicatorCurrent = false;
        }

        scaleCircleIndicator = indicatorCurrent.gameObject.transform.localScale;
        
        // Démarre la fonction rétrécit l'indicateur courrant
        coroutineShrinkIndicator = StartCoroutine(ScaleToTargetCoroutine(indicatorCurrent));
    }


    /// <summary>
    /// Rétrécis l'indicateur courrant
    /// </summary>
    /// <param name="indicator"> L'indicateur à rétrécir </param>
    /// <returns> null </returns>
    private IEnumerator ScaleToTargetCoroutine(GameObject indicator)
    {
        
        while (scaleCircleIndicator.x > MIN_DIAMETER_INDICATOR)
        {

            yield return new WaitForSeconds(0.001f);
            
            indicator.gameObject.transform.localScale -= new Vector3(0.005f, 0.0f, 0.005f);
            
            scaleCircleIndicator = indicator.gameObject.transform.localScale;

            valueX = scaleCircleIndicator.x;

            yield return null;
        }


        yield return null;
    }


    /// <summary>
    /// Remets à l'échelle de base l'indicateur
    /// </summary>
    /// <param name="indicator">  L'indicateur à remettre à l'échelle de base </param>
    public void setDefaultSizeIndicator()
    {
        GameObject indicatorNext;

        // Test de qui est l'indicateur prochain ainsi pour remettre à échelle l'indicateur
        if (isRightIndicatorCurrent)
        {
            indicatorNext = rightIndicator;
        }
        else
        {
            indicatorNext = leftIndicator;
        }
        
        indicatorNext.gameObject.transform.localScale = new Vector3(.8f, 1.0f, 0.8f);
        // Ici dans les git hub c'est différent, voir ci-dessous :
        /*b 
         leftIndicator.gameObject.transform.localScale = new Vector3(.8f, 1.0f, 0.8f);
         rightIndicator.gameObject.transform.localScale = new Vector3(.8f, 1.0f, 0.8f);
         */
    }


    /// <summary>
    /// Mets la valeur à vrai si le bouton à été appuyé
    /// </summary>
    /// <param name="pressed"> valeur vraie si le bouton est pressé sinon faux </param>
    public void stopShrinkIndicator()
    {

        if (!isFirstEnterInFunctionStopShrink)
        {
            //StopCoroutine(coroutineShrinkIndicator);
            
            if (isFirstTimeToPressButton)
            {
                isRightIndicatorCurrent = false;
                isFirstTimeToPressButton = false;
            }


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

        }
        
        
        sizeValueCircle = valueX;
        StopCoroutine(coroutineShrinkIndicator);
    }


    public float getSizeValueCircle()
    {
        return sizeValueCircle;
    }
    
    public void setIsFirstEnterInFunctionStopShrink(bool isEnter)
    {
        //isFirstTimeToPressButton = isEnter;
        isFirstEnterInFunctionStopShrink = isEnter;
    }
}