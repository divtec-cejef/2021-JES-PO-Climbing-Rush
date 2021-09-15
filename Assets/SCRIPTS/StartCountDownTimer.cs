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
    
    public TextMeshProUGUI countDownTimeDisplay;

    private bool canStartGeneralCountDownTimer = false;
    
    private void Start()
    {
        StartCoroutine(CountdownTimer());
    }

   
    IEnumerator CountdownTimer()
    {
        IntroAnim.startGame = true;
        StartCoroutine(countDownTimeDisplay.gameObject.GetComponent<IntroAnim>().PulseEffect());
        countDownTimeDisplay.text = "10";
        yield return new WaitForSeconds(1f);
        countDownTimeDisplay.text = "9";
        yield return new WaitForSeconds(1f);
        countDownTimeDisplay.text = "8";
        yield return new WaitForSeconds(1f);
        countDownTimeDisplay.text = "7";
        yield return new WaitForSeconds(1f);
        countDownTimeDisplay.text = "6";
        yield return new WaitForSeconds(1f);
        countDownTimeDisplay.text = "5";
        yield return new WaitForSeconds(1f);
        countDownTimeDisplay.text = "4";
        yield return new WaitForSeconds(1f);
        countDownTimeDisplay.text = "3";
        yield return new WaitForSeconds(1f);
        countDownTimeDisplay.text = "2";
        yield return new WaitForSeconds(1f);
        countDownTimeDisplay.text = "1";
        yield return new WaitForSeconds(1f);
        countDownTimeDisplay.text = "GO ! ";
        yield return new WaitForSeconds(.5f);
        canStartGeneralCountDownTimer = true;
        countDownTimerIsFinished = true;
        countDownTimeDisplay.gameObject.SetActive(false);
        IntroAnim.startGame = false;
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
    
