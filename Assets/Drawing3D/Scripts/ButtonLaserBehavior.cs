using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLaserBehavior : MonoBehaviour
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
        if(laserPointer)
        {
            if (laserPointer.hit.collider)
            {
                if (laserPointer.hit.collider.gameObject == this.gameObject)
                {
                    if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                        this.gameObject.GetComponent<Button>().onClick.Invoke();

                }
            }
        }
            

    }
}
