using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectObject : MonoBehaviour
{

    Shader sh1;
    Shader shStandard;
    PhysicsPointer laserPointer;
    GameObject go=null;
    public bool isClicked;
    List<string> exceptions;
    GameObject tempGizmo;
    public GameObject gizmo;
    // Start is called before the first frame update
    void Start()
    {
        exceptions = new List<string>();

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
        else
        {

            go = null;

        }
        if(go)
        Debug.Log(go.tag);


        //Ki yenzel aala bouton souris
        if (Input.GetMouseButtonDown(0))
        {
            //Idha l laser aamel collision maa haja
            if(go!=null)
            {
                //Idha laser aaamel collision maa l instance mtaa l objet li fih script hedha
                if (go == this.gameObject)
                {

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

        

        /*
        if (Input.GetMouseButtonDown(0))
        {
            if(go == this.gameObject )
            {
                isClicked = true;
                showGizmo();


            }
            else
            {
                if(go == null)
                {
                    isClicked = false;
                    destroyGizmo();
                }
                else
                {  
                    //ken l go artistic tools ouala gizmo donc kh

                    if (exceptions.Contains(go.tag))
                    {
                        isClicked = true;

                    }
                    else { isClicked = false; destroyGizmo(); }
                }
               

            }
        }
        */
        mainBehavior();
    }

    public void onSelectObject()
    {       
        //Debug.Log(laserPointer.onCollison);
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

                destroyGizmo();
                //  artisticTools.SetActive(false);
                    
               
            }


        }  
        

    }

    public void mainBehavior()
    {
        Debug.Log(isClicked);
        if(isClicked)
        {
            onClickObject();
            showGizmo();
        }
        else
        {
            onSelectObject();
            destroyGizmo();
        }

    }

    public void addToExcpetions(string tag)
    {
        if (!exceptions.Contains(tag))
        {

            exceptions.Add(tag);
        }
        
    }

    public void showGizmo()
    {
       if(tempGizmo == null)
       tempGizmo= Instantiate(gizmo, transform.position + Vector3.up * 1, Quaternion.identity);

    }

    public void destroyGizmo()
    {

                Destroy(tempGizmo);

    }


}
