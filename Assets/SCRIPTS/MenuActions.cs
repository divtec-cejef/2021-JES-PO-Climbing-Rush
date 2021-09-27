using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
//using Camera;
using LayerLab;
using MySql.Data.MySqlClient;
//using Players;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
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
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private TextMeshProUGUI LoadingText;

    
    private bool settings = false;
    private bool inscription = false;

    private int player1Color = 2;
    private int player2Color = 1;

    public static int id1;
    public static int id2;

    public static int musicVolume;
    public static int sfxVolume;

    private List<Button> player1Buttons;
    private List<Button> player2Buttons;

    
    private void Awake()
    {
        id1 = Int32.MinValue;
        id2 = Int32.MinValue;
        player1Color = 1;
        player1Color = 2;
    }
    

    public void StartGame()
    {
        if (GetData())
            StartCoroutine(LoadGame());
        else
            errorPanel.SetActive(true);
    }

    private IEnumerator LoadGame()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        MainMenu.SetActive(false);
        errorPanel.SetActive(false);

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

    public void Retour()
    {
        errorPanel.SetActive(false);
    }

    public void LaunchAnyway()
    {
        StartCoroutine(LoadGame());
    }
    
    public void Inscription()
    {
        if (inscription)
        {
            MainMenu.SetActive(true);
            inscription = false;
        }
        else
        {
            MainMenu.SetActive(false);
            inscription = true;
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


    public void SetName1(string s)
    {
        try
        {
            id1 = Int32.Parse(s);
        }
        catch (Exception e)
        {
            id1 = Int32.MinValue;
        }
        
    }

    public void SetName2(string s)
    {

        try
        {
            id2 = Int32.Parse(s);
        }
        catch (Exception e)
        {
            id2 = Int32.MinValue;
        }

    }
    
    public bool GetData()
    {
    
        string connStr =
            "Database=lacourseauxtrophees;Server=192.168.1.10;Uid=maxime;Password=Admlocal1;pooling=false;CharSet=utf8;port=3306";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {
            if (id1.Equals(Int32.MaxValue) || id2.Equals(Int32.MaxValue))
            {
                throw CheckoutException.Canceled;
            }

            conn.Open();
            MySqlCommand Player1 = conn.CreateCommand();
            Player1.CommandText = "SELECT name_player FROM tb_player WHERE identifiant_player = " + id1 + ";";
            object name1 = Player1.ExecuteScalar();

            Debug.LogError(name1.ToString());

            /*/////////////////////////////////////////////////*/

            MySqlCommand Player2 = conn.CreateCommand();
            Player2.CommandText = "SELECT name_player FROM tb_player WHERE identifiant_player = " + id2 + ";";
            object name2 = Player2.ExecuteScalar();

            Debug.LogError(name2.ToString());


            /*/////////////////////////////////////////////////*/

            MySqlCommand Color1 = conn.CreateCommand();
            Color1.CommandText = "SELECT color_player FROM tb_player WHERE identifiant_player = " + id1 + ";";
            object color1 = Color1.ExecuteScalar();

            Debug.LogError(Int32.Parse(color1.ToString()));

            /*/////////////////////////////////////////////////*/

            MySqlCommand Color2 = conn.CreateCommand();
            Color2.CommandText = "SELECT color_player FROM tb_player WHERE identifiant_player = " + id2 + ";";
            object color2 = Color2.ExecuteScalar();

            Debug.LogError(Int32.Parse(color2.ToString()));

        }
        catch (Exception ex)
        {
            print("Id Incorrecte - " + ex);
            return false;
        }
        finally
        {
            conn.Close();
            print("Done.");
        }

        return true;
    }
}
