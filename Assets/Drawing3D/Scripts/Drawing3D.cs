using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;

public class Drawing3D : MonoBehaviour
{
    PhysicsPointer laserInstance;

    public GameObject sphere;
    bool draw = false;
    // Start is called before the first frame update
    public GameObject linePrefab = null;
    public GameObject currentLine = null;
    LineRenderer lineRenderer;
    public List<Vector3> fingerPositions;
    const string MATERIALS_TEMP_PATH = "Assets/Drawing3D/Materials/MaterialsTemp/";
    float defaultWidth=0.5f;
    float middleWidth=0.5f;
    Mesh mesh;
    MeshCollider meshCollider;
    string[] DrawingExceptions = {"wheels","gizmo","artisticTools"};
    void Start()
    {

        laserInstance = PhysicsPointer.Instance;

    }

    // Update is called once per frame
 
    private void FixedUpdate()
    {
            drawing();
    }

    public void drawing()
    {/*
        if (Input.GetMouseButtonDown(0))
        {
            if(laserInstance.onCollison)
            {
                if (!DrawingExceptions.Contains(laserInstance.hit.collider.tag))
                    createLine();
            }
            else
            {
                createLine();
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (laserInstance.onCollison)
            {
                if(!DrawingExceptions.Contains(laserInstance.hit.collider.tag))
                    updateLine(laserInstance.hit.point);
            }
            else
            {
                updateLine(laserInstance.DefaultEnd(laserInstance.defaultLength));
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (lineRenderer != null)
            {
                mesh = new Mesh();
                lineRenderer.BakeMesh(mesh,true);
                MeshCollider meshCollider = lineRenderer.gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = mesh;
                lineRenderer.gameObject.GetComponent<MeshFilter>().mesh = mesh;

                UndoRedo.Instance.AddChangementToUndo(new Changement(currentLine.GetInstanceID(), currentLine, currentLine.GetComponent<Renderer>().material.GetColor("_TintColor"), ChangementType.INSTANCIATE_LINERENDERER));

            }
        }
        */

        if (Input.GetMouseButtonDown(0))
        {
            
                createLine();
            
        }
        else if (Input.GetMouseButton(0))
        {
            
                updateLine(laserInstance.DefaultEnd(laserInstance.defaultLength));
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (lineRenderer != null)
            {
                mesh = new Mesh();
                lineRenderer.BakeMesh(mesh, true);
                MeshCollider meshCollider = lineRenderer.gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = mesh;
                lineRenderer.gameObject.GetComponent<MeshFilter>().mesh = mesh;

                UndoRedo.Instance.AddChangementToUndo(new Changement(currentLine.GetInstanceID(), currentLine, currentLine.GetComponent<Renderer>().material.GetColor("_TintColor"), ChangementType.INSTANCIATE_LINERENDERER));

            }
        }


    }
    private void LateUpdate()
    {
        VerifyForMeshes();
    }

    public void VerifyForMeshes()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("lineRenderer"))
        {
            if(go.GetComponent<LineRenderer>())
            {
                LineRenderer LR = go.GetComponent<LineRenderer>();
                if(LR.GetComponent<MeshFilter>().mesh != null)
                {
                    mesh = new Mesh();
                    LR.BakeMesh(mesh,false);
                    MeshCollider meshCollider = LR.gameObject.AddComponent<MeshCollider>();
                    meshCollider.sharedMesh = mesh;
                    LR.gameObject.GetComponent<MeshFilter>().mesh = mesh;

                }

            }


        }
    }
    public void createLine()
    {

        currentLine = Instantiate(linePrefab);
        currentLine.name = currentLine.GetInstanceID().ToString();
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        
        if (lineRenderer) lineRenderer.widthCurve = new AnimationCurve(new Keyframe(0, defaultWidth), new Keyframe(0.5f, middleWidth), new Keyframe(1, defaultWidth));

        if (ColorIndicator.Instance == null)
        {
        
            currentLine.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(250, 65, 204));
        
        }
        else
        {
        
            currentLine.GetComponent<Renderer>().material.SetColor("_TintColor",ColorIndicator.Instance.color.ToColor());
        
        }

        fingerPositions.Clear();
        fingerPositions.Add(laserInstance.CalculateEnd());
        fingerPositions.Add(laserInstance.CalculateEnd());
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
    }

    public void updateLine(Vector3 newPosition)
    {
        if(lineRenderer != null)
        {

            fingerPositions.Add(newPosition);           
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);

        }
       
    }


    public void updateLineWidth(float value)
    {
        
        defaultWidth = value / 100;
        
    }

    public void updateMiddleWidth(float value)
    {
        middleWidth = value / 100;
    }



}
