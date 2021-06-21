using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class CountdownTimer : MonoBehaviour 
{ 
    [SerializeField] private float timeValue = 90; 
    public Text timeText; 
 
    private void Update() 
    { 
        // permet de ne pas avoir de valeurs negatives
        if (timeValue > 0) 
        { 
            timeValue -= Time.deltaTime; 
        } 
        else 
        { 
            timeValue = 0; 
        } 
         // affiche le temps
        displayTime(timeValue); 
    } 
 
    /// <summary>
    /// Fonction qui affichera le temps au format "MM:SS"
    /// </summary>
    /// <param name="timeToDisplay"></param> temps qu'il faudra afficher
    void displayTime(float timeToDisplay) 
    { 
        if (timeToDisplay < 0) 
        { 
            timeToDisplay = 0; 
        } 
 
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float secondes = Mathf.FloorToInt(timeToDisplay % 60); 
 
        timeText.text = string.Format("{0:00}:{1:00}", minutes, secondes); 
    }
}