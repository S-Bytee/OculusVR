using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ArtisticToolsHandler : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    Color defaultColor = Color.green;
    Color selectedColor = Color.yellow;
    GameObject[] buttons = null;
    PhysicsPointer laserInstance;
    GameObject selectedButton = null;

    public GameObject newCube;
    public GameObject newSphere;
    public GameObject newQuad;
    Vector3 instanceOffset;
    GameObject player;
    Vector3 offset;
    GameObject currCubeInstance;
    GameObject currSphereInstance;
    GameObject currQuadInstance;
    public GameObject teleportGO;

    void Start()
    {

        laserInstance = PhysicsPointer.Instance;
        buttons = GameObject.FindGameObjectsWithTag("Clickable");
        instanceOffset = new Vector3(0,0,10);
        player = GameObject.FindGameObjectWithTag("Player");
        setPosition();
        offset = new Vector3(0, 1.5f, 6);
    }

    // Update is called once per frame
    void Update()
    {
       
        setPosition();
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

                if (Input.GetMouseButtonDown(0) && selectedButton.name == "buttonSphere")
                {
                
                    createSphere();

                }

                if (Input.GetMouseButtonDown(0) && selectedButton.name == "buttonQuad")
                {

                    createQuad();

                }

                if (Input.GetMouseButtonDown(0) && selectedButton.name == "TeleportButton")
                {

                    teleportPlayer();

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


     currCubeInstance =  Instantiate(newCube, player.transform.position+instanceOffset, Quaternion.identity);
     currCubeInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();


    }

    public void createSphere()
    {

     currSphereInstance = Instantiate(newSphere, player.transform.position + instanceOffset, Quaternion.identity);
     currSphereInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
    
    }

    public void createQuad()
    {

        currQuadInstance = Instantiate(newQuad, player.transform.position + instanceOffset, Quaternion.identity);
        currQuadInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();

    }

    public void teleportPlayer()
    {

        Instantiate(teleportGO, laserInstance.DefaultEnd(laserInstance.defaultLength),Quaternion.identity);

    }


    public void setPosition()
    {
        transform.position = player.transform.position + offset;
    }

    public void onBackClick(int indexChild)
    {

        transform.GetChild(indexChild).gameObject.SetActive(false);
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("onBackClick");
        Debug.Log(transform.GetChild(0).name);
    }
  

}
