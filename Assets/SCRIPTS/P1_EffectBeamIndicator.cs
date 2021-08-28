using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_EffectBeamIndicator : MonoBehaviour
{

    public ParticleSystem effectBeam;

    private int numberOfTarget = 0;


    private void Start()
    {
        effectBeam.gameObject.SetActive(false);
    }

    /// <summary>
    /// Change la couleur de l'effet et l'affiche
    /// </summary>
    /// <param name="colorIndicator">Couleur de l'indicateur courrant</param>
    public void playEffectBeam(Color colorIndicator)
    {
        effectBeam.gameObject.SetActive(true);

        
        numberOfTarget++;
        
        
        // Déplace l'effet à la prise courrante
        effectBeam.transform.position = GameObject.Find("P1_prise " + numberOfTarget).transform.position + new Vector3(0, 0.1f, 0);
        
        // Change la couleur de l'effet pour correspondre à la même couleur que de l'indicateur
        effectBeam.startColor = colorIndicator;
        
        
        // Joue l'effet
        effectBeam.Play();
    }


    /// <summary>
    /// Change à vrai si le joueur tombe sinon faux
    /// </summary>
    /// <param name="fell">Si le joueur est tombé ou non</param>
    public void substractOneTarget()
    {
        numberOfTarget--;
    }
}
