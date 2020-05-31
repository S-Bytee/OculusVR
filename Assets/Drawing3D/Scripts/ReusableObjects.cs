using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReusableObjects : MonoBehaviour
{
    PhysicsPointer laserInstance;

    GameObject rootGo; 
    // Start is called before the first frame update
    void Start()
    {

        laserInstance = PhysicsPointer.Instance;

    }
    private void OnEnable()
    {
        rootGo = new GameObject();
    }
    // Update is called once per frame
    void Update()
    {
        AddObject();
    }


    void AddObject()
    {
        if(laserInstance.hit.collider)
        {
            
            if(laserInstance.hit.collider.tag == "lineRenderer")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    laserInstance.hit.collider.gameObject.transform.parent = rootGo.transform;
                }
            }


            if(laserInstance.hit.collider.tag == "object")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    laserInstance.hit.collider.gameObject.transform.parent.transform.parent = rootGo.transform;
                }
            }
        }
    }

    void GroupObjects()
    {


    }

    void SaveObject()
    {

    }


}
