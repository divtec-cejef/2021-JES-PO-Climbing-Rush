using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_skybox : MonoBehaviour
{
    // Start is called before the first frame update
    public Material skyboxJour;
    public Material skyboxNuit;
    void Start()
    {
        RenderSettings.skybox = skyboxJour;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (RenderSettings.skybox == skyboxJour)
            {
                RenderSettings.skybox = skyboxNuit;
            }
            else
            {
                RenderSettings.skybox = skyboxJour;
            }
        }
    }
}
