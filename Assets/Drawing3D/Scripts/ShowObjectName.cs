using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowObjectName : MonoBehaviour
{
     GameObject FirstObject;

    GameObject TextGameObject;
    Vector3 Offset;
    // Start is called before the first frame update

    void Start()
    {
        //Debug.Log("sssss");

        if (transform.GetChild(0).gameObject.tag == "object")
        {
            if (transform.GetChild(0).childCount == 1)
            {

                TextGameObject = new GameObject();

            }
            else
            {
                TextGameObject = transform.GetChild(0).GetChild(1).gameObject;
            }

        }
        else if (transform.GetChild(0).gameObject.tag == "lineRenderer")
        {
            if (transform.GetChild(0).childCount == 0)
            {
                TextGameObject = new GameObject();

            }
            else
            {

                TextGameObject = transform.GetChild(0).GetChild(0).gameObject;

            }

        }

        Offset = new Vector3(0, 5f, 2f);
   

    }
   


    private void FixedUpdate()
    {
        CreateText();
        if (transform.childCount > 0)
        {
            UpdateTextPosition();
        }
    }

    void UpdateTextPosition()
    {

        if (transform.GetChild(0).tag == "object")
        {
            TextGameObject.transform.localPosition = Vector3.zero + Offset;

        }
        else if(transform.GetChild(0).tag == "lineRenderer")
        {
            TextGameObject.transform.localPosition = transform.GetChild(0).GetComponent<LineRenderer>().GetPosition(0) + Offset;

        }
    }
        

    void CreateText()
    {


        FirstObject = transform.GetChild(0).gameObject;
        if(GetComponent<TextMeshPro>()==null)
        TextGameObject.AddComponent<TextMeshPro>();
        TextGameObject.GetComponent<TextMeshPro>().enableAutoSizing = true;
        TextGameObject.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Center ;
        TextGameObject.GetComponent<TextMeshPro>().fontSize = 5;
        TextGameObject.transform.parent = FirstObject.transform;
        string Text = gameObject.name.Split('_')[0] + " " + TextGameObject.transform.parent.parent.childCount.ToString() + " obj";
        TextGameObject.GetComponent<TextMeshPro>().text = Text;


    }

}
