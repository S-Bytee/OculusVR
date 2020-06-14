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
           
            if(Input.GetButtonDown("Jump") || OVRInput.GetDown(OVRInput.Touch.Two))

            {
            

                if (laserInstance.hit.collider.gameObject.tag == "lineRenderer")
                {
                    if (laserInstance.hit.collider.gameObject.transform.parent)
                    {
                        if (laserInstance.hit.collider.gameObject.transform.parent.tag == "reusableObject")
                        {
                            objectToGrab = laserInstance.hit.collider.gameObject.transform.parent.gameObject;

                            objectToGrab.transform.parent = laserInstance.gameObject.transform;

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        objectToGrab = laserInstance.hit.collider.transform.gameObject;

                        objectToGrab.transform.parent = laserInstance.gameObject.transform;

                    }





                }



                if (laserInstance.hit.collider.gameObject.transform.parent.tag == "object")
                {



                    if (laserInstance.hit.collider.gameObject.transform.parent.parent)
                    {
                        if (laserInstance.hit.collider.gameObject.transform.parent.parent.tag == "reusableObject")
                        {
                            objectToGrab = laserInstance.hit.collider.gameObject.transform.parent.parent.gameObject;

                            objectToGrab.transform.parent = laserInstance.gameObject.transform;

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        objectToGrab = laserInstance.hit.collider.transform.parent.gameObject;

                        objectToGrab.transform.parent = laserInstance.gameObject.transform;

                    }


                }




            }

            if (Input.GetButtonUp("Jump") || OVRInput.GetUp(OVRInput.Touch.Two))
            {

                objectToGrab.transform.parent = null;

            }

        }

    }

}
