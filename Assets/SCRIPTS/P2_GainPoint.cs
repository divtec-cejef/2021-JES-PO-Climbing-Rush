using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class P2_GainPoint : MonoBehaviour
{

    public TextMeshProUGUI gainPointText;
    
    [SerializeField] private TextMeshProUGUI P2_PositivePointsText;
    [SerializeField] private TextMeshProUGUI P2_NegativePointsText;

    private Coroutine startGainPointCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        P2_PositivePointsText.gameObject.SetActive(false);
        P2_NegativePointsText.gameObject.SetActive(false);
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
        //Color color = Color.yellow;
        Color color;

        if (!positive)
        {
            P2_NegativePointsText.text = "-" + pointAdded;
            P2_NegativePointsText.gameObject.SetActive(true);
        }
        else
        {
            P2_PositivePointsText.text = "+" + pointAdded;
            P2_PositivePointsText.gameObject.SetActive(true);
        }
        
        
        
        yield return new WaitForSeconds(0.5f);

        P2_NegativePointsText.gameObject.SetActive(false);
        P2_PositivePointsText.gameObject.SetActive(false);
        
        
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