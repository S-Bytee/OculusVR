using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingSettings : MonoBehaviour
{
    // Start is called before the first frame update

    int x = 0;
    GameObject artisticTools;
    void Start()
    {

       artisticTools = GameObject.Find("WheelCanvas");
        //artisticTools.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) || OVRInput.GetDown(OVRInput.Button.One))
        {
            x++;
        }

        if(x%2==0)
        {
         artisticTools.SetActive(false);
        }
        else
        {
           artisticTools.SetActive(true);
        }
        
    }
}
