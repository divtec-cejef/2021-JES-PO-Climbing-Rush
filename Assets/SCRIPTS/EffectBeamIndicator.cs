using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBeamIndicator : MonoBehaviour
{

    public ParticleSystem effectBeam;

    private int numberOfTarget = 0;

    
    /// <summary>
    /// Change la couleur de l'effet et l'affiche
    /// </summary>
    /// <param name="colorIndicator">Couleur de l'indicateur courrant</param>
    public void playEffectBeam(Color colorIndicator)
    {
        numberOfTarget++;
        
        // Déplace l'effet à la prise courrante
        effectBeam.transform.position = GameObject.Find("prise " + numberOfTarget).transform.position + new Vector3(0, 0.1f, 0);
        
        // Change la couleur de l'effet pour correspondre à la même couleur que de l'indicateur
        effectBeam.startColor = colorIndicator;
        
        
        // Joue l'effet
        effectBeam.Play();
    }
}
