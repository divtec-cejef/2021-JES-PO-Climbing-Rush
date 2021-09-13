using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.InputSystem.iOS;

public class StartCountDownTimer : MonoBehaviour
{
    // Start is called before the first frame update

    
    private int countDownTime = 3;
    private bool countDownTimerIsFinished = false;
    private Coroutine startCountDownTimer;
    
    public GeneralCoutnDownTimer generalCoutnDownTimer;
    public TextMeshProUGUI countDownTimeDisplay;

    private bool canStartGeneralCountDownTimer = false;

    // Toujours mettre +1 au nombre de base (ex.: décompte qui commence à 3 alors timeValue = 4
    public float timeValue = 4;


    private void Start()
    {
        countDownTimeDisplay.text = timeValue.ToString();
    }

    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            countDownTimeDisplay.gameObject.SetActive(false);    
        }

        if (timeValue > 0)
        {
            DisplayTime(timeValue);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 1 && timeToDisplay > 0)
        {
            countDownTimeDisplay.text = "GO !";
            canStartGeneralCountDownTimer = true;
            countDownTimerIsFinished = true;
        }
        else
        {
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            countDownTimeDisplay.text = seconds.ToString();
        }

        
    }
    


    /*
    void Start()
    {
        startCountDownTimer = StartCoroutine(CountDownToStart());
    }

    // Décompte de 3 secondes
    IEnumerator CountDownToStart()
    {
        while (countDownTime > 0)
        {
            countDownTimeDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        canStartGeneralCountDownTimer = true;

        countDownTimeDisplay.text = "GO !";

        countDownTimerIsFinished = true;
        print("cest fini gars");
                                                              
        yield return new WaitForSeconds(1f);

        countDownTimeDisplay.gameObject.SetActive(false);     
                                                              
        StopCoroutine(startCountDownTimer);                   
    }                                                         

    */

    /// <summary>
    /// </summary>
    /// <returns>Retourne vrai si le compteur de départ est fini sinon faux</returns>
    public bool getcountDownTimerIsFinished()
    {
        return countDownTimerIsFinished;
    }

    public bool getCanStartGeneralCountDownTimer()
    {
        return canStartGeneralCountDownTimer;
    }

    public void setCanStartGeneralCountDownTimer(bool canStart)
    {
        canStartGeneralCountDownTimer = canStart;
    }
    
}
    
