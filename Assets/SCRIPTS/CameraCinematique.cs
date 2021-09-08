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
        
        playername1.gameObject.SetActive(false);
        playername2.gameObject.SetActive(false);
    
        
                
        string connStr = "Database=lacourseauxtrophees;Server=192.168.1.10;Uid=maxime;Password=Admlocal1;pooling=false;CharSet=utf8;port=3306";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            MySqlCommand Player1 = conn.CreateCommand();
            Player1.CommandText = "SELECT name_player FROM tb_player WHERE current_game_player = 2 AND number_player = 1";
            object Player1Name = Player1.ExecuteScalar();
                
            MySqlCommand Player2 = conn.CreateCommand();
            Player2.CommandText = "SELECT name_player FROM tb_player WHERE current_game_player = 2 AND number_player = 1";
            object Player2Name = Player2.ExecuteScalar();

            playername1.text = Player1Name.ToString();
            playername2.text = Player2Name.ToString();
        }
        catch (Exception ex)
        {
            print("Ca marche po - " + ex);
        }
        conn.Close();
        print("Done.");
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
        
        playername1.gameObject.SetActive(true);
        playername2.gameObject.SetActive(true);
        
    }
}
