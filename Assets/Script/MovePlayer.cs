using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.RedButton.performed += ctx => CorrectCircle('R');
        controls.Gameplay.BlueButton.performed += ctx => CorrectCircle('B');
        controls.Gameplay.GreenButton.performed += ctx => CorrectCircle('G');
        controls.Gameplay.YellowButton.performed += ctx => CorrectCircle('Y');
        controls.Gameplay.PurpleButton.performed += ctx => CorrectCircle('P');
    }

    // Affiche la couleur du bouton qui est appuyé
    void CorrectCircle(char colorButton)
    {
        {
            print("bouton " + colorButton);
        }
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
