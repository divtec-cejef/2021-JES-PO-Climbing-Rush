using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GainPoint : MonoBehaviour
{

    public TextMeshProUGUI gainPointText;

    private Coroutine startGainPointCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        
        string sign = "";
        Color color = Color.yellow;

        if (!positive)
        {
            sign = "-";
            color = Color.red;
        }
        else
        {
            sign = "+";
            color = Color.yellow;
        }
        
        gainPointText.text = "" + sign + pointAdded;
        gainPointText.color = color;
        
        gainPointText.enabled = true;

        
        yield return new WaitForSeconds(1.5f);

        gainPointText.enabled = false;
        
        
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
