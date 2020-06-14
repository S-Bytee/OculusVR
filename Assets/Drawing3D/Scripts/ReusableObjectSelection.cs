using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReusableObjectSelection : MonoBehaviour
{
    public bool IsSelected = false;

    private void Update()
    {
        Debug.Log("IsSelected: "+IsSelected);
        for(int i=0;i<transform.childCount;i++)
        {
            if(transform.GetChild(i).tag=="object")
            {
                transform.GetChild(i).GetChild(0).GetComponent<OnSelectObject>().isClicked = false;
                transform.GetChild(i).GetChild(0).GetComponent<OnSelectObject>().enabled = false;
                
            }else if(transform.GetChild(i).tag == "lineRenderer")
            {
                transform.GetChild(i).GetComponent<SelectLineRenderer>().isSelected = false;
                transform.GetChild(i).GetComponent<SelectLineRenderer>().enabled = false;
            }
        }
    }
}
