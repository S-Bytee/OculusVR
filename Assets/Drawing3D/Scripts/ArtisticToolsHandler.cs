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
    public GameObject newPyramid;
    public GameObject newDonut;
    public GameObject newCone;
    public GameObject newTube;
    public GameObject newHemisphere;


    Vector3 instanceOffset;
    GameObject player;
    Vector3 offset;
    GameObject currInstance;
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
    
    public GameObject pyramidExample;
    GameObject currPyramidExample;
    bool pyramidExampleFollow = false;
    Vector3 pyramidInstancePos;


    public GameObject donutExample;
    GameObject currDonutExample;
    bool donutExampleFollow = false;
    Vector3 donutInstancePos;

    public GameObject coneExample;
    GameObject currConeExample;
    bool coneExampleFollow = false;
    Vector3 coneInstancePos;



    public GameObject tubeExample;
    GameObject currTubeExample;
    bool tubeExampleFollow = false;
    Vector3 tubeInstancePos;

    public GameObject hemisphereExample;
    GameObject currHemisphereExample;
    bool hemisphereExampleFollow = false;
    Vector3 hemisphereInstancePos;

    public Material previewMaterial;
    public Material defaultMaterial;

    // 2D declaratives //

    void Start()
    {

        laserInstance = PhysicsPointer.Instance;
        instanceOffset = new Vector3(0,0,10);

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<OculusRiftDetector>().ProjectType == ProjectType.DESKTOP)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject;

            }
            else if (GameObject.FindGameObjectWithTag("Player").GetComponent<OculusRiftDetector>().ProjectType == ProjectType.OCULUS)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;

            }
        }
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

        onPyramidExampleFollow();
        instanciatePyramid();

        onDonutExampleFollow();
        instanciateDonut();

        onConeExampleFollow();
        instanciateCone();

        onTubeExampleFollow();
        instanciateTube();

        onHemisphereExampleFollow();
        instanciateHemisphere();


        onRectanglePreviewFollow();
        onCirclePreviewFollow();
        onTrianglePreviewFollow();
        onPolygonePreviewFollow();


    }


    void onPyramidExampleFollow()
    {
        if (pyramidExampleFollow)
        {
            currPyramidExample.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);
            pyramidInstancePos = currPyramidExample.transform.position;
        }
        else
        {
            Destroy(currPyramidExample);

        }
    }

    void instanciatePyramid()
    {
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {

            if (laserInstance.hit.collider)
            {
                if (laserInstance.hit.collider.tag == "examplePyramidObject")
                {

                    currInstance = Instantiate(newPyramid, pyramidInstancePos, Quaternion.identity);
                    currInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
                    pyramidExampleFollow = false;
                }

            }


        }
    }

    public void createPyramid()
    {


        if (!pyramidExampleFollow)
        {

            currPyramidExample = Instantiate(pyramidExample, Vector3.zero, Quaternion.identity);

            pyramidExampleFollow = true;

        }


    }



    void onDonutExampleFollow()
    {
        if (donutExampleFollow)
        {
            currDonutExample.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);
            donutInstancePos = currDonutExample.transform.position;
        }
        else
        {
            Destroy(currDonutExample);

        }
    }

    void instanciateDonut()
    {
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {

            if (laserInstance.hit.collider)
            {
                if (laserInstance.hit.collider.tag == "exampleDonutObject")
                {

                    currInstance = Instantiate(newDonut, donutInstancePos, Quaternion.identity);
                    currInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
                    donutExampleFollow = false;
                }

            }


        }
    }

    public void createDonut()
    {


        if (!donutExampleFollow)
        {

            currDonutExample = Instantiate(donutExample, Vector3.zero, Quaternion.identity);

            donutExampleFollow = true;

        }


    }




    void onConeExampleFollow()
    {
        if (coneExampleFollow)
        {
            currConeExample.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);
            coneInstancePos = currConeExample.transform.position;
        }
        else
        {
            Destroy(currConeExample);

        }
    }

    void instanciateCone()
    {
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {

            if (laserInstance.hit.collider)
            {
                if (laserInstance.hit.collider.tag == "exampleConeObject")
                {

                    currInstance = Instantiate(newCone, coneInstancePos, Quaternion.identity);
                    currInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
                    coneExampleFollow = false;
                }

            }


        }
    }

    public void createCone()
    {

        if (!coneExampleFollow)
        {

            currConeExample = Instantiate(coneExample, Vector3.zero, Quaternion.identity);
            coneExampleFollow = true;

        }

    }


    void onTubeExampleFollow()
    {
        if (tubeExampleFollow)
        {
            currTubeExample.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);
            tubeInstancePos = currTubeExample.transform.position;
        }
        else
        {
            Destroy(currTubeExample);

        }
    }

    void instanciateTube()
    {
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {

            if (laserInstance.hit.collider)
            {
                if (laserInstance.hit.collider.tag == "exampleTubeObject")
                {

                    currInstance = Instantiate(newTube, tubeInstancePos, Quaternion.identity);
                    currInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
                    tubeExampleFollow = false;
                }

            }


        }
    }

    public void createTube()
    {

        if (!tubeExampleFollow)
        {

            currTubeExample = Instantiate(tubeExample, Vector3.zero, Quaternion.identity);
            tubeExampleFollow = true;

        }

    }



    void onHemisphereExampleFollow()
    {
        if (hemisphereExampleFollow)
        {
            currHemisphereExample.transform.position = laserInstance.DefaultEnd(laserInstance.defaultLength);
            hemisphereInstancePos = currHemisphereExample.transform.position;
        }
        else
        {
            Destroy(currHemisphereExample);

        }
    }

    void instanciateHemisphere()
    {
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {

            if (laserInstance.hit.collider)
            {
                if (laserInstance.hit.collider.tag == "exampleHemisphereObject")
                {

                    currInstance = Instantiate(newHemisphere, hemisphereInstancePos, Quaternion.identity);
                    currInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
                    hemisphereExampleFollow = false;
                }

            }


        }
    }

    public void createHemisphere()
    {

        if (!hemisphereExampleFollow)
        {

            currHemisphereExample = Instantiate(hemisphereExample, Vector3.zero, Quaternion.identity);
            hemisphereExampleFollow = true;

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
        
        
        if (!boxExampleFollow)
        {
            
            currboxExample = Instantiate(boxExample, Vector3.zero, Quaternion.identity);
            
            boxExampleFollow = true;

        }
     

    }

    public void instanciateCube()
    {


        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (laserInstance.hit.collider)
            {
                if (laserInstance.hit.collider.tag == "exampleCubeObject")
                {
                    currInstance = Instantiate(newCube, cubeInstancePos, Quaternion.identity);
                    currInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
                    boxExampleFollow = false;
                }

            }


        };
    }

    public void instanciateSphere()
    {


        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {

            if (laserInstance.hit.collider)
            {
                if (laserInstance.hit.collider.tag == "exampleSphereObject")
                {
                    currInstance = Instantiate(newSphere, sphereInstancePos, Quaternion.identity);
                    currInstance.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
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

            if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
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
           
            if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
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

            if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
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

            if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                currPolygone.transform.GetChild(0).GetComponent<Shape>().settings.fillColor = ColorIndicator.Instance.color.ToColor();

                onPreviewPolygoneFollow = false;

            }
        }

    }


}
