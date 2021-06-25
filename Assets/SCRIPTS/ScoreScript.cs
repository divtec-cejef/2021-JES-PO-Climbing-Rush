using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Constantes pour les points
    private const int POINT_LOSS = 10; // Petite perte de points
    private const int POINT_LOSS_WRONG_BUTTON = 75; // Grande perte de points
    private const int MAX_POINT = 500; // Grand gain de points
    private const int MEDIUM_POINT = 150; // Gain moyen de points
    private const int MIN_POINT = 10; // Petit gain de points

    // Constantes pour la taille du cercle
    private const float MAX_SIZE = 0.8f; // Taille maximal
    private const float MEDIUM_SIZE = 0.65f; // Taille moyenne
    private const float MIN_SIZE = 0.5f; // Taille minimal

    public ShrinkIndicator shrinkIndicator;
    public FlashIndicator flashIndicator;
    public TextMeshProUGUI score;

    public bool isGoodButton;
    public static int scoreValue = 0;

    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score : " + scoreValue; // Affiche le score au début du jeu (égal à 0)
    }


    /// <summary>
    /// Calculer le nombre de points que le joueur gagnera et affiche le score
    /// </summary>
    public void calculatePoints()
    {
        setCounter(shrinkIndicator.getSizeValueCircle());

        // Si le bon bouton est appuyé
        if (isGoodButton)
        {
            if (getCounter() == 0)
            {
                setCounter(MAX_SIZE);
            }

            if (getCounter() <= MIN_SIZE)
            {
                scoreValue += MIN_POINT;
            }
            else if (getCounter() <= MEDIUM_SIZE)
            {
                scoreValue += MEDIUM_POINT;
            }
            else
            {
                scoreValue += MAX_POINT;
            }
        }

        score.text = "Score : " + scoreValue; // Affichage du nouveau score
    }

    /// <summary>
    /// Recupere la valeur du booleen (si le bon bouton est pressé)
    /// </summary>
    /// <returns></returns>
    public bool getIsGoodButton()
    {
        return isGoodButton;
    }

    /// <summary>
    /// Modifie la valeur du boolean
    /// </summary>
    /// <param name="isGoodButton"></param>
    public void setIsGoodButton(bool isGoodButton)
    {
        this.isGoodButton = isGoodButton;
    }

    /// <summary>
    /// Recupere la valeur du compteur
    /// </summary>
    /// <returns></returns>
    public float getCounter()
    {
        return counter;
    }


    /// <summary>
    /// Modifie la valeur du compteur
    /// </summary>
    /// <param name="counter"></param>
    public void setCounter(float counter)
    {
        this.counter = counter;
    }

    /// <summary>
    /// Grande perte de points sans aller dans le niggatif
    /// </summary>
    public void setWrongButton()
    {
        if (scoreValue <= POINT_LOSS_WRONG_BUTTON)
        {
            scoreValue = 0;
        }
        else
        {
            scoreValue -= POINT_LOSS_WRONG_BUTTON;
        }

        score.text = "Score : " + scoreValue;
    }

    /// <summary>
    /// Petite perte de points sans aller dans le négatif
    /// </summary>
    public void losePoint()
    {
        if (scoreValue <= POINT_LOSS)
        {
            scoreValue = 0;
        }
        else
        {
            scoreValue -= POINT_LOSS;
        }

        score.text = "Score : " + scoreValue;
    }
}