using MongoDB.Bson;
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

    public GameObject sphere;
    List<GameObject> spheres;
    bool onDrag;

    Mongo mongo;
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        /*
        var document = new BsonDocument { { "student_id", 10000 } };
        Mongo.getDatabase().GetCollection<BsonDocument>("projects").InsertOneAsync(document);
        */

        spheres = new List<GameObject>();
        verts = new List<Vector3>();
        triangles = new List<int>();

        mesh = GetComponent<MeshFilter>().mesh;
        laserPointer = PhysicsPointer.Instance;

        GetComponent<MeshFilter>().mesh.Clear();

        verts.Add(new Vector3(1, 1, 5));
        verts.Add(new Vector3(1, 2, 0));
        verts.Add(new Vector3(1, 5, 10));
       // verts.Add(new Vector3(1, 1, 1));
        
        
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);


        triangles.Add(2);
        triangles.Add(1);
        triangles.Add(0);

        GetComponent<MeshFilter>().mesh.vertices = verts.ToArray();
        GetComponent<MeshFilter>().mesh.triangles = triangles.ToArray();
        GetComponent<MeshFilter>().mesh.RecalculateNormals();

        foreach (Vector3 ver in GetComponent<MeshFilter>().mesh.vertices)
        {
            spheres.Add(Instantiate(sphere, ver + transform.position, Quaternion.identity));
        }
   
    }

    // Update is called once per frame
    void Update()
    {

        if(laserPointer.hit.collider)
        {
            if(spheres.Count>0)
            {
                foreach (GameObject sGo in spheres)
                {
                    if(laserPointer.hit.collider.gameObject==sGo)
                    {
                        if(Input.GetMouseButton(0))
                        {
                            onDrag = true;

                            verts[spheres.IndexOf(sGo)] = laserPointer.CalculateEnd();


                        }

                    }
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                onDrag = false;
                GetComponent<MeshFilter>().mesh.vertices = verts.ToArray();
                GetComponent<MeshFilter>().mesh.RecalculateNormals();

            }
        }
        else
        {
            onDrag = false;
        }


        
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
