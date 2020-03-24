using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Drawing3D : MonoBehaviour
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
            tempFingerPos = laserInstance.DefaultEnd(laserInstance.defaultLength);
       
             updateLine(laserInstance.DefaultEnd(laserInstance.defaultLength));

        }

    }


    public void createLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        
      
       currentLine.GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor(); 
        
        fingerPositions.Clear();
        fingerPositions.Add(laserInstance.DefaultEnd(laserInstance.defaultLength));
        fingerPositions.Add(laserInstance.DefaultEnd(laserInstance.defaultLength));
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
