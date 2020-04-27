using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitProject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("ProjectName") == "")
        {

            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {

            GetComponent<BoxCollider>().enabled = true;

        }



    }
}
