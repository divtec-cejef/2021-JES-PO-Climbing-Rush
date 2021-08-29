using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWinner : MonoBehaviour
{

    [SerializeField] private GeneralCoutnDownTimer P1_GeneralCountDownTimer;
    [SerializeField] private GeneralCoutnDownTimer P2_GeneralCountDownTimer;
    [SerializeField] private P1_ScoreScript P1_ScoreScript;
    [SerializeField] private P2_ScoreScript P2_ScoreScript;
    
    [SerializeField] private TextMeshProUGUI P1_textWinnerOrLooser;
    [SerializeField] private TextMeshProUGUI P2_textWinnerOrLooser;

    private bool isPlayerWin = false;


    private void Start()
    {
        P1_textWinnerOrLooser.gameObject.SetActive(false);
        P2_textWinnerOrLooser.gameObject.SetActive(false);
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
        

    }
    
    
    /// <summary>
    /// Joueur 1 gagne, affichage du gagnant sur l'écran
    /// </summary>
    private void displayPlayer1Winner()
    {
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
        P2_textWinnerOrLooser.gameObject.SetActive(true);
        P2_textWinnerOrLooser.color = Color.yellow;
        P2_textWinnerOrLooser.text = "GAGNANT";
        
        P1_textWinnerOrLooser.gameObject.SetActive(true);
        P1_textWinnerOrLooser.color = Color.red;
        P1_textWinnerOrLooser.text = "PERDANT";
    }
}
