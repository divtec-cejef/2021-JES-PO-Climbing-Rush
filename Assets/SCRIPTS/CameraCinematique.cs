using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraCinematique : MonoBehaviour
{
    [SerializeField] private Image IndicatorPlayer1;
    [SerializeField] private Image IndicatorPlayer2;
    [SerializeField] private 
    
    
    void Start()
    {
        IndicatorPlayer1.gameObject.SetActive(false);
        IndicatorPlayer2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void EndAnim()
    {
        IndicatorPlayer1.gameObject.SetActive(true);
        IndicatorPlayer2.gameObject.SetActive(true);
    }
}
