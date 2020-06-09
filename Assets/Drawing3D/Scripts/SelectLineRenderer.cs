using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLineRenderer : MonoBehaviour
{

    PhysicsPointer laserInstance;
    public bool isSelected;
    // Start is called before the first frame update
    void Start()
    {

        isSelected = false;
        laserInstance = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {


        OnLaserClick();
        

    }


    void OnLaserClick()
    {
        if (laserInstance.hit.collider)
        {
            if (laserInstance.hit.collider.gameObject == gameObject)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    
                    DisableAllObjectSelection();
                    isSelected = true;
                        
                }
            }
        }


        if (laserInstance.hit.collider)
        {
            if (laserInstance.hit.collider.gameObject != gameObject && laserInstance.hit.collider.gameObject.tag != "artisticTools" && laserInstance.hit.collider.gameObject.tag != "gizmo")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    isSelected = false;
                }
            }
        }
        else
        {
            //isSelected = false;
        }
    }

    void DisableAllObjectSelection()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("object"))
        {
            if(go.transform.childCount == 1)
            {
                if (go.transform.GetChild(0).GetComponent<OnSelectObject>().isClicked == true)
                    go.transform.GetChild(0).GetComponent<OnSelectObject>().isClicked = false;

            }
        }
    }


}
