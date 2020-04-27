using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErasingDeleting : MonoBehaviour
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
        if (laserPointer.onCollison)
        {
            if (laserPointer.hit.collider)
            {
                if(laserPointer.hit.collider.gameObject.transform.childCount>0)
                {
                    if (laserPointer.hit.collider.transform.parent.tag == "object")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            Destroy(laserPointer.hit.collider.gameObject);
                        }
                    }
                }
                else
                {
                    if (laserPointer.hit.collider.gameObject.tag== "lineRenderer")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {

                            Destroy(laserPointer.hit.collider.gameObject);

                        }
                    }
                }
                

            }
        }
        



    }
}
