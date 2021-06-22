using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShrinkIndicator : MonoBehaviour
{
    private const float MIN_DIAMETER_INDICATOR = 0.5f;

    public GameObject rightIndicator;
    public GameObject leftIndicator;
    
    public FlashIndicator flashIndicator; 
    private bool isRightIndicatorCurrent = true;
    private Coroutine coroutineShrinkIndicator;
    private Vector3 scaleCircleIndicator;
    private GameObject indicatorCurrent;
    private GameObject indicatorNext;


    public float valueX = 0;
    public float sizeValueCircle;


    public bool isFirstEnterInFunctionStopShrink = true;
    private bool isFirstTimeToPressButton = true;

    
    private void Start()
    {
        
        coroutineShrinkIndicator = StartCoroutine(ScaleToTargetCoroutine(indicatorCurrent));
        stopShrinkIndicator();
        
    }


    /// <summary>
    /// Rétrécis l'indicateur courrant à l'aide de la fonction StartCoroutine (qui permet de
    /// de rétrécir l'indicateur avec fluidité et non que l'indicateur se rétrécit immédiatement) 
    /// </summary>
    public void ShrinkCurrentIndicator()
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
            indicator.gameObject.transform.localScale -= new Vector3(0.005f, 0.0f, 0.005f);
            valueX = indicator.gameObject.transform.localScale.x;

            scaleCircleIndicator = indicator.gameObject.transform.localScale;
            
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
        if (isRightIndicatorCurrent)
        {
            indicatorNext = leftIndicator;
        }
        else
        {
            indicatorNext = rightIndicator;
        }
        leftIndicator.gameObject.transform.localScale = new Vector3(.8f, 1.0f, 0.8f);
        rightIndicator.gameObject.transform.localScale = new Vector3(.8f, 1.0f, 0.8f);

    }


    /// <summary>
    /// Strop le rétrécissement de l'indicateur et met à jour quel indicateur doit être rétréci
    /// </summary>
    public void stopShrinkIndicator()
    {
        if (!isFirstEnterInFunctionStopShrink)
        {
            StopCoroutine(coroutineShrinkIndicator);
            
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
    }
    

    public float getValueX()
    {
        return sizeValueCircle;
    }


    public void setIsFirstEnterInFunctionStopShrink(bool isEnter)
    {
        isFirstTimeToPressButton = isEnter;
    }
    
}