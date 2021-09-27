using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabInputIdPlayer : MonoBehaviour
{
    [SerializeField] private TMP_InputField idPlayer1;
    [SerializeField] private TMP_InputField idPlayer2;
    public int inputIdSelected = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputIdSelected++;
            if (inputIdSelected > 1)
            {
                inputIdSelected = 0;
            }    
            
            selectInputField();
        }

        void selectInputField()
        {
            switch (inputIdSelected)
            {
                case 0: idPlayer1.Select();
                    break;
                case 1: idPlayer2.Select();
                    break;
            }
        }
    }
    
    public void idPlayer1Selected() => inputIdSelected = 0;
    public void idPlayer2Selected() => inputIdSelected = 1;
}


