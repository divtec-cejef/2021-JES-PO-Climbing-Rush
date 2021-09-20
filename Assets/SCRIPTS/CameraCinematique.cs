using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraCinematique : MonoBehaviour
{
    [SerializeField] private Image IndicatorPlayer1;
    [SerializeField] private Image IndicatorPlayer2;
    [SerializeField] private Camera cameraPlay1;
    [SerializeField] private Camera cameraPlay2;
    [SerializeField] private Camera cameraCinematicPlayer2;
    [SerializeField] private Canvas HUDPlayer1;
    [SerializeField] private Canvas HUDPlayer2;
    [SerializeField] private TextMeshProUGUI positionOfPlayer1;
    [SerializeField] private TextMeshProUGUI positionOfPlayer2;
    
    [SerializeField] private TextMeshProUGUI playername1;
    [SerializeField] private TextMeshProUGUI playername2;
    
    public GameObject P1_generalCountDownTimer;
    public GameObject P2_generalCountDownTimer;
    
    

    public bool isCinematicFinished = false;


    void Start()
    {
        
        P1_generalCountDownTimer.SetActive(false);
        P2_generalCountDownTimer.SetActive(false);

        IndicatorPlayer1.gameObject.SetActive(false);
        IndicatorPlayer2.gameObject.SetActive(false);
        
        cameraPlay1.gameObject.SetActive(false);
        cameraPlay2.gameObject.SetActive(false);
        
        HUDPlayer1.gameObject.SetActive(false);
        HUDPlayer2.gameObject.SetActive(false);
        
        positionOfPlayer1.gameObject.SetActive(false);
        positionOfPlayer2.gameObject.SetActive(false);
        
        playername1.gameObject.SetActive(false);
        playername2.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    public void EndAnim()
    {
        
        
        P1_generalCountDownTimer.SetActive(true);
        P2_generalCountDownTimer.SetActive(true);

        IndicatorPlayer1.gameObject.SetActive(true);
        IndicatorPlayer2.gameObject.SetActive(true);
        
        this.gameObject.SetActive(false);
        cameraCinematicPlayer2.gameObject.SetActive(false);
        
        cameraPlay1.gameObject.SetActive(true);
        cameraPlay2.gameObject.SetActive(true);
        
        
        HUDPlayer1.gameObject.SetActive(true);
        HUDPlayer2.gameObject.SetActive(true);
        
        positionOfPlayer1.gameObject.SetActive(true);
        positionOfPlayer2.gameObject.SetActive(true);
        
        playername1.gameObject.SetActive(true);
        playername2.gameObject.SetActive(true);

        isCinematicFinished = true;

    }

    public bool getIsCinemticFinished()
    {
        return isCinematicFinished;
    }
}
