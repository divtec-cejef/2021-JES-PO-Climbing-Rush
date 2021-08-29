using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MenuPause : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject P1_menuPause;
    public GameObject P2_menuPause;
    public GameObject P1_HUD;
    public GameObject P2_HUD;
    public GameObject P1_generalCountDownTimer;
    public GameObject P2_generalCountDownTimer;
    public GameObject P1_startCountDownTimer;
    public GameObject P2_startCountDownTimer;


    private void Start()
    {
        P1_menuPause.SetActive(false);
        P2_menuPause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void ResumeGame()
    {
        P1_startCountDownTimer.SetActive(true);
        P2_startCountDownTimer.SetActive(true);
        
        P1_generalCountDownTimer.SetActive(true);
        P2_generalCountDownTimer.SetActive(true);
        
        P1_HUD.SetActive(true);
        P2_HUD.SetActive(true);
        
        P1_menuPause.SetActive(false);
        P2_menuPause.SetActive(false);
        
        Time.timeScale = 1.0f;
        isGamePaused = false;
    }

    public void PauseGame()
    {
        P1_startCountDownTimer.SetActive(false);
        P2_startCountDownTimer.SetActive(false);
        
        P1_generalCountDownTimer.SetActive(false);
        P2_generalCountDownTimer.SetActive(false);
        
        P1_HUD.SetActive(false);
        P2_HUD.SetActive(false);
        
        P1_menuPause.SetActive(true);
        P2_menuPause.SetActive(true);
        
        Time.timeScale = 0.0f;
        isGamePaused = true;
    }

    public void QuitGame()
    {
        
        SceneManager.LoadSceneAsync(0);
        
        //Application.Quit();
    }
}
