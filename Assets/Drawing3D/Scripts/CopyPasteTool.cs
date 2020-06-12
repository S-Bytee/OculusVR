using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPasteTool : MonoBehaviour
{

    PhysicsPointer laserPointer;
    GameObject currgo;


    bool IsDragging = false;
    GameObject SelectedObjectOrLine = null;


    // Start is called before the first frame update
    void Start()
    {

        laserPointer = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {
      SetSelectedObjectOrLine();
    }

    private void FixedUpdate()
    {
        if(IsDragging && currgo!=null && currgo.tag == "object")
        {
            currgo.transform.position = laserPointer.CalculateEnd();

            if (Input.GetMouseButtonDown(0))
            {
            
                currgo.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.r, currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.g, currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.b, currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.a*2); ;
                currgo.transform.GetChild(0).GetComponent<OnSelectObject>().enabled = true;
                IsDragging = false;
                //SelectedObjectOrLine = null;
            
            }
        }

        if (IsDragging && currgo != null && currgo.tag == "lineRenderer")
        {
            currgo.transform.position = laserPointer.CalculateEnd();
           // currgo.GetComponent<LineRenderer>().transform.parent = laserPointer.transform;
            if (Input.GetMouseButtonDown(0))
            {
        
                currgo.transform.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(currgo.transform.GetComponent<Renderer>().material.GetColor("_TintColor").r, currgo.transform.GetComponent<Renderer>().material.GetColor("_TintColor").g, currgo.transform.GetComponent<Renderer>().material.GetColor("_TintColor").b, currgo.transform.GetComponent<Renderer>().material.GetColor("_TintColor").a * 2));
                IsDragging = false;
                currgo.transform.parent = null;
                //SelectedObjectOrLine = null;
            
            }
        }


    }

    public void Copy()
    {

        if (SelectedObjectOrLine.tag == "object")
        {
            CopyObject();
        }
        else if (SelectedObjectOrLine.tag == "lineRenderer")
        {
            CopyLineRenderer();
        }

      
    }


    void CopyObject()
    {
        if(SelectedObjectOrLine!=null)
        {

            if(SelectedObjectOrLine.transform.childCount==0)
            {
                Debug.Log(SelectedObjectOrLine.name);

                currgo = Instantiate(SelectedObjectOrLine.transform.parent.gameObject, SelectedObjectOrLine.transform.position, SelectedObjectOrLine.transform.rotation);

                IsDragging = true;

                currgo.transform.GetChild(0).GetComponent<OnSelectObject>().enabled = false;
                currgo.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.r, currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.g, currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.b, currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.a / 2); ;

            }
            else
            {
              Debug.Log(SelectedObjectOrLine.name);

                currgo = Instantiate(SelectedObjectOrLine.gameObject, SelectedObjectOrLine.transform.position, SelectedObjectOrLine.transform.rotation);

                IsDragging = true;

                currgo.transform.GetChild(0).GetComponent<OnSelectObject>().enabled = false;
                currgo.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.r, currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.g, currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.b, currgo.transform.GetChild(0).GetComponent<Renderer>().material.color.a / 2); ;
                
            }

        }
    }


    void CopyLineRenderer()
    {
        if (SelectedObjectOrLine != null)
        {
           
            currgo = Instantiate(SelectedObjectOrLine.transform.gameObject, SelectedObjectOrLine.transform.position, SelectedObjectOrLine.transform.rotation);
            IsDragging = true;
            currgo.transform.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(currgo.transform.GetComponent<Renderer>().material.GetColor("_TintColor").r, currgo.transform.GetComponent<Renderer>().material.GetColor("_TintColor").g, currgo.transform.GetComponent<Renderer>().material.GetColor("_TintColor").b, currgo.transform.GetComponent<Renderer>().material.GetColor("_TintColor").a * 2));

        }

    }


    void SetSelectedObjectOrLine()
    {

        SelectedObjectOrLine = getSelectedObject();
        if (SelectedObjectOrLine == null)
        {

            SelectedObjectOrLine = getSelectedLineRenderer();
            
        }

    }

    public GameObject getSelectedObject()
    {

        GameObject selectedObject = null;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("object"))
        {
            if (go.GetComponentInChildren<OnSelectObject>())
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
