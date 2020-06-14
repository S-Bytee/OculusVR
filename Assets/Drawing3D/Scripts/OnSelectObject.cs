using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectObject : MonoBehaviour
{

    Shader sh1;
    Shader shStandard;
    Shader shader2D;
    PhysicsPointer laserPointer;
    GameObject go=null;
    public bool isClicked;
    List<string> exceptions;

    // Start is called before the first frame update
    void Start()
    {
        exceptions = new List<string>();
        shader2D = Shader.Find("Shapes2D/Shape");
        sh1 = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
        shStandard = Shader.Find("Standard");
        laserPointer = PhysicsPointer.Instance;
        exceptions.Add("artisticTools");
        exceptions.Add("gizmo");
       
    }

    // Update is called once per frame
    void Update()
    {

     
        if(laserPointer.onCollison)
        {
         
            if (laserPointer.hit.collider)
            {
                go = laserPointer.hit.collider.gameObject;
            }

        }
        
    

        //Ki yenzel aala bouton souris
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {

            //Idha l laser aamel collision maa haja
            if (go!=null)
            {
                //Idha laser aaamel collision maa l instance mtaa l objet li fih script hedha
                if (go == this.gameObject)
                {
                    DisableAllLineRendererSelection();
                    DeselectAllReusableOjects();
                        isClicked = true;

                }
                else
                {
                    //Idha laser aamel collision maa artisticTools ouala gizmo
                    if (!exceptions.Contains(go.tag))
                    {
                        isClicked = false;
                    }

                }
            }
            else
            {

                isClicked = false;

            }

        }

       // Debug.Log(isClicked);

        mainBehavior();
    }

    public void onSelectObject()
    {       
        if (laserPointer.onCollison)
        {

            if (go == this.gameObject)
            {

                    if(!this.gameObject.GetComponent<Shape>())
                    GetComponent<Renderer>().material.shader = sh1;

                onClickObject();
            
            }
            else
            {
                if (!this.gameObject.GetComponent<Shape>())
                    GetComponent<Renderer>().material.shader = shStandard;
            
            }

        }
        else
        {

            if (!this.gameObject.GetComponent<Shape>())
                GetComponent<Renderer>().material.shader = shStandard;

        }
    }

    public void onClickObject()
    {
                  
            if (go == this.gameObject)
            {

            if (!this.gameObject.GetComponent<Shape>())
                GetComponent<Renderer>().material.shader = sh1;

                
            }
            else
            {
            
                if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {

                if (!this.gameObject.GetComponent<Shape>())
                    GetComponent<Renderer>().material.shader = shStandard;
  
               
                }


        }  
        

    }

    public void mainBehavior()
    {
        if(isClicked)
        {
            onClickObject();
        }
        else
        {
            onSelectObject();
        }

    }

    public void addToExcpetions(string tag)
    {
        if (!exceptions.Contains(tag))
        {

            exceptions.Add(tag);
        }
        
    }


    void DisableAllLineRendererSelection()
    {

        foreach(GameObject go in GameObject.FindGameObjectsWithTag("lineRenderer"))
        {
            if (go.GetComponent<SelectLineRenderer>().isSelected == true)
                go.GetComponent<SelectLineRenderer>().isSelected = false;
        }

    }

    void DeselectAllReusableOjects()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("reusableObject"))
        {
                go.GetComponent<ReusableObjectSelection>().IsSelected = false;
        }
    }

    
}
