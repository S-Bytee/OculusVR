using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{

    List<Vector3> verts;
    List<int> triangles;
    Mesh mesh;
    int x = 0;
    int restOfDiv;
    PhysicsPointer laserPointer;

    // Start is called before the first frame update
    void Start()
    {
        
        verts = new List<Vector3>();
        triangles = new List<int>();



        mesh = GetComponent<MeshFilter>().mesh;
        laserPointer = PhysicsPointer.Instance;

        GetComponent<MeshFilter>().mesh.Clear();

        verts.Add(new Vector3(1, 0, 0));
        verts.Add(new Vector3(1, 1, 0));
        verts.Add(new Vector3(1, 0, 1));
        verts.Add(new Vector3(1, 1, 1));
        
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);
        
        triangles.Add(2);
        triangles.Add(1);
        triangles.Add(0);
        

        GetComponent<MeshFilter>().mesh.vertices = verts.ToArray();
        GetComponent<MeshFilter>().mesh.triangles = triangles.ToArray() ;
        GetComponent<MeshFilter>().mesh.RecalculateNormals();


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetMouseButton(0))
        {

            x++;
            verts.Add(laserPointer.DefaultEnd(laserPointer.defaultLength));
            triangles.Add(x);

        }
        else if(Input.GetMouseButtonUp(0))
        {
         
            //Debug.Log(x);
            if(x%3!=0)
            {
                restOfDiv = 3 - (triangles.Count % 3);
                Debug.Log(restOfDiv);
                for (int i = 1; i <= restOfDiv; i++)
                {
                    triangles.Add(0);
                }
                //Debug.Log(triangles.Count);
                for (int i = 0; i <= triangles.Count; i++)
                {
                    
                    Debug.Log(triangles.ToArray()[i]);
                
                }
            }

            mesh.vertices = verts.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.RecalculateNormals();

        }*/

    }



}
