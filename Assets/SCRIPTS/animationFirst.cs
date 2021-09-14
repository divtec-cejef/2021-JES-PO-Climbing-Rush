using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationFirst : MonoBehaviour
{
    public float Strength;
    

    IEnumerator PulseEffect()
    {
        // Loops forever
        while (true)
        {
            float timer = 0f;
            // Zoom in
            while (timer < 1f)
            {
                yield return new WaitForEndOfFrame();
                timer += Time.deltaTime;
                transform.localScale = new Vector3
                (
                    transform.localScale.x + (Time.deltaTime * Strength * 2),
                    transform.localScale.y + (Time.deltaTime * Strength * 2)
                );
            }
            timer = 0f;
            //yield return new WaitForSeconds(Speed);
            while (timer < 1f)
            {
                yield return new WaitForEndOfFrame();
                timer += Time.deltaTime;
                transform.localScale = new Vector3
                (
                    transform.localScale.x - (Time.deltaTime * Strength * 2),
                    transform.localScale.y - (Time.deltaTime * Strength * 2)
                );
            }
            //yield return new WaitForSeconds(Speed);
            yield return null;
        }
    }

    private void OnEnable()
    {
        transform.localScale = new Vector3(1f, 1f);
        StartCoroutine(PulseEffect());
    }

}
