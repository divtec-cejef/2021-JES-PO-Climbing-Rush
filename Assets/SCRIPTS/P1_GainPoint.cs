using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class P1_GainPoint : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI P1_PositivePointsText;
    [SerializeField] private TextMeshProUGUI P1_NegativePointsText;

    private Coroutine startGainPointCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {

        P1_PositivePointsText.gameObject.SetActive(false);
        P1_NegativePointsText.gameObject.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayGainPoint(int pointAdded, bool positive)
    {

        print("AVANT LE COROUTINE");
        startGainPointCoroutine = StartCoroutine(displayGainPointTimed(pointAdded,positive));

    }

    IEnumerator displayGainPointTimed(int pointAdded, bool positive)
    {

        
        print("DANS LE COROUTINE");
        

        if (!positive)
        {
            P1_NegativePointsText.text = "-" + pointAdded;
            P1_NegativePointsText.gameObject.SetActive(true);
        }
        else
        {
            P1_PositivePointsText.text = "+" + pointAdded;
            P1_PositivePointsText.gameObject.SetActive(true);
        }


        yield return new WaitForSeconds(0.5f);

        P1_NegativePointsText.gameObject.SetActive(false);
        P1_PositivePointsText.gameObject.SetActive(false);
        
        
        //StopCoroutine(startGainPointCoroutine);
        
    }

    public void stopCoroutineGainPointTimed()
    {
        if (startGainPointCoroutine != null)
        {
            StopCoroutine(startGainPointCoroutine);
        }
    }
    
}