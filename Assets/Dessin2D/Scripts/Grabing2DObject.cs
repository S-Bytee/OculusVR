﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabing2DObject : MonoBehaviour
{

    PhysicsPointer laserInstance;
    GameObject objectToGrab;
    // Start is called before the first frame update
    void Start()
    {
        laserInstance = PhysicsPointer.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        grabObject();
    }


    public void grabObject()
    {

        if (laserInstance.hit.collider)
        {

            if (Input.GetButtonDown("Jump"))
            {

                Debug.Log(laserInstance.hit.collider.gameObject);

                if (laserInstance.hit.collider.gameObject.transform.parent.tag == "object")
                {


                    objectToGrab = laserInstance.hit.collider.transform.parent.gameObject;

                    objectToGrab.transform.parent = laserInstance.gameObject.transform;

                }
               


            }

            if (Input.GetButtonUp("Jump"))
            {

                objectToGrab.transform.parent = null;

            }


        }




    }
}