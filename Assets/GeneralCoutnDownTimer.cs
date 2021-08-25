using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneralCoutnDownTimer : MonoBehaviour
{
    public TextMeshProUGUI GeneralCountDownTimer;
    // Start is called before the first frame update


    private float countDownTime; // 1 minute 30 secondes
    private bool countDownTimerIsFinished = false;

    private Coroutine startGeneralCountDownTimer;
    public TextMeshProUGUI countDownTimeDisplay;
    public StartCountDownTimer startCountDownTimer;


    public Text textTemps;
    public TextMeshProUGUI TempsNum;
    public GameObject FinText;
    public float timeValue = 90;

    private void Start()
    {
        //textTemps.text = textTempsAfficher;
        countDownTimeDisplay.text = string.Format("{0:00}:{1:00}", 1, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountDownTimer.getCanStartGeneralCountDownTimer())
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
                FinText.SetActive(true);
            }

            DisplayTime(timeValue);
        }

        void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float secondes = Mathf.FloorToInt(timeToDisplay % 60);
            countDownTimeDisplay.text = string.Format("{0:00}:{1:00}", minutes, secondes);
        }
    }
}


/*
void Start()
{
    
}

public void Update()
{
    if (startCountDownTimer.getCanStartGeneralCountDownTimer())
    {
        countDownTime += Time.deltaTime;
    }
}

void OnGUI()
{
    float minutes = Mathf.Floor(countDownTime / 60);
    float seconds = countDownTime%60;

    GUI.Label(new Rect(10,10,250,100), minutes + ":" + Mathf.RoundToInt(seconds));    }

public void startCoroutineStartGeneralCountDownTimer()
{
    startGeneralCountDownTimer = StartCoroutine(GeneralCountDownToStart());
}

// Décompte de 3 secondes
IEnumerator GeneralCountDownToStart()
{
    while (countDownTime > 0)
    {
        GeneralCountDownTimer.text = countDownTime.ToString();

        yield return new WaitForSeconds(1f);

        countDownTime--;
    }


    countDownTimerIsFinished = true;
    print("cest fini gars");
                                                          
    yield return new WaitForSeconds(1f);                  
                                                           
    
                                                                                                                                                               
                                                                                                                                                                                                                      
    countDownTimeDisplay.gameObject.SetActive(false);     
                                                          
    StopCoroutine(startGeneralCountDownTimer);                   
}                                                         



/// <summary>
/// </summary>
/// <returns>Retourne vrai si le compteur de départ est fini sinon faux</returns>
public bool getcountDownTimerIsFinished()
{
    return countDownTimerIsFinished;
}
*/
