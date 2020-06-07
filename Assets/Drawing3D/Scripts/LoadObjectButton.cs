using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjectButton : MonoBehaviour
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
        
        if(laserInstance.hit.collider)
        {
            if(laserInstance.hit.collider.gameObject== gameObject)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    transform.parent.GetComponent<LoadReusableObjects>().InstanciateObject(gameObject.name);
                }
            }
        }

    }



}
