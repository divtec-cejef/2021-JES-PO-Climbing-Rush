using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject menuPause;
    public GameObject HUD;

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
        HUD.SetActive(true);
        menuPause.SetActive(false);
        Time.timeScale = 1.0f;
        isGamePaused = false;
    }

    public void PauseGame()
    {
        HUD.SetActive(false);
        menuPause.SetActive(true);
        Time.timeScale = 0.0f;
        isGamePaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}