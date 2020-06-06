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
        TextGameObject = new GameObject();
        Offset = new Vector3(0, 5f, 2f);
    }



    private void FixedUpdate()
    {
        if (transform.childCount > 0)
        {
            CreateText();
            UpdateTextPosition();
        }
            
    }

    void UpdateTextPosition()
    {
        TextGameObject.transform.localPosition = Vector3.zero+Offset;
    }
        

    void CreateText()
    {


        FirstObject = transform.GetChild(0).gameObject;
        if(!GetComponent<TextMeshPro>())
        TextGameObject.AddComponent<TextMeshPro>();
        TextGameObject.GetComponent<TextMeshPro>().enableAutoSizing = true;
        TextGameObject.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Center ;
        TextGameObject.GetComponent<TextMeshPro>().fontSize = 5;
        TextGameObject.transform.parent = FirstObject.transform;
        string Text = gameObject.name + " " + TextGameObject.transform.parent.parent.childCount.ToString() + " obj";
        TextGameObject.GetComponent<TextMeshPro>().text = Text;

    }

}
