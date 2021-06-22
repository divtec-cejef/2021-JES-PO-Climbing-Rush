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
    public ShrinkIndicator shrinkIndicator;

    private GameObject indicatorCurrent;
    private int counter;
    private Renderer colorIndicatorCurrent;


    void Start()
    {
        flashCurrentIndicator();
    }

    /// <summary>
    /// Appelle la fonction qui fera clignoter les indicateurs
    /// </summary>
    /// <param name="indicatorCurrent"></param>
    public void flashCurrentIndicator()
    {
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
    public IEnumerator FlashCurrentIndicator(Color currentColor)
    {

        counter = 0;
        continueFlash = true;

        while (continueFlash)
        {
            
            yield return new WaitForSeconds(0.2f);
            colorIndicatorCurrent.material.SetColor("_Color", Color.white);
            
            yield return new WaitForSeconds(0.3f);
            colorIndicatorCurrent.material.SetColor("_Color", currentColor);

            if (counter >= 3)
            {
                continueFlash = false;
                StopFlashCurrentIndicator();
                shrinkIndicator.ShrinkCurrentIndicator();

            }
            counter++;
        }
        
        yield return null;

    }
    
    
    /// <summary>
    /// Arrete le clignotement
    /// </summary>
    public void StopFlashCurrentIndicator()
    {
        StopCoroutine(flashIndicator);
    }
    
}