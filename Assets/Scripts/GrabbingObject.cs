using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingObject : MonoBehaviour
{

    PhysicsPointer laserInstance;
   
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

                laserInstance.hit.collider.gameObject.transform.parent = laserInstance.gameObject.transform;
                
            }

            if (Input.GetButtonUp("Jump"))
            {
                laserInstance.hit.collider.gameObject.transform.parent = null;

            }


        }




    }

}
