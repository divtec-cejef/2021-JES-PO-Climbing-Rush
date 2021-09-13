using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject LoadingMenu;
    
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SfxSlider;
    [SerializeField] private Slider LoadingSlider;
    
    [SerializeField] private TextMeshProUGUI LoadingText;

    private bool settings = false;
    
    public static string Player1Name;
    public static string Player2Name;

    public static int musicVolume;
    public static int sfxVolume;

    public void StartGame()
    {
        StartCoroutine(LoadGame());
    }

    public void Name1(string name)
    {
        Player1Name = name;
    }
    public void Name2(string name)
    {
        Player2Name = name;
    }
    
    private IEnumerator LoadGame()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        MainMenu.SetActive(false);
        LoadingMenu.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingSlider.value = progress;
            LoadingText.text = (int)(progress * 100f) + "%";
            
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        if (settings)
        {
            MainMenu.SetActive(true);
            SettingsMenu.SetActive(false);
            settings = false;
        }
        else
        {
            MainMenu.SetActive(false);
            SettingsMenu.SetActive(true);
            settings = true;

            MusicSlider.value = musicVolume;
            SfxSlider.value = sfxVolume;
        }
    }
    
    public void ChangeMusicVolume()
    {
        musicVolume = (int)MusicSlider.value;
    }

    public void ChangeSFXVolume()
    {
        sfxVolume = (int)SfxSlider.value;
    }
}
