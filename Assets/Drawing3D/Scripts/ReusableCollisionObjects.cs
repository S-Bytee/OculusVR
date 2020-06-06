using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Component = UnityEngine.Component;

public class ReusableCollisionObjects : MonoBehaviour
{
    PhysicsPointer laserInstance;
    Shader sh1;

    Ray ray;
    public bool IsCollidedWithObject = false;
    LineRenderer lineRenderer;
    Vector3[] Points;
    // Start is called before the first frame update
    void Start()
    {

        laserInstance = PhysicsPointer.Instance;
        sh1 = Shader.Find("Standard");
        if(gameObject.tag == "lineRenderer")
        {
            lineRenderer = gameObject.GetComponent<LineRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(gameObject.tag == "object")
        {

            handleCollisionForObject();

        }
        else if (gameObject.tag == "lineRenderer")
        {
            HandleCollisionForLineRenderer();
        }


    }

    


    void handleCollisionForObject()
    {

        if (laserInstance.hit.collider)
        {
            if (laserInstance.hit.collider.gameObject != gameObject)
            {
                if (!IsCollidedWithObject)
                {
                   
                        transform.parent.parent = null;
                        GetComponent<Renderer>().material.shader = sh1;

                        GetComponent<OnSelectObject>().enabled = true;

                    
                 

                }

            }
        }
        else
        {
            if (!IsCollidedWithObject)
            {
              
                    transform.parent.parent = null;
                    GetComponent<Renderer>().material.shader = sh1;
                    GetComponent<OnSelectObject>().enabled = true;
                
         
            }

        }
    }

    void HandleCollisionForLineRenderer()
    {
            
                      if (transform.parent == null)
                      {

                            if (GetComponent<Rigidbody>())
                                Destroy(GetComponent<Rigidbody>());        
                      }
                      else
                      {

                        AddRigidBodyToLine();
                                
                      }


              Debug.Log(gameObject.GetInstanceID() + " / " + IsCollidedWithObject);

    }

    void AddRigidBodyToLine() 
    {
        if(GetComponent<Rigidbody>())
        {

        }
        else
        {
            
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

        }


    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "object" || collision.gameObject.tag == "lineRenderer")
        {
            IsCollidedWithObject = true;

        }

    }

    private void OnCollisionStay(Collision collision)
    {
        

        if (collision.gameObject.tag == "object" || collision.gameObject.tag == "lineRenderer")
        {
            
            IsCollidedWithObject = true;

        }


    }


    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.tag == "object" ||  collision.gameObject.tag == "lineRenderer")
        {
            IsCollidedWithObject = false;
            Debug.Log(">>>>>>>>>>>");
        }

    }

    

    

}
