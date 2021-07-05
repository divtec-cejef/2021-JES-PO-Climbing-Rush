using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro.EditorUtilities;
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

    private float lookWeightForLeftFeet;
    private float lookWeightForRightFeet;
    public float lookSmoother = 3f;
    public float speed = 1f;

    public ScoreScript scoreScript;


    private float lookWeightMaxForHoldRight;
    private float lookWeightMaxForHoldLeft;


    private GameObject currentHoldRight;
    private GameObject currentHoldLeft;

    private int numberOfTarget;


    private bool canClimb = false;
    private bool isRightHandOnHold = false;
    private bool isLeftHandOnHold = false;
    private bool isSecondHold = false;

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

        /*----------------------------------------*/
        /*--------------- BRAS DROIT --------------*/
        /*-----------------------------------------*/

        // Vérifie si c'est le bras droit qui doit bouger, ainsi bouge le bras droit
        if (isHoldRight)
        {
            isRightHandOnHold = lookWeightForHoldRight >= 0.99f;
            print("quand lookWeightForHoldRight est à 1 alors isRightHandOnHold doit être égale a *true*,  : " +
                  lookWeightForHoldRight);
            print("valeur de isRightHandOnHold : " + isRightHandOnHold);


            lookWeightForHoldRight = Mathf.Lerp(lookWeightForHoldRight, 1f, Time.deltaTime * lookSmoother);
            lookWeightForLeftFeet = Mathf.Lerp(lookWeightForLeftFeet, 1f, Time.deltaTime * lookSmoother);

            // Cherche l'objet qui est la prise courrante
            currentHoldRight = GameObject.Find("prise " + numberOfTarget);

            print("c'est la prise : " + currentHoldRight);

            transform.position = Vector3.Lerp(transform.position,
                currentHoldRight.transform.position - new Vector3(.9f, 1.81f, .6f),
                speed * Time.deltaTime);
        }
        else
        {
            lookWeightForHoldRight = 0;
            lookWeightForLeftFeet = 0;
        }

        // Récupère la valeur maximale de lookWeight à chaque fois pour que le bras ne descende pas 
        if (lookWeightForHoldRight > lookWeightMaxForHoldRight)
        {
            lookWeightMaxForHoldRight = lookWeightForHoldRight;
        }


        try
        {
            // Bouge le bras droit (animation)
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, lookWeightMaxForHoldRight);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, lookWeightMaxForHoldRight);
            animator.SetIKPosition(AvatarIKGoal.RightHand,
                currentHoldRight.transform.position - new Vector3(0, 0, .3f));
            animator.SetIKRotation(AvatarIKGoal.RightHand, currentHoldRight.transform.rotation);
        }
        catch (Exception e)
        {
        }


        /*-----------------------------------------*/
        /*--------------- PIED DROIT --------------*/
        /*-----------------------------------------*/
        try
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, lookWeightForRightFeet);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, lookWeightForRightFeet);

            animator.SetIKPosition(AvatarIKGoal.RightFoot,
                currentHoldRight.transform.position - new Vector3(0.5f, 1.5f, -0.5f));
            animator.SetIKRotation(AvatarIKGoal.RightFoot, currentHoldRight.transform.rotation);
        }
        catch (Exception e)
        {
        }


        /*-----------------------------------------*/
        /*-------------- BRAS GAUCHE --------------*/
        /*-----------------------------------------*/

        // Vérifie si c'est le bras gauche qui doit bouger
        if (isHoldLeft)
        {
            isLeftHandOnHold = lookWeightForHoldLeft >= 0.99f;

            lookWeightForHoldLeft = Mathf.Lerp(lookWeightForHoldLeft, 1f, Time.deltaTime * lookSmoother);
            lookWeightForRightFeet = Mathf.Lerp(lookWeightForRightFeet, 1f, Time.deltaTime * lookSmoother);

            // Cherche l'objet qui est la prise courrante
            currentHoldLeft = GameObject.Find("prise " + numberOfTarget);

            // Bouge le corps du personnage vers la prise et monte
            transform.position = Vector3.Lerp(transform.position,
                currentHoldLeft.transform.position - new Vector3(-0.9f, 1.81f, .6f),
                speed * Time.deltaTime);
        }
        else
        {
            lookWeightForHoldLeft = 0;
            lookWeightForRightFeet = 0;
        }


        // Récupère la valeur maximale de lookWeight à chaque fois pour que le bras ne descende pas 
        if (lookWeightForHoldLeft > lookWeightMaxForHoldLeft)
        {
            lookWeightMaxForHoldLeft = lookWeightForHoldLeft;
        }


        // Bouge le bras gauche (animation)
        try
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, lookWeightMaxForHoldLeft);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, lookWeightMaxForHoldLeft);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, currentHoldLeft.transform.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, currentHoldLeft.transform.rotation);
        }
        catch (Exception e)
        {
        }


        /*-----------------------------------------*/
        /*-------------- PIED GAUCHE --------------*/
        /*-----------------------------------------*/
        try
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, lookWeightForLeftFeet);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, lookWeightForLeftFeet);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot,
                currentHoldLeft.transform.position - new Vector3(0.5f, 1.5f, -0.5f));
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, currentHoldLeft.transform.rotation);
        }
        catch (Exception e)
        {
        }
    }


    /// <summary>
    /// Retourne si oui ou non le joueur peut attraper la prochaine prise
    /// </summary>
    /// <returns></returns>
    public bool getCanClimb()
    {
        canClimb = false;


        if (isFirstHold || (isSecondHold && isRightHandOnHold) || (isRightHandOnHold && isLeftHandOnHold))
        {
            if (scoreScript.getIsGoodButton())
            {
                print("oui c'est le bon bouton");
                isSecondHold = isFirstHold;
            }

            canClimb = true;
        }


        return canClimb;
    }
}