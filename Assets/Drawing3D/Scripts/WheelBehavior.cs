﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelBehavior : MonoBehaviour
{
    public Sprite default_sprite;
    public Sprite select_sprite;

    PhysicsPointer laserPointer;

    
    // Start is called before the first frame update
    void Start()
    {

        laserPointer = PhysicsPointer.Instance;        

    }

    // Update is called once per frame
    void Update()
    {
            print(laserPointer);
            if (laserPointer.hit.collider)
            {
                if (laserPointer.onCollison)
                {
                    //  Debug.Log("onselecteeeeed");

                    if (laserPointer.hit.collider.gameObject == this.gameObject)
                    {


                        GetComponent<Image>().sprite = select_sprite;

                        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) this.gameObject.GetComponent<Button>().onClick.Invoke();

                    }
                    else
                    {
                        GetComponent<Image>().sprite = default_sprite;
                    }
                }
                else
                {

                    GetComponent<Image>().sprite = default_sprite;

                }

            }
        

       


    }
}
