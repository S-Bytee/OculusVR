using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabing2DObject : MonoBehaviour
{

    PhysicsPointer laserInstance;
    GameObject objectToGrab;
    public Color c = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        laserInstance = PhysicsPointer.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        grabObject();
        if(ColorIndicator.Instance)
        c = ColorIndicator.Instance.color.ToColor();


    }


    public void grabObject()
    {

        if (laserInstance.hit.collider)
        {

            if (Input.GetButtonDown("Jump") || OVRInput.GetDown(OVRInput.Button.One))
            {

                //Debug.Log(laserInstance.hit.collider.gameObject);

                if (laserInstance.hit.collider.gameObject.transform.parent.tag == "object")
                {


                    objectToGrab = laserInstance.hit.collider.transform.parent.gameObject;

                    objectToGrab.transform.parent = laserInstance.gameObject.transform;
                    objectToGrab.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
                    





                }

               

            }
            if (Input.GetMouseButtonDown(1) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {

                Destroy(objectToGrab);

            }

            if (Input.GetButtonUp("Jump") || OVRInput.GetDown(OVRInput.Button.One))
            {

                objectToGrab.transform.parent = null;

            }
            


        }




    }
}
