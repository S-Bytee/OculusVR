using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Photon.Pun;

public class Drawing3DMultiplayer : MonoBehaviourPunCallbacks
{


    PhysicsPointerMultiplayer laserInstance;


    public GameObject sphere;
    bool draw = false;
    // Start is called before the first frame update
    public string linePrefab;
    public GameObject currentLine = null;
    LineRenderer lineRenderer;
    Vector3 tempFingerPos;
    public List<Vector3> fingerPositions;
    const string MATERIALS_TEMP_PATH = "Assets/Drawing3D/Materials/MaterialsTemp/";


    void Start()
    {

       
        if(!photonView.IsMine) return ;
            laserInstance = GameObject.Find("PhysicsPointer").GetComponent<PhysicsPointerMultiplayer>();
        
        


        /*   if(GameObject.FindGameObjectWithTag("player") != null)
           {


           }*/
    }

    // Update is called once per frame
    void Update()
    {

        //if (!photonView.IsMine) return;
          



                drawing();

 



        /*   if (GameObject.FindGameObjectWithTag("player")!=null)
        {
          
            Debug.Log(laserInstance.hit.collider);
        }*/


        /* if(!laserInstance.hit.collider)
         {
             if (!laserInstance.onCollison) return;
             drawing();
         }*/

    }


    [PunRPC]
    public void drawing()
    {

        if(Input.GetMouseButtonDown(0))
        {
            photonView.RPC("createLine", RpcTarget.AllBuffered);
         //   createLine();
        }
        if (Input.GetMouseButton(0))
        {

            photonView.RPC("updateLine", RpcTarget.AllBuffered,PhysicsPointerMultiplayer.Instance.CalculateEnd());
            
        }

    }

    [PunRPC]
    public void createLine()
    {

        currentLine = PhotonNetwork.Instantiate(linePrefab, transform.position, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        
        if(ColorIndicator.Instance == null)
        {
        
            currentLine.GetComponent<Renderer>().material.color = Color.white;
        
        }
        else
        {
        
            currentLine.GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();
        
        }

        fingerPositions.Clear();
        fingerPositions.Add(PhysicsPointerMultiplayer.Instance.CalculateEnd());
        fingerPositions.Add(PhysicsPointerMultiplayer.Instance.CalculateEnd());
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);

    }


    [PunRPC]
    public void updateLine(Vector3 newPosition)
    {


        fingerPositions.Add(newPosition);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1,newPosition);

    }




}
