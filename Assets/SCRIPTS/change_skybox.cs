using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_skybox : MonoBehaviour
{
    // Start is called before the first frame update
    public Material skyboxJour;
    public Material skyboxNuit;
    public float tempsCycle;
    private float tempsEcoule;

    
    void Start()
    {
        RenderSettings.skybox = skyboxJour;
        tempsEcoule = tempsCycle;
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

        if (tempsEcoule > 0)
        {
            tempsEcoule -= Time.deltaTime;
        }
        else
        {
            tempsEcoule = tempsCycle;
            if (RenderSettings.skybox == skyboxJour)
            {                                       
                RenderSettings.skybox = skyboxNuit; 
            }                                       
            else                                    
            {                                       
                RenderSettings.skybox = skyboxJour; 
            }                                       
        }
        
        /*
        if (tempsEcoule >= tempsCycle)
        {
            tempsEcoule = 0f;
            if (RenderSettings.skybox == skyboxJour)
            {
                RenderSettings.skybox = skyboxNuit;
            }
            else
            {
                RenderSettings.skybox = skyboxJour;
            }
        }
         */
        
        print("TEMPS ECOULE : "+tempsEcoule);
        print("CYCLE : "+tempsCycle);
    }
}