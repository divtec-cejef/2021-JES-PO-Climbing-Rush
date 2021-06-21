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

    public float valueX = 0;
    public float sizeValueCircle;


    private void Start()
    {
        // Rétrécis le premier indicator jusqu'à la limite
        shrinkCurrentIndicator();
        
        print("dans le start du shrinkIndicator");
    }


    /// <summary>
    /// Rétrécis l'indicateur courrant à l'aide de la fonction StartCoroutine (qui permet de
    /// de rétrécir l'indicateur avec fluidité et non que l'indicateur se rétrécit immédiatement) 
    /// </summary>
    public void shrinkCurrentIndicator()
    {
        GameObject indicatorCurrent;

        print("bonjour je suis dans la focntion shrink");

        // Test de qui est l'indicateur courrant     
        if (isRightIndicatorCurrent)
        {
            print("indicateur droit");
            indicatorCurrent = rightIndicator;
            isRightIndicatorCurrent = false;
        }
        else
        {
            print("indicateur gauihce");

            indicatorCurrent = leftIndicator;
            isRightIndicatorCurrent = true;
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
            
            print("ouuais saluuut alros voila mon scale : " + scaleCircleIndicator);

            yield return null;
        }
        
        flashIndicator.flashCurrentIndicator(indicator);

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
    }


    /// <summary>
    /// Mets la valeur à vrai si le bouton à été appuyé
    /// </summary>
    /// <param name="pressed"> valeur vraie si le bouton est pressé sinon faux </param>
    public void stopShrinkIndicator()
    {
        sizeValueCircle = valueX;
        StopCoroutine(coroutineShrinkIndicator);
    }

    public float getValueX()
    {
        return sizeValueCircle;
    }
}