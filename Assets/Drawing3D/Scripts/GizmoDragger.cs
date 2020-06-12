using Shapes2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public enum GzimoDirection
{
    XPos,XNeg,YPos,YNeg,ZPos,ZNeg
}
public enum GizmoMode
{
    Rotating,Scaling
}
public class GizmoDragger : MonoBehaviour
{

    [SerializeField]
    private GzimoDirection gizmoDirection;
    [SerializeField]
    private GizmoMode gizmoMode;

    PhysicsPointer lasetInstance;
    float x;
    bool onDrag = false;
    GameObject selectedObject = null;
    // Start is called before the first frame update
    void Start()
    {

        lasetInstance = PhysicsPointer.Instance;
  
    }

    // Update is called once per frame
    void Update()
    {

        //Ken kaaaad nezeel aal souris
        if (Input.GetMouseButton(0))
        {
            onDrag = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            onDrag = false;
        }

        selectedObject = getSelectedObject();   
        if (selectedObject == null)
            selectedObject = getSelectedLineRenderer();
        

        if (gizmoMode== GizmoMode.Scaling)
        {
            if(selectedObject.gameObject.tag == "object")
            scaleObject();
        }

        if (gizmoMode == GizmoMode.Rotating)
        {
            if(selectedObject.gameObject.tag=="object")
                RotateObject();

            if (selectedObject.gameObject.tag == "lineRenderer")
                RotateLineRenderer();
        }

    }


    Vector3 GetMiddlePointLineRenderer()
    {
        int MiddleIndex = 0;
        if(selectedObject.GetComponent<LineRenderer>().positionCount%2 ==0)
        {
            MiddleIndex = selectedObject.GetComponent<LineRenderer>().positionCount / 2;
        }
        else if (selectedObject.GetComponent<LineRenderer>().positionCount !=0 )
        {
            MiddleIndex = (selectedObject.GetComponent<LineRenderer>().positionCount + 1) / 2;
        }


        return selectedObject.GetComponent<LineRenderer>().GetPosition(MiddleIndex);
    }
        
    void RotateLineRenderer()
    {
         
        if (lasetInstance.hit.collider)
        {

            if (lasetInstance.hit.collider.gameObject == this.gameObject)
            {
                switch (gizmoDirection)
                {
                    case GzimoDirection.XPos:
                        {
                            if (onDrag)
                            {
                                x += 5f * Time.deltaTime;

                                selectedObject.transform.RotateAround(GetMiddlePointLineRenderer(), Vector3.right, x);                               
                            }
                            else
                            {
                                x = 0;
                            }

                            break;
                        }

                    case GzimoDirection.XNeg:
                        {
                            if (onDrag)
                            {

                                x += 5f * Time.deltaTime;
                                selectedObject.transform.RotateAround(GetMiddlePointLineRenderer(), -Vector3.right, x);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;
                        }


                    case GzimoDirection.YPos:
                        {
                            if (onDrag)
                            {

                                x += 5f * Time.deltaTime;
                                selectedObject.transform.RotateAround(GetMiddlePointLineRenderer(), Vector3.up, x);


                            }
                            else
                            {
                                x = 0;
                            }

                            break;

                        }

                    case GzimoDirection.YNeg:
                        {
                            if (onDrag)
                            {

                                x += 5f * Time.deltaTime;
                                selectedObject.transform.RotateAround(GetMiddlePointLineRenderer(), -Vector3.up, x);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;

                        }
                    case GzimoDirection.ZPos:
                        {
                            if (onDrag)
                            {

                                x += 5f * Time.deltaTime;
                                selectedObject.transform.RotateAround(GetMiddlePointLineRenderer(), Vector3.forward, x);

                            }
                            else
                            {
                                x = 0;
                            }
                            break;
                        }

                    case GzimoDirection.ZNeg:
                        {
                            if (onDrag)
                            {

                                x += 5f * Time.deltaTime;
                                selectedObject.transform.RotateAround(GetMiddlePointLineRenderer(), -Vector3.forward, x);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;
                        }

                }

                //Ken kaaad nezeeel aal souris o houaa fel fleche l gris mtaa -X 
            }


        }
    }
    private void RotateObject()
    {

    

        if (lasetInstance.hit.collider)
        {

            if (lasetInstance.hit.collider.gameObject == this.gameObject)
            {
                switch (gizmoDirection)
                {
                    case GzimoDirection.XPos:
                        {
                            if (onDrag)
                            {
                                //Debug.Log("ssss");

                                x += 5f * Time.deltaTime;

                                selectedObject.transform.localRotation *= Quaternion.AngleAxis( x,Vector3.right); 
                                //selectedObject.transform.RotateAround(selectedObject.GetComponent<LineRenderer>().GetPosition(0), Vector3.right, x);                               
                            }
                            else
                            {
                                x = 0;
                            }

                            break;
                        }

                    case GzimoDirection.XNeg:
                        {
                            if (onDrag)
                            {

                                x += 5f * Time.deltaTime;
                                selectedObject.transform.rotation *= Quaternion.AngleAxis(x , -Vector3.right);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;
                        }


                    case GzimoDirection.YPos:
                        {
                            if (onDrag)
                            {

                                x += 5f * Time.deltaTime;
                                selectedObject.transform.rotation *= Quaternion.AngleAxis(x , Vector3.up);


                            }
                            else
                            {
                                x = 0;
                            }

                            break;

                        }

                    case GzimoDirection.YNeg:
                        {
                            if (onDrag)
                            {

                                x += 5f * Time.deltaTime;
                                selectedObject.transform.rotation *= Quaternion.AngleAxis(x, -Vector3.up);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;

                        }
                    case GzimoDirection.ZPos:
                        {
                            if (onDrag)
                            {

                                x += 5f * Time.deltaTime;
                                selectedObject.transform.rotation *= Quaternion.AngleAxis(x,Vector3.forward);

                            }
                            else
                            {
                                x = 0;
                            }
                            break;
                        }

                    case GzimoDirection.ZNeg:
                        {
                            if (onDrag)
                            {

                                x += 5f * Time.deltaTime;
                                selectedObject.transform.rotation *= Quaternion.AngleAxis(x, -Vector3.forward);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;
                        }

                }

                //Ken kaaad nezeeel aal souris o houaa fel fleche l gris mtaa -X 
            }


        }


    }

    public void scaleObject()
    {

         if (lasetInstance.hit.collider)
        {
           
        
                if (lasetInstance.hit.collider.gameObject == this.gameObject)
                {
                switch(gizmoDirection)
                {
                    case GzimoDirection.XPos:
                        {
                            if (onDrag)
                            {

                                x += 0.3f * Time.deltaTime;
                                selectedObject.transform.localScale = new Vector3(x + selectedObject.transform.localScale.x, selectedObject.transform.localScale.y, selectedObject.transform.localScale.z);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;
                        }
                        
                    case GzimoDirection.XNeg:
                        {
                            if (onDrag)
                            {

                                x += 0.3f * Time.deltaTime;
                                selectedObject.transform.localScale = new Vector3(-x + selectedObject.transform.localScale.x, selectedObject.transform.localScale.y, selectedObject.transform.localScale.z);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;
                        }

                        
                    case GzimoDirection.YPos:
                        {
                            if (onDrag)
                            {

                                x += 0.3f * Time.deltaTime;
                                selectedObject.transform.localScale = new Vector3(selectedObject.transform.localScale.x, x + selectedObject.transform.localScale.y, selectedObject.transform.localScale.z);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;

                        }

                    case GzimoDirection.YNeg:
                        {
                            if (onDrag)
                            {

                                x += 0.3f * Time.deltaTime;
                                selectedObject.transform.localScale = new Vector3(selectedObject.transform.localScale.x, -x + selectedObject.transform.localScale.y, selectedObject.transform.localScale.z);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;

                        }
                    case GzimoDirection.ZPos:
                        {
                            if (onDrag)
                            {

                                x += 0.3f * Time.deltaTime;
                                selectedObject.transform.localScale = new Vector3(selectedObject.transform.localScale.x, selectedObject.transform.localScale.y, x + selectedObject.transform.localScale.z);

                            }
                            else
                            {
                                x = 0;
                            }
                            break;
                        }                        
                        
                    case GzimoDirection.ZNeg:
                        {
                            if (onDrag)
                            {

                                x += 0.3f * Time.deltaTime;
                                selectedObject.transform.localScale = new Vector3(selectedObject.transform.localScale.x, selectedObject.transform.localScale.y, -x + selectedObject.transform.localScale.z);

                            }
                            else
                            {
                                x = 0;
                            }

                            break;
                        }
                        
                }

                    //Ken kaaad nezeeel aal souris o houaa fel fleche l gris mtaa -X 
                    
                
            
            
            
            }
            
            
        }
    }
    public GameObject getSelectedObject()
    {

        GameObject selectedObject = null;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("object"))
        {
            if(go.GetComponentInChildren<OnSelectObject>())
            {
                if (go.GetComponentInChildren<OnSelectObject>().isClicked)
                {

                    selectedObject = go.gameObject;

                }
            }
            
        }

        return selectedObject;

    }

    public GameObject getSelectedLineRenderer()
    {

        GameObject selectedObject = null;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("lineRenderer"))
        {
            if (go.GetComponent<SelectLineRenderer>())
            {
                if (go.GetComponent<SelectLineRenderer>().isSelected)
                {

                    selectedObject = go.gameObject;

                }
            }

        }

        return selectedObject;

    }

}
