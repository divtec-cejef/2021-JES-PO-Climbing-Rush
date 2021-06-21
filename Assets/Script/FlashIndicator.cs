using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashIndicator : MonoBehaviour
{

    private Renderer currenIndicator;
    private Coroutine flashIndicator;
    public MoveIndicator moveIndicator;
    public GameObject rightIndicator;
    public GameObject leftIndicator;
    private bool isRightIndicatorCurrent = true;
    private bool continueFlash = true;

    private GameObject indicatorCurrent;

    private Renderer colorIndicatorCurrent;


    private void Start()
    {
        flashIndicator = StartCoroutine(FlashCurrentIndicator(moveIndicator.getCurrentColorIndicator())); 
    }


    /// <summary>
    /// Appelle la fonction qui fera clignoter les indicateurs
    /// </summary>
    /// <param name="indicatorCurrent"></param>
    public void flashCurrentIndicator(GameObject indicatorCurrent)
    {
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

        continueFlash = true;

        while (continueFlash)
        {
            
            yield return new WaitForSeconds(0.3f);
            colorIndicatorCurrent.material.SetColor("_Color", currentColor);
            
            yield return new WaitForSeconds(0.3f);
            colorIndicatorCurrent.material.SetColor("_Color", Color.white);
        }

        yield return null;

    }
    /// <summary>
    /// Arrete le clignotement
    /// </summary>
    public void stopFlashCurrentIndicator()
    {
        print("STOP LE SHRINK");
        continueFlash = false;
        StopCoroutine(flashIndicator);
    }
    
}