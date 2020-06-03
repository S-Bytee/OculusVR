using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObjectsReturnState : MonoBehaviour
{

    PhysicsPointer laserInstance;

    public GameObject ReusableObects;

    // Start is called before the first frame update
    void Start()
    {

        laserInstance = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        ReturnToStateAndPlayAnimation();
    }

    public void ReturnToStateAndPlayAnimation()
    {
        if(laserInstance.hit.collider)
        {
            if(laserInstance.hit.collider.gameObject == this.gameObject)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    GetComponent<Animator>().SetBool("active", false);
                    GetComponent<Animator>().SetFloat("direction", -1); 
                    GetComponent<BoxCollider>().enabled = false;
                    transform.parent.GetChild(0).GetChild(2).GetComponent<Animator>().SetBool("active", false);
                    transform.parent.GetChild(0).GetChild(2).GetComponent<Animator>().SetFloat("direction", -1);  

                }
            }
        }
    }

    public void ReturnToStateIfCreated()
    {

        if(ReusableObects.GetComponent<ReusableObjects>().IsCreated)
        {
            GetComponent<Animator>().SetBool("active", false);
            GetComponent<Animator>().SetFloat("direction", -1);
            GetComponent<BoxCollider>().enabled = false;
            transform.parent.GetChild(0).GetChild(2).GetComponent<Animator>().SetBool("active", false);
            transform.parent.GetChild(0).GetChild(2).GetComponent<Animator>().SetFloat("direction", -1);
        }

    }

    
}
