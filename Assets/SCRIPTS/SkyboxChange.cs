using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Material skyboxmaterial;

    [Range(0.00f,1.00f)]
    
    public float yourBlend = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Day --> Night
        if (yourBlend <= 1f)
        {
            yourBlend += 0.01f * Time.deltaTime;
            skyboxmaterial.SetFloat("_Blend", yourBlend);
        }
        // Night --> Day
        if (yourBlend >= 1f)
        {
            yourBlend -= 0.01f * Time.deltaTime;
            skyboxmaterial.SetFloat("_Blend", yourBlend);
        }
    }
}
