using System.Collections;
using System.Collections.Generic;
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
    
    void Start()
    {
        IndicatorPlayer1.gameObject.SetActive(false);
        IndicatorPlayer2.gameObject.SetActive(false);
        
        cameraPlay1.gameObject.SetActive(false);
        cameraPlay2.gameObject.SetActive(false);
        
        HUDPlayer1.gameObject.SetActive(false);
        HUDPlayer2.gameObject.SetActive(false);
        
        positionOfPlayer1.gameObject.SetActive(false);
        positionOfPlayer2.gameObject.SetActive(false);
    
    }

    // Update is called once per frame
    public void EndAnim()
    {
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
        
    }
}
