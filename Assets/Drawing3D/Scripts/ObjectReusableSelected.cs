using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectReusableSelected : MonoBehaviour
{

    PhysicsPointer laserInstance;

    string[] exceptions= {"gizmo"};

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
            if(laserInstance.hit.collider.gameObject==this.gameObject)
            {
                if(this.gameObject.transform.parent.parent)
                {
                    if (this.gameObject.transform.parent.parent.tag == "reusableObject")
                    {
                        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                        {
                            DeselectLineRenderer();
                            DeselectObjects();
                            this.gameObject.transform.parent.parent.GetComponent<ReusableObjectSelection>().IsSelected = true;
                        }
                    }else
                    {

                        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                        {
                            if (!exceptions.Contains(laserInstance.hit.collider.gameObject.tag))
                            {
                                DeselectReusable();
                            }
                        }
                       
                    }

                }
                else
                {

                    if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {
                        if (!exceptions.Contains(laserInstance.hit.collider.gameObject.tag))
                        {
                            DeselectReusable();
                        }
                    }
                }

                
                
            }else
            {

                //DeselectReusable();
                if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    if (!exceptions.Contains(laserInstance.hit.collider.gameObject.tag))
                    {
                        DeselectReusable();
                    }
                }


            }
        }
    }



    void DeselectReusable()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("reusableObject"))
        {
            go.GetComponent<ReusableObjectSelection>().IsSelected = false;
        }
    }


   void DeselectLineRenderer()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("lineRenderer"))
        {
            if (go.GetComponent<SelectLineRenderer>().enabled)

                go.GetComponent<SelectLineRenderer>().isSelected = false;
        }
    }

    void DeselectObjects()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("object"))
        {
            if(go.GetComponent<OnSelectObject>())
            go.GetComponent<OnSelectObject>().isClicked = false;
        }
    }
}
