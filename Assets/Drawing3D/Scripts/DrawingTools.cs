using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingTools : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DisableAll()
    {
        for(int i = 0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    } 
       

    public void ShowScaling()
    {
        DisableAll();
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ShowRotating()
    {
        DisableAll();
        transform.GetChild(1).gameObject.SetActive(true);
    }


}
