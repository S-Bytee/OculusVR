using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsNavigation : MonoBehaviour
{

    PhysicsPointer laserInstance;
    GameObject selectedButton;
    Color defaultColor = Color.green;
    Color selectedColor = Color.yellow;
    // Start is called before the first frame update
    void Start()
    {
        laserInstance = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {


        if (laserInstance.hit.collider)
        {
            selectedButton = laserInstance.hit.collider.gameObject;

            if (laserInstance.hit.collider.tag == "Clickable")
            {

                GameObject.Find("Drawing").GetComponent<Drawing3D>().enabled = false;

                selectedButton.GetComponent<Renderer>().material.color = selectedColor;

                if (Input.GetMouseButtonDown(0) && selectedButton.name == "Next")
                {
                }

            }
            else
            {
                GameObject.Find("Drawing").GetComponent<Drawing3D>().enabled = true;
            }

        }

    }
}
