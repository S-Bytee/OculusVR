using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Shapes2D;

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
    Vector3 instanceOffset;
    GameObject player;
    Vector3 offset;
    GameObject currCubeInstance;
    GameObject currSphereInstance;
    GameObject currQuadInstance;
    public GameObject teleportGO;

    
   
    //Prefab mtaa box example
    public GameObject boxExample;
    //L instance mtaa prefab li besh nasn3oha
    GameObject currboxExample;
    //Variable de test besh naarfou beha idha l box example mazel mawjoud ouala le
    bool boxExampleFollow = false;
    //l position mtaa l box l example une fois yenzel aal clique
    Vector3 cubeInstancePos;


    public GameObject sphereExample;
    GameObject currShpereExample;
    bool sphereExampleFollow = false;
    Vector3 sphereInstancePos;

    public Material previewMaterial;
    public Material defaultMaterial;

    // 2D declaratives //

    
    
    



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
     
        onBoxExampleFollow();
        instanciateCube();

        onSphereExampleFollow();
        instanciateSphere();


        onRectanglePreviewFollow();
        onCirclePreviewFollow();
        onTrianglePreviewFollow();
        onPolygonePreviewFollow();





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
        
        
        if (!boxExampleFollow)
        {
            
            currboxExample = Instantiate(boxExample, Vector3.zero, Quaternion.identity);
            
            boxExampleFollow = true;

        }
     

    }

    public void instanciateCube()
    {


        if (Input.GetMouseButtonDown(0))
        {

            if (laserInstance.hit.collider)
            {
                if (laserInstance.hit.collider.tag == "exampleCubeObject")
                {
                    currCubeInstance = Instantiate(newCube, cubeInstancePos, Quaternion.identity);
                    currCubeInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
                    boxExampleFollow = false;
                }

            }


        };
    }

    public void instanciateSphere()
    {


        if (Input.GetMouseButtonDown(0))
        {

            if (laserInstance.hit.collider)
            {
                if (laserInstance.hit.collider.tag == "exampleSphereObject")
                {
                    currCubeInstance = Instantiate(newSphere, sphereInstancePos, Quaternion.identity);
                    currCubeInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
                    sphereExampleFollow = false;
                }

            }


        };
    }



    public void createSphere()
    {

        if (!sphereExampleFollow)
        {

            currShpereExample = Instantiate(sphereExample, Vector3.zero, Quaternion.identity);

            sphereExampleFollow = true;

        }
    }


    public void teleportPlayer()
    {

        Instantiate(teleportGO, laserInstance.DefaultEnd(laserInstance.defaultLength),Quaternion.identity);

    }


    public void setPosition()
    {
        transform.position = player.transform.position + offset;
    }




    public void onBoxExampleFollow()
    {

        if (boxExampleFollow)
        {
            currboxExample.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);
            cubeInstancePos = currboxExample.transform.position;
        }
        else
        {
            Destroy(currboxExample);

        }

    }

    public void onSphereExampleFollow()
    {

        if (sphereExampleFollow)
        {
            currShpereExample.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);
            sphereInstancePos = currShpereExample.transform.position;
        }
        else
        {
            Destroy(currShpereExample);

        }

    }

    public void onBackClick(int indexChild)
    {

        transform.GetChild(indexChild).gameObject.SetActive(false);
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("onBackClick");
        Debug.Log(transform.GetChild(0).name);
    }


    //********************************* 2D Shapes *********************************//

    
    
    
    public GameObject rectangle;
    GameObject currRectangle;
    bool onPreviewFollow = false;

    public void createRectangle()
    {
        currRectangle=  Instantiate(rectangle, player.transform.position + instanceOffset, Quaternion.identity);
        onPreviewFollow = true;        
            
    }

    public void onRectanglePreviewFollow()
    {    
     
        if(onPreviewFollow)
        {
            currRectangle.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);
            currRectangle.transform.GetChild(0).GetComponent<Renderer>().material = previewMaterial;

            if (Input.GetMouseButtonDown(0))
            {
                currRectangle.transform.GetChild(0).GetComponent<Renderer>().material = defaultMaterial;
                currRectangle.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();

                onPreviewFollow = false;
            
            }
        }
        
    }


    public GameObject circle;
    GameObject currCircle;
    bool onPreviewCircleFollow = false;

    public void createCircle()
    {
        currCircle = Instantiate(circle, player.transform.position + instanceOffset, Quaternion.identity);
        onPreviewCircleFollow = true;

    }

    public void onCirclePreviewFollow()
    {

        if (onPreviewCircleFollow)
        {
            currCircle.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);
           
            if (Input.GetMouseButtonDown(0))
            {
                currCircle.transform.GetChild(0).GetComponent<Shape>().settings.fillColor = ColorIndicator.Instance.color.ToColor();
                
                onPreviewCircleFollow = false;

            }
        }

    }


    public GameObject triangle;
    GameObject currTriangle;
    bool onPreviewTriangleFollow = false;

    public void createTriangle()
    {
        currTriangle = Instantiate(triangle, player.transform.position + instanceOffset, Quaternion.identity);
        onPreviewTriangleFollow = true;

    }

    public void onTrianglePreviewFollow()
    {

        if (onPreviewTriangleFollow)
        {
            currTriangle.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);

            if (Input.GetMouseButtonDown(0))
            {
                currTriangle.transform.GetChild(0).GetComponent<Shape>().settings.fillColor = ColorIndicator.Instance.color.ToColor();

                onPreviewTriangleFollow = false;

            }
        }

    }

    public GameObject polygone;
    GameObject currPolygone;
    bool onPreviewPolygoneFollow = false;

    public void createPolygone()
    {
        currPolygone = Instantiate(polygone, player.transform.position + instanceOffset, Quaternion.identity);
        onPreviewPolygoneFollow = true;

    }

    public void onPolygonePreviewFollow()
    {

        if (onPreviewPolygoneFollow)
        {
            currPolygone.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);

            if (Input.GetMouseButtonDown(0))
            {
                currPolygone.transform.GetChild(0).GetComponent<Shape>().settings.fillColor = ColorIndicator.Instance.color.ToColor();

                onPreviewPolygoneFollow = false;

            }
        }

    }


}
