using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPopUpText : MonoBehaviour
{

    public GameObject blockedImage;
    
    // Start is called before the first frame update
    void Start()
    {
        blockedImage.SetActive(false);
    }

    public void setBlocked(bool blocked)
    {
        blockedImage.SetActive(blocked);
    }
}
