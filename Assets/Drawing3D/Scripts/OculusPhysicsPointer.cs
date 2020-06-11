using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;



public enum OculusControllerHand
{
    RIGHT,LEFT
}
public class OculusPhysicsPointer : MonoBehaviour
{

    public OculusControllerHand PhysicsPointerHand;
    public GameObject PhysicsPointer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PhysicsPointerPosition();
    }


    void PhysicsPointerPosition()
    {
        if(PhysicsPointer == null)
        {
            for (int i = 0; i < transform.parent.GetChild(1).childCount; i++)
            {
                if (transform.parent.GetChild(1).GetChild(i).gameObject.GetComponentInChildren<PhysicsPointer>())
                {
                    PhysicsPointer = transform.parent.GetChild(1).GetChild(i).gameObject;
                }
            }

        }
        else
        {

            if (transform.childCount > 0)
            {

                if (PhysicsPointerHand == OculusControllerHand.LEFT)
                {
                    PhysicsPointer.transform.parent = transform.GetChild(0).transform;
                    PhysicsPointer.transform.localPosition = Vector3.zero;
                    PhysicsPointer.transform.localRotation = Quaternion.Euler(Vector3.zero);

                }
                else if (PhysicsPointerHand == OculusControllerHand.RIGHT)
                {
                    PhysicsPointer.transform.parent = transform.GetChild(1).transform;
                    PhysicsPointer.transform.localPosition = Vector3.zero;
                    PhysicsPointer.transform.localRotation = Quaternion.Euler(Vector3.zero);


                }

            }
        
        }

    }
}
