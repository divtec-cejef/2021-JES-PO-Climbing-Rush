using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerWinner : MonoBehaviour
{
    [SerializeField] private GeneralCoutnDownTimer P1_GeneralCountDownTimer;
    [SerializeField] private GeneralCoutnDownTimer P2_GeneralCountDownTimer;
    [SerializeField] private P1_ScoreScript P1_ScoreScript;
    [SerializeField] private P2_ScoreScript P2_ScoreScript;

    [SerializeField] private TextMeshProUGUI P1_textWinnerOrLooser;
    [SerializeField] private TextMeshProUGUI P2_textWinnerOrLooser;
    [SerializeField] private TextMeshProUGUI P1Screen_winnerScoreBoard;
    [SerializeField] private TextMeshProUGUI P1Screen_looserScoreBoard;
    [SerializeField] private TextMeshProUGUI P2Screen_winnerScoreBoard;
    [SerializeField] private TextMeshProUGUI P2Screen_looserScoreBoard;
    [SerializeField] private TextMeshProUGUI P1Screen_nameWinner;
    [SerializeField] private TextMeshProUGUI P1Screen_nameLooser;
    [SerializeField] private TextMeshProUGUI P2Screen_nameWinner;
    [SerializeField] private TextMeshProUGUI P2Screen_nameLooser;
    
    [SerializeField] private TextMeshProUGUI P1Name;
    [SerializeField] private TextMeshProUGUI P2Name;


    [SerializeField] private Canvas canvasClassementP1;
    [SerializeField] private Canvas canvasClassementP2;

    private bool isP1_winnerLooserDisplayed = false;
    private bool isP2_winnerLooserDisplayed = false;
    private bool isTimeExpired = false;


    private bool isPlayerWin = false;


    private void Start()
    {
        P1_textWinnerOrLooser.gameObject.SetActive(false);
        P2_textWinnerOrLooser.gameObject.SetActive(false);

        canvasClassementP1.gameObject.SetActive(false);
        canvasClassementP2.gameObject.SetActive(false);
    }


    /// <summary>
    /// Affiche sur l'écran du premier et deuxième joueur Temps écoulé
    /// </summary>
    public void timeExpired()
    {
        isTimeExpired = true;

        P1_textWinnerOrLooser.gameObject.SetActive(true);
        P2_textWinnerOrLooser.gameObject.SetActive(true);


        P1_textWinnerOrLooser.text = "Temps écoulé";
        P2_textWinnerOrLooser.text = "Temps écoulé";

        displayScoreBoard();
    }


    public void player1Winner()
    {
        if (!isPlayerWin)
        {
            isPlayerWin = true;
            P1_GeneralCountDownTimer.stopGeneralCountDownTimer();
            P2_GeneralCountDownTimer.stopGeneralCountDownTimer();

            displayPlayer1Winner();

            P1_ScoreScript.addRemainingPointsOfTimer(P1_GeneralCountDownTimer.getTimeValueRemaining());
        }

        displayScoreBoard();
    }

    public void player2Winner()
    {
        if (!isPlayerWin)
        {
            isPlayerWin = true;
            P1_GeneralCountDownTimer.stopGeneralCountDownTimer();
            P2_GeneralCountDownTimer.stopGeneralCountDownTimer();

            displayPlayer2Winner();

            P2_ScoreScript.addRemainingPointsOfTimer(P2_GeneralCountDownTimer.getTimeValueRemaining());
        }

        displayScoreBoard();
    }


    /// <summary>
    /// Joueur 1 gagne, affichage du gagnant sur l'écran
    /// </summary>
    private void displayPlayer1Winner()
    {
        isP2_winnerLooserDisplayed = true;

        P1_textWinnerOrLooser.gameObject.SetActive(true);
        P1_textWinnerOrLooser.color = Color.yellow;
        P1_textWinnerOrLooser.text = "GAGNANT";

        P2_textWinnerOrLooser.gameObject.SetActive(true);
        P2_textWinnerOrLooser.color = Color.red;
        P2_textWinnerOrLooser.text = "PERDANT";
    }


    /// <summary>
    /// Joueur 2 gagne, affichage du gagnant sur l'écran
    /// </summary>
    private void displayPlayer2Winner()
    {
        isP2_winnerLooserDisplayed = true;

        P2_textWinnerOrLooser.gameObject.SetActive(true);
        P2_textWinnerOrLooser.color = Color.yellow;
        P2_textWinnerOrLooser.text = "GAGNANT";

        P1_textWinnerOrLooser.gameObject.SetActive(true);
        P1_textWinnerOrLooser.color = Color.red;
        P1_textWinnerOrLooser.text = "PERDANT";
    }


    /// <summary>
    /// Affiche les points des joueurs sur le scoreBoard
    /// </summary>
    private void displayScoreBoard()
    {
        canvasClassementP1.gameObject.SetActive(true);
        canvasClassementP2.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string connStr =
                "Database=lacourseauxtrophees;Server=192.168.1.10;Uid=maxime;Password=Admlocal1;pooling=false;CharSet=utf8;port=3306";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
            
                MySqlCommand CMD_addScore = conn.CreateCommand();
                CMD_addScore.CommandText = "UPDATE tb_player SET score_kr_player = " + P1_ScoreScript.getScoreValue() + " WHERE identifiant_player  = " + MenuActions.Player1Name + ";";
                CMD_addScore.ExecuteScalar();
                MySqlCommand CMD_addScore2 = conn.CreateCommand();
                CMD_addScore2.CommandText = "UPDATE tb_player SET score_kr_player = " + P2_ScoreScript.getScoreValue() + " WHERE identifiant_player  = " + MenuActions.Player2Name + ";";
                CMD_addScore2.ExecuteScalar();
            }
            catch (Exception ex)
            {
                print("Ca marche po - " + ex);
            }

            conn.Close();
            print("Done.");

            SceneManager.LoadScene(0);
        }


        if (P1_ScoreScript.getScoreValue() > P2_ScoreScript.getScoreValue())
        {
            P1Screen_winnerScoreBoard.text = P1_ScoreScript.getScoreValue().ToString();
            P1Screen_looserScoreBoard.text = P2_ScoreScript.getScoreValue().ToString();

            P2Screen_winnerScoreBoard.text = P1_ScoreScript.getScoreValue().ToString();
            P2Screen_looserScoreBoard.text = P2_ScoreScript.getScoreValue().ToString();
            
            P1Screen_nameWinner.text = P1Name.text;
            P1Screen_nameLooser.text = P2Name.text;
            P2Screen_nameWinner.text = P1Name.text;
            P2Screen_nameLooser.text = P2Name.text;
        }


        else
        {
            P1Screen_winnerScoreBoard.text = P2_ScoreScript.getScoreValue().ToString();
            P1Screen_looserScoreBoard.text = P1_ScoreScript.getScoreValue().ToString();

            P2Screen_winnerScoreBoard.text = P2_ScoreScript.getScoreValue().ToString();
            P2Screen_looserScoreBoard.text = P1_ScoreScript.getScoreValue().ToString();
            
            P1Screen_nameWinner.text = P2Name.text;
            P1Screen_nameLooser.text = P1Name.text;
            P2Screen_nameWinner.text = P2Name.text;
            P2Screen_nameLooser.text = P1Name.text;
            
        }
    }


    public bool getIsWinnerLooserDisplayed()
    {
        if (isP1_winnerLooserDisplayed || isP2_winnerLooserDisplayed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool getIsTimerExpired()
    {
        return isTimeExpired;
    }
}