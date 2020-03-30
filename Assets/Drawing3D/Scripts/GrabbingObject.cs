using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingObject : MonoBehaviour
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
           
            if(Input.GetButtonDown("Jump"))
            {
                objectToGrab = laserInstance.hit.collider.transform.parent.gameObject;

                if(objectToGrab.tag=="object")
                {

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
