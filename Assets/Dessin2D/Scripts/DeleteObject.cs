using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    PhysicsPointer laserPointer;
    // Start is called before the first frame update
    void Start()
    {
        laserPointer = PhysicsPointer.Instance;
    }

    // Update is called once per frame
    void Update()
    {

        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject.transform.childCount > 0)
            {
                Debug.Log(laserPointer.hit.collider.transform.parent.tag);

                if (laserPointer.hit.collider.transform.parent.tag == "object")
                {
                    if (Input.GetMouseButtonDown(1) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        Destroy(laserPointer.hit.collider.gameObject);
                    }
                }
            }
            else
            {
                if (laserPointer.hit.collider.gameObject.tag == "lineRenderer")
                {
                    if (Input.GetMouseButtonDown(1) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    {

                        Destroy(laserPointer.hit.collider.gameObject);

                    }
                }
            }


        }





    }
}
