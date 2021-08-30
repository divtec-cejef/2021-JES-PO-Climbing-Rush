using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PositionOfPlayer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI P1_TextPositionOfPlayer; 
    [SerializeField] private TextMeshProUGUI P2_TextPositionOfPlayer;
    
    [SerializeField] private P1_ProgressiveCircular P1_ProgressiveCircular; 
    [SerializeField] private P2_ProgressiveCircular P2_ProgressiveCircular; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        P1_TextPositionOfPlayer.text = "1er";
        P2_TextPositionOfPlayer.text = "2e";

        P1_TextPositionOfPlayer.color = Color.yellow;
        P2_TextPositionOfPlayer.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {

        if (P1_ProgressiveCircular.getCurrentNumberOfHoldOnIndicator() >
            P2_ProgressiveCircular.getCurrentNumberOfHoldOnIndicator())
        {
            P1_TextPositionOfPlayer.text = "1er";
            P2_TextPositionOfPlayer.text = "2e";

            P1_TextPositionOfPlayer.color = Color.yellow;
            P2_TextPositionOfPlayer.color = Color.white;
        }
        else if (P1_ProgressiveCircular.getCurrentNumberOfHoldOnIndicator() <
                 P2_ProgressiveCircular.getCurrentNumberOfHoldOnIndicator())
        {
            P1_TextPositionOfPlayer.text = "2e";
            P2_TextPositionOfPlayer.text = "1er";

            P1_TextPositionOfPlayer.color = Color.white;
            P2_TextPositionOfPlayer.color = Color.yellow; 
        }
        
    }
}
