using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public enum GzimoDirection
{
    XPos,XNeg,YPos,YNeg,ZPos,ZNeg
}

public class GizmoDragger : MonoBehaviour
{

    [SerializeField]
    private GzimoDirection gizmoDirection;
    PhysicsPointer lasetInstance;
    float x;
    bool onDrag = false;
    GameObject selectedObject;
    // Start is called before the first frame update
    void Start()
    {

        lasetInstance = PhysicsPointer.Instance;
  
    }

    // Update is called once per frame
    void Update()
    {


     
        scaleObject();

    }

    public void scaleObject()
    {

        selectedObject = getSelectedObject();

        //Ken kaaaad nezeel aal souris
        if (Input.GetMouseButton(0))
        {
            onDrag = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            onDrag = false;
        }
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

}
