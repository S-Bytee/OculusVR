﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLineRenderer : MonoBehaviour
{

    PhysicsPointer laserInstance;
    public bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        laserInstance = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {


        OnLaserClick();
        

    }


    void OnLaserClick()
    {
        if (laserInstance.hit.collider)
        {
            if (laserInstance.hit.collider.gameObject == gameObject)
            {
                if (Input.GetMouseButtonDown(0))
                {
                
                    isSelected = true;
                        
                }
            }
        }


        if (laserInstance.hit.collider)
        {
            if (laserInstance.hit.collider.gameObject != gameObject && laserInstance.hit.collider.gameObject.tag != "artisticTools")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    isSelected = false;
                }
            }
        }
        else
        {
            //isSelected = false;
        }
    }


}
