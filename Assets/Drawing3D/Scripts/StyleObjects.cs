using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleObjects : MonoBehaviour
{
    
    Shader sh1;
    Shader shOriginal;
    public Color OutlineColor;
    // Start is called before the first frame update
    void Start()
    {

        sh1 = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
        OutlineColor = new Color(250, 65, 204);
        
    }

    // Update is called once per frame
    void Update()
    {
        StyleObject();
    }

    public void StyleObject()
    {

        if (transform.childCount > 0)
        {
            GetComponent<ShowObjectName>().enabled = true;
            UpdateOutlineColor();
        }
        else
        {
            GetComponent<ShowObjectName>().enabled = false;

        }


        for (int i=0; i<transform.childCount;i++)
        {
            

            if(transform.GetChild(i).tag == "object")
            {
                
                transform.GetChild(i).GetChild(0).GetComponent<Renderer>().material.shader = sh1;     
                transform.GetChild(i).GetChild(0).GetComponent<Renderer>().material.SetColor("_OutlineColor",OutlineColor) ;
                transform.GetChild(i).GetChild(0).GetComponent<OnSelectObject>().enabled = false;

            }
            else if(transform.GetChild(i).tag == "lineRenderer")
            {

                /*transform.GetChild(i).GetComponent<Renderer>().material.shader = sh1;
                transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_OutlineColor", OutlineColor);
                transform.GetChild(i).GetChild(0).GetComponent<SelectLineRenderer>().enabled = false;
                */
            }
        }

    }

    void UpdateOutlineColor()
    {
        if(transform.GetChild(0).tag=="object")
        {

            OutlineColor = transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.GetColor("_Color");

        }
        else if(transform.GetChild(0).tag == "lineRenderer")
        {
            OutlineColor = transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color");

        }
    }
}
