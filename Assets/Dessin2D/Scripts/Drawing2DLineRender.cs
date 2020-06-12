using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing2DLineRender : MonoBehaviour
{
    PhysicsPointer laserInstance;

    public GameObject plan;
    bool draw = false;
    // Start is called before the first frame update
    public GameObject linePrefab = null;
    public GameObject currentLine = null;
    public GameObject CanvasDraw;
    LineRenderer lineRenderer;
    Vector3 tempFingerPos;
    public List<Vector3> fingerPositions;
    const string MATERIALS_TEMP_PATH = "Assets/Drawing3D/Materials/MaterialsTemp/";
    float defaultWidth = 0.5f;
    float middleWidth = 0.5f;
    Mesh mesh;
    MeshCollider meshCollider;
    void Start()
    {
        laserInstance = PhysicsPointer.Instance;
        plan = GameObject.FindGameObjectWithTag("Plan");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        //if (laserInstance.hit.collider)
       if( laserInstance.onCollison)
        {
            //Debug.Log(laserInstance.hit.collider.gameObject);

            if (laserInstance.hit.collider.gameObject == plan) {
                Debug.Log("************************");
               drawing();
            }
        } 
        

    }
   

    public void drawing()
    {

        if (Input.GetMouseButtonDown(0))
        {
            createLine();

        }

        if (Input.GetMouseButton(0))
        {
            tempFingerPos = laserInstance.CalculateEnd();

            updateLine(laserInstance.CalculateEnd()+new Vector3(0,0,-0.3f));

        }

        if (Input.GetMouseButtonUp(0))
        {

            if (lineRenderer != null)
            {

                mesh = new Mesh();
                lineRenderer.BakeMesh(mesh, true);
                MeshCollider meshCollider = lineRenderer.gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = mesh;
                lineRenderer.gameObject.GetComponent<MeshFilter>().mesh = mesh;

            }

        }

    }


    public void createLine()
    {

        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();


        if (lineRenderer) lineRenderer.widthCurve = new AnimationCurve(new Keyframe(0, defaultWidth), new Keyframe(0.5f, middleWidth), new Keyframe(1, defaultWidth));


        if (ColorIndicator.Instance == null)
        {

            currentLine.GetComponent<Renderer>().material.color = new Color(250, 65, 204);

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
        if (lineRenderer != null)
        {


            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);

        }


    }


    public void updateLineWidth(float value)
    {


        defaultWidth = value / 100 * 0.5f;

    }

    public void updateMiddleWidth(float value)
    {
        middleWidth = value / 100;
    }
    public void hideMenu()
    { if (CanvasDraw != null)
        {
            Debug.Log("moved");
            bool isActive = CanvasDraw.activeSelf;
            CanvasDraw.SetActive(!isActive);
        }

        Debug.Log("not moved");
    }


}
