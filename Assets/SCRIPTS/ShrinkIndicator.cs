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
    private bool isRightIndicatorCurrent;
    private Coroutine coroutineShrinkIndicator;
    private Vector3 scaleCircleIndicator;
    private GameObject indicatorCurrent;

    public float valueX = 0;
    public float sizeValueCircle;
    
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
        
        print("l'indicateur courrant : " + indicatorCurrent);

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
        GameObject indicatorNext;

        // Test de qui est l'indicateur prochain
        if (isRightIndicatorCurrent)
        {
            indicatorNext = leftIndicator;
        }
        else
        {
            indicatorNext = rightIndicator;
        }
        
        indicatorNext.gameObject.transform.localScale = new Vector3(.8f, 1.0f, 0.8f);
        // Ici dans les git hub c'est différent, voir ci-dessous :
        /*
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

        print("actuellement dans le stopShrinkIndicator");
        
        if (!isFirstEnterInFunctionStopShrink)
        {
            //StopCoroutine(coroutineShrinkIndicator);

            print("coucou uband");
            
            if (isFirstTimeToPressButton)
            {
                isRightIndicatorCurrent = false;
                isFirstTimeToPressButton = false;
            }
            
    
            if (isRightIndicatorCurrent)
            {
                print("indicateur courrant droit");
                indicatorCurrent = rightIndicator;
                isRightIndicatorCurrent = false;
            }
            else
            {
                print("indicateur courrant gauche");
                indicatorCurrent = leftIndicator;
                isRightIndicatorCurrent = true;
            }

        }
        
        
        
        sizeValueCircle = valueX;
        StopCoroutine(coroutineShrinkIndicator);
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