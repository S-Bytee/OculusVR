using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Drawing3DMultiplayer : MonoBehaviour
{
    PhysicsPointer laserInstance;

    public GameObject sphere;
    bool draw = false;
    // Start is called before the first frame update
    public GameObject linePrefab = null;
    public GameObject currentLine = null;
    LineRenderer lineRenderer;
    Vector3 tempFingerPos;
    public List<Vector3> fingerPositions;
    const string MATERIALS_TEMP_PATH = "Assets/Drawing3D/Materials/MaterialsTemp/";


    void Start()
    {
        
        laserInstance = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if(!laserInstance.onCollison)
        drawing();
    }

    public void drawing()
    {

        if(Input.GetMouseButtonDown(0))
        {
            createLine();
        }
        if (Input.GetMouseButton(0))
        {
            tempFingerPos = laserInstance.CalculateEnd();
       
            updateLine(laserInstance.CalculateEnd());

        }

    }


    public void createLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
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
        fingerPositions.Add(laserInstance.CalculateEnd());
        fingerPositions.Add(laserInstance.CalculateEnd());
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);

    }

    public void updateLine(Vector3 newPosition)
    {


        fingerPositions.Add(newPosition);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1,newPosition);


    }


    public void assignColorToInstance()
    {
      
    }



}
