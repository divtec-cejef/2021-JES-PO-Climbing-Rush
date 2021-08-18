using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCountDownTimer : MonoBehaviour
{
    // Start is called before the first frame update

    private float currentTime = 0f;
    private float startingTime = 3f;

    public TextMeshProUGUI countDownTimer;

    void Start()
    {

        currentTime = startingTime;


    }

    // Update is called once per frame
    void Update()
    {

        
        
        
            currentTime -= 1 * Time.deltaTime;
            
            if (currentTime <= 0 && currentTime >= -1)
            {
                countDownTimer.text = "GO !";
                
            }
            
            countDownTimer.text = currentTime.ToString("0");

            
        

       
        
        
       
        

    }
}
