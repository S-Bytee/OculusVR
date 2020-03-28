using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectObject : MonoBehaviour
{

    Shader sh1;
    Shader shStandard;
    PhysicsPointer laserPointer;
    GameObject go=null;
    GameObject artisticTools;
    public bool isClicked;
    List<GameObject> exceptions;
    // Start is called before the first frame update
    void Start()
    {
        exceptions = new List<GameObject>();

        sh1 = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
        shStandard = Shader.Find("Standard");
        laserPointer = PhysicsPointer.Instance;
        artisticTools = GameObject.Find("ArtisticTools");

        addToExcpetions("artisticTools");
        addToExcpetions("gizmo");
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if(laserPointer.onCollison)
        {
            if (laserPointer.hit.collider)
                go = laserPointer.hit.collider.gameObject;
        }
        else
        {
            go = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(go == this.gameObject)
            {
                isClicked = true;

            }
            else
            {
                //ken l go artistic tools ouala gizmo donc kh
                if(!exceptions.Contains(go))
                isClicked = false;
            }
        }
        
        Debug.Log(isClicked);
        mainBehavior();
    }

    public void onSelectObject()
    {       
        Debug.Log(laserPointer.onCollison);
        if (laserPointer.onCollison)
        {

            if (go == this.gameObject)
            {
                GetComponent<Renderer>().material.shader = sh1;

                onClickObject();
            }
            else
            {

                GetComponent<Renderer>().material.shader = shStandard;
            }

        }
        else
        {
            GetComponent<Renderer>().material.shader = shStandard;

        }
    }

    public void onClickObject()
    {
                  
            if (go == this.gameObject)
            {

            GetComponent<Renderer>().material.shader = sh1;

            //GameObject.Find("ArtisticTools").SetActive(true);
                
            }
            else
            {
            
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Renderer>().material.shader = shStandard;
                  //  artisticTools.SetActive(false);
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
        foreach(GameObject go in GameObject.FindGameObjectsWithTag(tag))
        {
            exceptions.Add(go);
        }
    }

}
