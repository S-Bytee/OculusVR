using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtisticToolsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    Color defaultColor = Color.green;
    Color selectedColor = Color.yellow;
    GameObject[] buttons = null;
    PhysicsPointer laserInstance;
    GameObject selectedButton = null;

    public GameObject newCube;
    Vector3 instanceOffset;
    GameObject player;
    void Start()
    {
        laserInstance = PhysicsPointer.Instance;
        buttons = GameObject.FindGameObjectsWithTag("Clickable");
        instanceOffset = new Vector3(0,0,10);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        handleButton();
    }

    public void handleButton()
    {

        if(laserInstance.hit.collider )
        {
            selectedButton = laserInstance.hit.collider.gameObject;

            if (laserInstance.hit.collider.tag == "Clickable")
            {

                GameObject.Find("Drawing").GetComponent<Drawing3D>().enabled = false;

                selectedButton.GetComponent<Renderer>().material.color = selectedColor;

                if (Input.GetMouseButtonDown(0) && selectedButton.name== "buttonCube")
                {
                    createCube();
                    
                }

                if (Input.GetMouseButtonDown(0) && selectedButton.name == "Next")
                {

                    transform.localEulerAngles = transform.localEulerAngles + Vector3.up * 90;


                }

            }
            else
            {
                GameObject.Find("Drawing").GetComponent<Drawing3D>().enabled = true;
                backToDefaultColor();
            }
                            
        }
    }


    public void backToDefaultColor()
    {
      foreach(GameObject btn in buttons)
        {
            btn.GetComponent<Renderer>().material.color = defaultColor;
        }
    }

    public void createCube()
    {


        Instantiate(newCube, player.transform.position+instanceOffset, Quaternion.identity);

    }

   

}
