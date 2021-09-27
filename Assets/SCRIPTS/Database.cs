using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;
public class Database : MonoBehaviour
{
    public TextMeshProUGUI J1;
    public TextMeshProUGUI J2;
    
    public GameObject ApplyColors;

    public GameObject Hat1;
    public GameObject Hat2;

    public void Start()
    {
        string connStr =
            "Database=lacourseauxtrophees;Server=192.168.1.10;Uid=maxime;Password=Admlocal1;pooling=false;CharSet=utf8;port=3306";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            
            MySqlCommand CMD_player1Name = conn.CreateCommand();
            CMD_player1Name.CommandText = "SELECT name_player FROM tb_player WHERE identifiant_player = " + MenuActions.id1 + ";";
            object player1Name = CMD_player1Name.ExecuteScalar();
            
            J1.text = player1Name.ToString();

            MySqlCommand CMD_player2Name = conn.CreateCommand();
            CMD_player2Name.CommandText = "SELECT name_player FROM tb_player WHERE identifiant_player = " + MenuActions.id2 + ";";
            object player2Name = CMD_player2Name.ExecuteScalar();
            
            J2.text = player2Name.ToString();


            MySqlCommand CMD_player1Color = conn.CreateCommand();
            CMD_player1Color.CommandText = "SELECT color_player FROM tb_player WHERE identifiant_player = " + MenuActions.id1 + ";";
            object player1Color = CMD_player1Color.ExecuteScalar();
            string P1Color = player1Color.ToString();

            MySqlCommand CMD_player2Color = conn.CreateCommand();
            CMD_player2Color.CommandText = "SELECT color_player FROM tb_player WHERE identifiant_player = " + MenuActions.id2 + ";";
            object player2Color = CMD_player2Color.ExecuteScalar();
            
            string P2Color = player2Color.ToString();
            
            ApplyColors.GetComponent<ApplyColors>().ApplyPlayerColor(Hat1, Int32.Parse(P1Color), Hat2, Int32.Parse(P2Color));
            
        }
        catch (Exception ex)
        {
            print("c'est pas ouf" + ex);
        }
        conn.Close();
        print("Done.");
    }
}