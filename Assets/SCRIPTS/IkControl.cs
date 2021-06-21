using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;

public class IkControl : MonoBehaviour
{
    
    private Animator animator;

    private bool isHoldRight = false;
    private bool isHoldLeft = false;
    private bool isFirstHold;

    private bool watchTarget;

    private float lookWeightForHead;
    private float lookWeightForHoldRight;
    private float lookWeightForHoldLeft;
    public float lookSmoother = 3f;
    public float speed = 1f;


    private float lookWeightMaxForHoldRight;
    private float lookWeightMaxForHoldLeft;

    

    private GameObject currentHoldRight;
    private GameObject currentHoldLeft;

    private int numberOfTarget;

    private void Start()
    {
        animator = GetComponent<Animator>();

        isFirstHold = true;
        watchTarget = true;

        numberOfTarget = 0;
    }


    /// <summary>
    /// Animation qui fait monter le personnage aux prises
    /// </summary>
    public void animationClimbingPlayer()
    {
        numberOfTarget++;
        
        watchTarget = false;
        

        if (isFirstHold)
        {
            print("isFirstHold");

            isHoldRight = true;
            isFirstHold = false;
        }
        else if (isHoldRight)
        {
            print("Prise droite");

            isHoldLeft = true;
            isHoldRight = false;
        }
        else
        {
            print("Prise gauche");

            isHoldRight = true;
            isHoldLeft = false;
        }
    }
    

    /// <summary>
    /// Fonction qui fait les animations
    /// </summary>
    /// <param name="layerIndex"></param>
    private void OnAnimatorIK(int layerIndex)
    {
        
        // Animations pour que la tête regarde la prochaine prise à prendre
        if (watchTarget)
        {
            lookWeightForHead = Mathf.Lerp(lookWeightForHead, 1f, Time.deltaTime * lookSmoother);
        }
        else
        {
            lookWeightForHead = Mathf.Lerp(lookWeightForHead, 0f, Time.deltaTime * lookSmoother * 1.5f);
            watchTarget = true;
        }


        animator.SetLookAtWeight(lookWeightForHead);
        
        // Prochaine prise à regarder avec la tête
        animator.SetLookAtPosition(GameObject.Find("prise " + (numberOfTarget + 1)).transform.position);
    


        // La variable lookWeight permet de faire bouger le bras jusqu'à la prise. Exemple :
        // lookWeight = 0, le bras ne vas pas bouger ; lookWeight = 0.5, le bras fera la moitié du chemin entre
        // le personnage et l'objet qu'il doit atteindre ; lookWieght = 1, le bras touche l'objet qui devait atteindre.
        // La valeur de la variable lookWeight change grâce à la fonction Mathf.Lerp(), elle peut se situer entre 0 et 1

        /*-----------------------------------------*/
        /*--------------- BRAS DROIT --------------*/
        /*-----------------------------------------*/

        // Vérifie si c'est le bras droit qui doit bouger, ainsi bouge le bras droit
        if (isHoldRight)
        {
            lookWeightForHoldRight = Mathf.Lerp(lookWeightForHoldRight, 1f, Time.deltaTime * lookSmoother);

            print("c'est la prise numero : " + numberOfTarget);

            // Cherche l'objet qui est la prise courrante
            currentHoldRight = GameObject.Find("prise " + numberOfTarget);

            transform.position = Vector3.Lerp(transform.position, currentHoldRight.transform.position - new Vector3(.9f, 1.81f, .6f),
               speed * Time.deltaTime);
        }
        else
        {
            lookWeightForHoldRight = 0;
        }

        // Récupère la valeur maximale de lookWeight à chaque fois pour que le bras ne descende pas 
        if (lookWeightForHoldRight > lookWeightMaxForHoldRight)
        {
            lookWeightMaxForHoldRight = lookWeightForHoldRight;
        }


        // Bouge le bras droit (animation)
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, lookWeightMaxForHoldRight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, lookWeightMaxForHoldRight);
        animator.SetIKPosition(AvatarIKGoal.RightHand, currentHoldRight.transform.position - new Vector3(0, 0, .3f));
        animator.SetIKRotation(AvatarIKGoal.RightHand, currentHoldRight.transform.rotation);


        /*-----------------------------------------*/
        /*-------------- BRAS GAUCHE --------------*/
        /*-----------------------------------------*/

        // Vérifie si c'est le bras gauche qui doit bouger
        if (isHoldLeft)
        {
            lookWeightForHoldLeft = Mathf.Lerp(lookWeightForHoldLeft, 1f, Time.deltaTime * lookSmoother);
            
            print("c'est la prise numero : " + numberOfTarget);
            
            // Cherche l'objet qui est la prise courrante
            currentHoldLeft = GameObject.Find("prise " + numberOfTarget);
            
            // Bouge le corps du personnage vers la prise et monte
            transform.position = Vector3.Lerp(transform.position, currentHoldLeft.transform.position - new Vector3(-0.9f, 1.81f, .6f),
                speed * Time.deltaTime);
        }
        else
        {
            lookWeightForHoldLeft = 0;
        }


        // Récupère la valeur maximale de lookWeight à chaque fois pour que le bras ne descende pas 
        if (lookWeightForHoldLeft > lookWeightMaxForHoldLeft)
        {
            lookWeightMaxForHoldLeft = lookWeightForHoldLeft;
        }

        // Bouge le bras gauche (animation)
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, lookWeightMaxForHoldLeft);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, lookWeightMaxForHoldLeft);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, currentHoldLeft.transform.position - new Vector3(0, 0, .3f));
        animator.SetIKRotation(AvatarIKGoal.LeftHand, currentHoldLeft.transform.rotation);
    }
}