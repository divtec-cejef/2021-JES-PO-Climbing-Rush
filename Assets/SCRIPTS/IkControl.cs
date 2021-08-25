using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Text;
//using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Serialization;

public class IkControl : MonoBehaviour
{
    public ProgressiveCircular progressiveCircular;
    
    private Animator animator;

    private bool isHoldRight = false;
    private bool isHoldLeft = false;
    private bool isFirstHold;

    private bool watchTarget;
    private bool doFallPlayer;

    private float lookWeightForHead;
    private float lookWeightForHoldRight;
    private float lookWeightForHoldLeft;

    private float lookWeightForLeftFeet;
    private float lookWeightForRightFeet;
    public float lookSmoother = 3f;
    public float speed = 2.5f;

    public ScoreScript scoreScript;


    private float lookWeightMaxForHoldRight;
    private float lookWeightMaxForHoldLeft;


    private GameObject currentHoldRight;
    private GameObject currentHoldLeft;

    private int numberOfHoldTraveled;
    private int targetNextOrBack;
    private int numberOfCurrentHold;
    private int numberToFallPlayerTmp = 0;


    private bool canClimb = false;
    private bool isRightHandOnHold = false;
    private bool isLeftHandOnHold = false;
    private bool isSecondHold = false;
    private bool fellPlayer = false;
    private bool isFellPlayerTmp = false;
    private bool neverExceedHold2 = true;
    private bool isNotYetFallen = true;
    private bool climbFirstHoldAfterFall;
    private bool forGetCurrentNumberHold = true;
    private bool fallPlayerInARow = false; // le joueur tombe d'affilé
    private bool fallPlayerOnce = false;
    private bool fallPlayerMoreThanOnce = false;



    private void Start()
    {
        animator = GetComponent<Animator>();

        isFirstHold = true;
        watchTarget = true;
        doFallPlayer = false;


        numberOfHoldTraveled = 0;
    }


    /// <summary>
    /// Animation qui fait monter le personnage aux prises
    /// </summary>
    public void animationClimbingPlayer()
    {
        numberOfHoldTraveled++;

        forGetCurrentNumberHold = true;
        isNotYetFallen = true;
        
        // Pas sur que ça change quelques choses ça
        if (numberOfHoldTraveled == 3)
        {
            neverExceedHold2 = false;
        }
        
        
        if (fellPlayer)
        {

            if (climbFirstHoldAfterFall)
            {
                numberOfHoldTraveled = 1;
                climbFirstHoldAfterFall = false;
            }
            
            else if (numberOfHoldTraveled == 2 && neverExceedHold2)
            {
                numberOfHoldTraveled = 2;
                neverExceedHold2 = false;
            }
            else
            {
                numberOfHoldTraveled--;
            }
            
            fellPlayer = false;
        }
        
        print("numberOfHoldTraveled : " + numberOfHoldTraveled);


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
            lookWeightForHead = Mathf.Lerp(lookWeightForHead, 0f, Time.deltaTime * 1);
            watchTarget = true;
        }
        
        animator.SetLookAtWeight(lookWeightForHead);

        
        targetNextOrBack = 1;
        // Si le jouer doit tomber alors il doit regarder la prise sur laquelle il venait de tomber
        if (doFallPlayer)
        {
            targetNextOrBack = 0;
        }
        
        climbFirstHoldAfterFall = numberOfHoldTraveled + targetNextOrBack == 1;
        
        // Prochaine prise à regarder avec la tête
        animator.SetLookAtPosition(GameObject.Find("prise " + (progressiveCircular.getCurrentNumberOfHoldOnIndicator())).transform.position);


        // La variable lookWeight permet de faire bouger le bras jusqu'à la prise. Exemple :
        // lookWeight = 0, le bras ne vas pas bouger ; lookWeight = 0.5, le bras fera la moitié du chemin entre
        // le personnage et l'objet qu'il doit atteindre ; lookWieght = 1, le bras touche l'objet qui devait atteindre.
        // La valeur de la variable lookWeight change grâce à la fonction Mathf.Lerp(), elle peut se situer entre 0 et 1

        /*----------------------------------------*/
        /*--------------- BRAS DROIT --------------*/
        /*-----------------------------------------*/

        // Vérifie si c'est le bras droit qui doit bouger, ainsi bouge le bras droit
        if (isHoldRight || doFallPlayer && !isHoldLeft)
        {
            print("bras droit");
            isRightHandOnHold = lookWeightForHoldRight >= 0.7f;
            
            lookWeightForHoldRight = Mathf.Lerp(lookWeightForHoldRight, 1f, Time.deltaTime * lookSmoother);
            lookWeightForLeftFeet = Mathf.Lerp(lookWeightForLeftFeet, 1f, Time.deltaTime * lookSmoother);

           
            numberOfCurrentHold = progressiveCircular.getCurrentNumberOfHoldOnIndicator() - 1;

            int numberOfTargetTmp = numberOfCurrentHold;
            print("avant, numberOfTargetTmp : " + numberOfTargetTmp);

            if (doFallPlayer)
            {
                numberOfTargetTmp = numberOfCurrentHold - 1;
                
                // Le joueur est tombé, donc vrai
                fellPlayer = true;

                if (fallPlayerInARow)
                {
                    if (getFellPlayer())
                    {
                        if (getIsHoldRight())
                        {
                            setGoodHandForClimb(true, false);
                        }
                        else
                        {
                            setGoodHandForClimb(false, true);
                        }
                        
                        fallPlayerInARow = false;

                        return;
                    }
                }

                fallPlayerOnce = true;
            }
            else
            {
                fallPlayerOnce = false;
            }
            
            /*
            // Si le joueur doit tomber alors on cherche la prise précédente
            if (doFallPlayer)
            {
                if (fallPlayerOnce)
                {
                    fallPlayerMoreThanOnce = true;
                }
                
                
                
                print("coucou le musulman 1");

                isNotYetFallen = false;
                
                // Le joueur est tombé, donc vrai
                fellPlayer = true;
                
                if (numberOfTargetTmp == 1)
                {
                    numberOfTargetTmp = 1;
                }
                else
                {
                    numberOfTargetTmp -= 1;
                    if (isHoldRight)
                    {
                        if (numberOfCurrentHold != 2)
                        {
                            numberOfTargetTmp -= 1;
                        }
                    }
                }

                /*
                if (forGetCurrentNumberHold)
                {
                    //numberOfCurrentHold -= numberOfTargetTmp;
                    // affecter la valeur ci dessus a une variable temporaire qu'ensuite affectera a numberOfCurrentHold
                    numberToFallPlayerTmp += numberOfTargetTmp;
                    
                    print("raccordon");

                    
                    forGetCurrentNumberHold = false;
                }
                */
            /*
                numberToFallPlayerTmp += numberOfTargetTmp;
                
                
                fallPlayerOnce = true;
            }
            else
            {
                fallPlayerOnce = false;
                fallPlayerMoreThanOnce = false;
            }

            */


            print("après, numberOfTargetTmp : " + numberOfTargetTmp);
            
            
          

            
            
            // Cherche l'objet qui est la prise courrante ou qui doit être la précédente
            currentHoldRight = GameObject.Find("prise " + numberOfTargetTmp);
            print("c'est la prise droite : " + currentHoldRight);

            if (numberOfTargetTmp == 1)
            {
                lookWeightForLeftFeet = 0;
            }


            
            
            float axeXPlayer = .9f;
            float axeYPlayer = 1.81f;


           
            if (doFallPlayer)
            {
                axeYPlayer = 1;
            }
            
            if (numberOfTargetTmp < 2)
            {
                if (numberOfTargetTmp == 0)
                {
                    currentHoldRight = GameObject.Find("prise 1");
                    //lookWeightForHoldLeft = 0;
                    //lookWeightMaxForHoldLeft = 0;
                    lookWeightForLeftFeet = 0;

                }
                numberOfTargetTmp = progressiveCircular.getCurrentNumberOfHoldOnIndicator();
            }
            
            
            // Info : dépendant de quel côté est la première prise, par ex. gauche, ce code devra être dans la partie du bras gauche
            if (numberOfTargetTmp == 1 && doFallPlayer)
            {
                // Ne change pas la postion y du joueur quand il doit tomber de la première prise
                //axeYPlayer = currentHoldRight.transform.position.y - transform.position.y;
                axeYPlayer = 0.83f;
                axeXPlayer = .9f;
                //lookWeightForHoldRight = 0;
                lookWeightMaxForHoldRight = Mathf.Lerp(lookWeightMaxForHoldRight, 0f, Time.deltaTime * lookSmoother);
            }
            
            
            
            // Fais monter ou descendre le joueur
            transform.position = Vector3.Lerp(transform.position,
                currentHoldRight.transform.position - new Vector3(axeXPlayer, axeYPlayer, .6f),
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
            print("prends la prise avec la main droite");
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
        if (isHoldLeft || doFallPlayer && !isHoldRight)
        {
            print("bras gauche");

            isLeftHandOnHold = lookWeightForHoldLeft >= 0.7f;

            lookWeightForHoldLeft = Mathf.Lerp(lookWeightForHoldLeft, 1f, Time.deltaTime * lookSmoother);
            lookWeightForRightFeet = Mathf.Lerp(lookWeightForRightFeet, 1f, Time.deltaTime * lookSmoother);
            
           
            numberOfCurrentHold = progressiveCircular.getCurrentNumberOfHoldOnIndicator() - 1;

            
            int numberOfTargetTmp = numberOfCurrentHold;
            
            
            print("avant, numberOfTargetTmp 11: " + numberOfTargetTmp);

            if (doFallPlayer)
            {
                
                numberOfTargetTmp = numberOfCurrentHold - 1;
                
                
                // Le joueur est tombé, donc vrai
                fellPlayer = true;

                if (fallPlayerInARow)
                {
                    if (getFellPlayer())
                    {
                        print("+ donc là il est tombé");
                        if (getIsHoldRight())
                        {
                            print("+ apparement c'est la main droite du coup on met true a gauche et faux droite");
                            setGoodHandForClimb(true, false);
                        }
                        else
                        {
                            print("+ apparement c'est la main gauche du coup on met false a gauche et true a droite");
                            setGoodHandForClimb(false, true);
                        }

                        fallPlayerInARow = false;
                        
                        return;
                    }
                }
                
                fallPlayerOnce = true;
            }
            else
            {
                fallPlayerOnce = false;
            }
            
            /*
            // Si le joueur doit tomber alors on cherche la prise précédente
            if (doFallPlayer)
            {
                print("coucou le musulman 2");
                isNotYetFallen = false;

                if (fallPlayerOnce)
                {
                    fallPlayerMoreThanOnce = true;
                }
                
                // Le joueur est tombé, donc vrai
                fellPlayer = true;
                
                if (numberOfTargetTmp == 1)
                {
                    numberOfTargetTmp = 1;
                }
                else
                {
                    numberOfTargetTmp -= 1;
                    if (isHoldLeft)
                    {
                        if (numberOfCurrentHold != 2)
                        {
                            numberOfTargetTmp -= 1;
                        }
                    }
                }
                
                /*
                if  (forGetCurrentNumberHold)
                {
                    //numberOfCurrentHold -= numberOfTargetTmp;

                    print("raccordon");
                    numberToFallPlayerTmp += numberOfTargetTmp;
                    
                    forGetCurrentNumberHold = false;
                }
                */
            /*
                numberToFallPlayerTmp += numberOfTargetTmp;


                fallPlayerOnce = true;
            }
            else
            {
                fallPlayerOnce = false;
                fallPlayerMoreThanOnce = false;
            }
            
            */
            print("après, numberOfTargetTmp : " + numberOfTargetTmp);


            
            
            // Cherche l'objet qui est la prise courrante ou qui doit être la précédente
            currentHoldLeft = GameObject.Find("prise " + numberOfTargetTmp);
            print("c'est la prise de gauche : " + currentHoldLeft);
            
            float axeYPlayer = 1.81f;
            float axeXPlayer = -0.9f;
            
            if (doFallPlayer)
            {
                axeYPlayer = 1;
            }

            
            // Les tests ci-dessous c'est quand le joueur descend vers les premières prises
            if (numberOfTargetTmp < 2)
            {
                if (numberOfTargetTmp == 0)
                {
                    currentHoldLeft = GameObject.Find("prise 2");
                    lookWeightForHoldLeft = 0;
                    lookWeightMaxForHoldLeft = 0;
                    lookWeightForRightFeet = 0;

                }
                numberOfTargetTmp = progressiveCircular.getCurrentNumberOfHoldOnIndicator() - 1;
            }
            
            print("after, numberOfTargetTmp et doFallPlayer : " + numberOfTargetTmp + " et " + doFallPlayer);

            
            // Le joueur doit tomber de la deuxième prise seulement en axe Y
            if (numberOfTargetTmp == 1 && doFallPlayer)
            {
                print("after, inoxtag");
                // Il faudra surement changer la valeur ici dans la nouvelle map -------------------- /!\
                //axeYPlayer = currentHoldRight.transform.position.y - transform.position.y;
                axeYPlayer = 2.83f;
            }
            
            /*
            // Info : dépenant de quel côté est la deuxième prise, par ex. droite, ce code devra être dans la partie du bras droit
            if (numberOfTargetTmp == 2 && doFallPlayer)
            {
                axeXPlayer = 1f;
                //axeYPlayer = 1.82f;
                axeYPlayer = 3f;
                lookWeightForHoldLeft = 0;
                lookWeightMaxForHoldLeft = 0;
                lookWeightForRightFeet = 0;
            }
            */
            

            // Bouge le corps du personnage vers la prise et monte ou descend
            transform.position = Vector3.Lerp(transform.position,
                currentHoldLeft.transform.position - new Vector3(axeXPlayer, axeYPlayer, .6f),
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
            print("prends la prise avec la main gauche");
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
        
        
        if (isFirstHold || numberOfHoldTraveled == 1 || (numberOfHoldTraveled == 2 && isRightHandOnHold) || (isSecondHold && isRightHandOnHold)  || (isRightHandOnHold && isLeftHandOnHold))
        {
            if (scoreScript.getIsGoodButton())
            {
                isSecondHold = isFirstHold;
            }

            canClimb = true;
        }


        return canClimb;
    }


    
    /// <summary>
    /// Modifie si le joueur doit tomber ou non
    /// </summary>
    /// <param name="fall">Booléen qui dit si le joueur doit tomber ou non</param>
    public void setDoFallPlayer(bool fall)
    {
        doFallPlayer = fall;
    }


    /// <summary>
    /// Change à vrai si le joueur est tombé sinon faux
    /// </summary>
    /// <param name="fell">Si le joueur est tombé ou non</param>
    public void setFellPlayer(bool fell)
    {
        fellPlayer = fell;
    }

    
    /// <summary>
    /// Change à vrai si le joueur est tombé
    /// </summary>
    /// <param name="fell">Si le joueur est déjà tombé ou non</param>
    public void setNotYetFallen(bool fell)
    {
        isNotYetFallen = fell;
    }



    /// <summary>
    /// Modifie à vrai si on a besoin de savoir sur quel numéro de prise se trouve le joueur
    /// </summary>
    /// <param name="needCurrentNumberHold">Vrai si on a besoin de savoir sinon faux</param>
    public void setForGetCurrentNumberHold(bool needCurrentNumberHold)
    {
        forGetCurrentNumberHold = needCurrentNumberHold;
    }
    

    

    /// <summary>
    /// Permet de savoir quelle manin doit monter quand on est tombé
    /// </summary>
    /// <param name="isHoldLeft">Si c'est la main gauche qui doit montée</param>
    /// <param name="isHoldRight">Si c'est la main droite qui doit montée</param>
    public void setGoodHandForClimb(bool isHoldLeft, bool isHoldRight)
    {
        this.isHoldLeft = isHoldLeft;
        this.isHoldRight = isHoldRight;
    }



    /// <summary>
    /// Modifie à vrai si le joueur tombe plusieurs fois d'affilé (minimum 2x)
    /// </summary>
    /// <param name="fallInARow">Vrai si le joueur est tombé plusieurs fois d'affilé</param>
    public void setFallPlayerInARow(bool fallInARow)
    {
        fallPlayerInARow = fallInARow;
    }
    
    
    
    
    
    
    /// <summary>
    /// </summary>
    /// <returns>Retourne le numéro de la prise prochaine</returns>
    public int getNumberOfHoldCurrent()
    {
        return numberOfHoldTraveled;
    }


    /// <summary>
    /// </summary>
    /// <returns> Retourne si c'est la main droit ou non qui doit grimper</returns>
    public bool getIsHoldRight()
    {
        return isHoldRight;
    }


    /// <summary>
    /// </summary>
    /// <returns>Retourne vrai si le joueur est déjà tombé une fois</returns>
    public bool getFallPlayerOne()
    {
        return fallPlayerOnce;
    }



    /// <summary>
    /// Change à vrai si c'est la première prise sinon faux
    /// </summary>
    /// <param name="isFirst">Vrai si c'est la première prise</param>
    public void setIsFirstHold(bool isFirst)
    {
        isFirstHold = isFirst;
    }
    
    
    /// <summary>
    /// </summary>
    /// <returns>Retourne vrai si le joueur est tombé sinon faux</returns>
    public bool getFellPlayer()
    {
        return fellPlayer;
    }
}