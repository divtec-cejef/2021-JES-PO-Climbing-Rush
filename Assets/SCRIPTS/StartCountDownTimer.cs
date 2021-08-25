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