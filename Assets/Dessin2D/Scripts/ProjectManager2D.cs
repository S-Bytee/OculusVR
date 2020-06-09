using MongoDB.Bson;
using MongoDB.Driver;
using Shapes2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectManager2D : MonoBehaviour
{

    List<Vector3> pointsList;
    public GameObject lineRendererLoaded;
    List<Vector3> loadedPoints;
    bool ok = false;
    public GameObject cubeLoaded;
    public GameObject sphereLoaded;
    public GameObject rectangleLoaded;
    public GameObject triangleLoaded;
    public GameObject circleLoaded;
    public GameObject polygoneLoaded;

    public GameObject CanvasDraw;
    public GameObject CanvasHome;



    public GameObject player;
    public GameObject WheelCanvas;
    public string project_name;
    public string new_project_name;
    public string username;





  

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerPrefs.SetString("ProjectName", "");
        
        username = PlayerPrefs.GetString("username");
        PlayerPrefs.Save();


    }



    void Start()
    {
        pointsList = new List<Vector3>();
        loadedPoints = new List<Vector3>();
        
       

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            //loadLines();
            //loadObjects();
        }

    }


    public void saveLines()
    {
        BsonDocument documentGlobal;
        List<BsonDocument> docs = new List<BsonDocument>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("lineRenderer"))
        {

            documentGlobal = new BsonDocument();

            var documentId = new BsonDocument { { "instanceID", go.GetInstanceID() } };

            var documentType = new BsonDocument { { "type", "LineRenderer" } };
            var documentColors = new BsonDocument { { "R", go.GetComponent<Renderer>().material.GetColor("_TintColor").r }, { "G", go.GetComponent<Renderer>().material.GetColor("_TintColor").g }, { "B", go.GetComponent<Renderer>().material.GetColor("_TintColor").b }, { "A", go.GetComponent<Renderer>().material.GetColor("_TintColor").a } };
            var documentPoints = new BsonDocument();


            for (int i = 0; i < go.GetComponent<LineRenderer>().positionCount - 1; i++)
            {
                var docu = new BsonDocument { { "x", go.GetComponent<LineRenderer>().GetPosition(i).x }, { "y", go.GetComponent<LineRenderer>().GetPosition(i).y }, { "z", go.GetComponent<LineRenderer>().GetPosition(i).z } };
                Dictionary<string, BsonDocument> p = new Dictionary<string, BsonDocument>();
                p.Add(i.ToString(), docu);
                documentPoints.Add(p);

            }

            documentGlobal.Add(documentId);
            documentGlobal.Add(documentType);
            documentGlobal.Add(new BsonDocument() { { "Color", documentColors } });
            documentGlobal.Add(new BsonDocument() { { "Points", documentPoints } });

            docs.Add(documentGlobal);
        }

        foreach (BsonDocument d in docs)
        {

            Mongo.getConnection().GetDatabase(username).GetCollection<BsonDocument>(currentProjectName()).InsertOneAsync(d);

        }


    }

    public void saveObjects()
    {
        BsonDocument documentGlobal;
        List<BsonDocument> docs = new List<BsonDocument>();

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("object"))
        {
            if (go.transform.childCount > 0)
            {
                switch (go.transform.GetChild(0).name)
                {
                    case "cube":
                        {
                            documentGlobal = new BsonDocument();
                            var documentId = new BsonDocument { { "InstanceID", go.GetInstanceID() } };
                            var documentType = new BsonDocument { { "Type", "Cube" } };

                            var documentColors = new BsonDocument { { "R", go.transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color").r }, { "G", go.transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color").g }, { "B", go.transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color").b }, { "A", go.transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color").a } };

                            var documentPosition = new BsonDocument { { "x", go.transform.GetChild(0).position.x }, { "y", go.transform.GetChild(0).position.y }, { "z", go.transform.GetChild(0).position.z } };
                            var documentRotation = new BsonDocument { { "x", go.transform.GetChild(0).rotation.x }, { "y", go.transform.GetChild(0).rotation.y }, { "z", go.transform.GetChild(0).rotation.z } };
                            var documentScale = new BsonDocument { { "x", go.transform.GetChild(0).localScale.x }, { "y", go.transform.GetChild(0).localScale.y }, { "z", go.transform.GetChild(0).localScale.z } };

                            documentGlobal.Add(documentId);
                            documentGlobal.Add(documentType);
                            documentGlobal.Add(new BsonDocument() { { "Color", documentColors } });
                            documentGlobal.Add(new BsonDocument() { { "Position", documentPosition }, { "Rotation", documentRotation }, { "Scale", documentScale } });

                            docs.Add(documentGlobal);

                            break;
                        }
                    case "sphere":
                        {
                            documentGlobal = new BsonDocument();
                            var documentId = new BsonDocument { { "InstanceID", go.GetInstanceID() } };
                            var documentType = new BsonDocument { { "type", "Sphere" } };

                            var documentColors = new BsonDocument { { "R", go.transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color").r }, { "G", go.transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color").g }, { "B", go.transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color").b }, { "A", go.transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color").a } };

                            var documentPosition = new BsonDocument { { "x", go.transform.GetChild(0).position.x }, { "y", go.transform.GetChild(0).position.y }, { "z", go.transform.GetChild(0).position.z } };
                            var documentRotation = new BsonDocument { { "x", go.transform.GetChild(0).rotation.x }, { "y", go.transform.GetChild(0).rotation.y }, { "z", go.transform.GetChild(0).rotation.z } };
                            var documentScale = new BsonDocument { { "x", go.transform.GetChild(0).localScale.x }, { "y", go.transform.GetChild(0).localScale.y }, { "z", go.transform.GetChild(0).localScale.z } };

                            documentGlobal.Add(documentId);
                            documentGlobal.Add(documentType);
                            documentGlobal.Add(new BsonDocument() { { "Color", documentColors } });
                            documentGlobal.Add(new BsonDocument() { { "Position", documentPosition }, { "Rotation", documentRotation }, { "Scale", documentScale } });

                            docs.Add(documentGlobal);

                            break;
                        }
                    case "triangle":
                        {

                            documentGlobal = new BsonDocument();
                            var documentId = new BsonDocument { { "InstanceID", go.GetInstanceID() } };
                            var documentType = new BsonDocument { { "type", "Triangle" } };

                            var documentColors = new BsonDocument { { "R", go.transform.GetChild(0).GetComponent<Shape>().settings.fillColor.r }, { "G", go.transform.GetChild(0).GetComponent<Shape>().settings.fillColor.g }, { "B", go.transform.GetChild(0).GetComponent<Shape>().settings.fillColor.b }, { "A", go.transform.GetChild(0).GetComponent<Shape>().settings.fillColor.a } };

                            var documentPosition = new BsonDocument { { "x", go.transform.GetChild(0).position.x }, { "y", go.transform.GetChild(0).position.y }, { "z", go.transform.GetChild(0).position.z } };
                            var documentRotation = new BsonDocument { { "x", go.transform.GetChild(0).rotation.x }, { "y", go.transform.GetChild(0).rotation.y }, { "z", go.transform.GetChild(0).rotation.z } };
                            var documentScale = new BsonDocument { { "x", go.transform.GetChild(0).localScale.x }, { "y", go.transform.GetChild(0).localScale.y }, { "z", go.transform.GetChild(0).localScale.z } };

                            documentGlobal.Add(documentId);
                            documentGlobal.Add(documentType);
                            documentGlobal.Add(new BsonDocument() { { "Color", documentColors } });
                            documentGlobal.Add(new BsonDocument() { { "Position", documentPosition }, { "Rotation", documentRotation }, { "Scale", documentScale } });

                            docs.Add(documentGlobal);


                            break;
                        }
                   





                }
            }



        }


        foreach (BsonDocument d in docs)
        {

            Mongo.getConnection().GetDatabase(username).GetCollection<BsonDocument>(currentProjectName()).InsertOneAsync(d);

        }
    }


    public void loadLines()
    {

        var filter = Builders<BsonDocument>.Filter.Eq("type", "LineRenderer");
        var document = Mongo.getConnection().GetDatabase(username).GetCollection<BsonDocument>(currentProjectName()+"_2D").Find(filter);
        Debug.Log("LoadedLines1");
        Debug.Log(currentProjectName());

        foreach (var doc in document.ToCursor().ToEnumerable())
        {
            GameObject go;
            go = Instantiate(lineRendererLoaded, Vector3.zero, Quaternion.identity);
            go.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(Convert.ToSingle(doc["Color"]["R"].AsDouble), Convert.ToSingle(doc["Color"]["G"].AsDouble), Convert.ToSingle(doc["Color"]["B"].AsDouble), Convert.ToSingle(doc["Color"]["A"].AsDouble)));

            loadedPoints.Clear();

            for (int i = 0; i < doc["Points"].AsBsonDocument.ElementCount; i++)
            {

                loadedPoints.Add(new Vector3(Convert.ToSingle(doc["Points"][i.ToString()]["x"].AsDouble), Convert.ToSingle(doc["Points"][i.ToString()]["y"].AsDouble), Convert.ToSingle(doc["Points"][i.ToString()]["z"].AsDouble)));
            }

            if (loadedPoints.ToArray().Length >= 2)
            {
                go.GetComponent<LineRenderer>().SetPosition(0, loadedPoints.ToArray()[0]);
                go.GetComponent<LineRenderer>().SetPosition(1, loadedPoints.ToArray()[1]);

                for (int i = 2; i < loadedPoints.ToArray().Length; i++)
                {
                    go.GetComponent<LineRenderer>().positionCount++;
                    go.GetComponent<LineRenderer>().SetPosition(i, loadedPoints.ToArray()[i]);
                    Debug.Log("LoadedLines2");
                }
            }


        }

    }

    public void loadObjects()
    {

        //Loading cubes

        var cubesFilter = Builders<BsonDocument>.Filter.Eq("Type", "Cube");
        var cubeDocuments = Mongo.getConnection().GetDatabase(username).GetCollection<BsonDocument>(currentProjectName()).Find(cubesFilter);
        foreach (var doc in cubeDocuments.ToCursor().ToEnumerable())
        {
            GameObject go;
            Vector3 position = new Vector3(Convert.ToSingle(doc["Position"]["x"]), Convert.ToSingle(doc["Position"]["y"]), Convert.ToSingle(doc["Position"]["z"]));
            Vector3 rotation = new Vector3(Convert.ToSingle(doc["Rotation"]["x"]), Convert.ToSingle(doc["Rotation"]["y"]), Convert.ToSingle(doc["Rotation"]["z"]));
            Vector3 scale = new Vector3(Convert.ToSingle(doc["Scale"]["x"]), Convert.ToSingle(doc["Scale"]["y"]), Convert.ToSingle(doc["Scale"]["z"]));

            go = Instantiate(cubeLoaded, position, Quaternion.identity);
            go.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(Convert.ToSingle(doc["Color"]["R"].AsDouble), Convert.ToSingle(doc["Color"]["G"].AsDouble), Convert.ToSingle(doc["Color"]["B"].AsDouble), Convert.ToSingle(doc["Color"]["A"].AsDouble)));
            go.transform.rotation = Quaternion.Euler(rotation);
            go.transform.localScale = scale;

        }

        //Loading shperes

        var shpereFilter = Builders<BsonDocument>.Filter.Eq("type", "Sphere");
        var shpereDocuments = Mongo.getConnection().GetDatabase(username).GetCollection<BsonDocument>(currentProjectName()).Find(shpereFilter);
        foreach (var doc in shpereDocuments.ToCursor().ToEnumerable())
        {
            GameObject go;
            Vector3 position = new Vector3(Convert.ToSingle(doc["Position"]["x"]), Convert.ToSingle(doc["Position"]["y"]), Convert.ToSingle(doc["Position"]["z"]));
            Vector3 rotation = new Vector3(Convert.ToSingle(doc["Rotation"]["x"]), Convert.ToSingle(doc["Rotation"]["y"]), Convert.ToSingle(doc["Rotation"]["z"]));
            Vector3 scale = new Vector3(Convert.ToSingle(doc["Scale"]["x"]), Convert.ToSingle(doc["Scale"]["y"]), Convert.ToSingle(doc["Scale"]["z"]));

            go = Instantiate(sphereLoaded, position, Quaternion.identity);
            go.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(Convert.ToSingle(doc["Color"]["R"].AsDouble), Convert.ToSingle(doc["Color"]["G"].AsDouble), Convert.ToSingle(doc["Color"]["B"].AsDouble), Convert.ToSingle(doc["Color"]["A"].AsDouble)));
            go.transform.rotation = Quaternion.Euler(rotation);
            go.transform.localScale = scale;

        }



        //Loading triangle

        var triangleFilter = Builders<BsonDocument>.Filter.Eq("type", "Triangle");
        var triangleDocuments = Mongo.getConnection().GetDatabase(username).GetCollection<BsonDocument>(currentProjectName()).Find(triangleFilter);
        foreach (var doc in triangleDocuments.ToCursor().ToEnumerable())
        {
            GameObject go;
            Vector3 position = new Vector3(Convert.ToSingle(doc["Position"]["x"]), Convert.ToSingle(doc["Position"]["y"]), Convert.ToSingle(doc["Position"]["z"]));
            Vector3 rotation = new Vector3(Convert.ToSingle(doc["Rotation"]["x"]), Convert.ToSingle(doc["Rotation"]["y"]), Convert.ToSingle(doc["Rotation"]["z"]));
            Vector3 scale = new Vector3(Convert.ToSingle(doc["Scale"]["x"]), Convert.ToSingle(doc["Scale"]["y"]), Convert.ToSingle(doc["Scale"]["z"]));

            go = Instantiate(triangleLoaded, position, Quaternion.identity);

            go.transform.GetChild(0).GetComponent<Shape>().settings.fillColor = new Color(Convert.ToSingle(doc["Color"]["R"].AsDouble), Convert.ToSingle(doc["Color"]["G"].AsDouble), Convert.ToSingle(doc["Color"]["B"].AsDouble), Convert.ToSingle(doc["Color"]["A"].AsDouble));
            go.transform.rotation = Quaternion.Euler(rotation);
            go.transform.localScale = scale;
        }


       
    }



    public void newProjectName(string newProj)
    {
        new_project_name = newProj;

        PlayerPrefs.SetInt("ProjectCreationError", 0);
        PlayerPrefs.Save();


    }











    public void createNewProject()
    {

        if (new_project_name.Length > 0)
        {

            if (!collectionExist(new_project_name))
            {
                new_project_name = new_project_name + "_2D";
                Mongo.getConnection().GetDatabase(username).CreateCollection(new_project_name);
                project_name = new_project_name;
                PlayerPrefs.SetString("ProjectName", new_project_name);
                PlayerPrefs.Save();
                startNewProject();
            }
            else
            {

                PlayerPrefs.SetInt("ProjectCreationError", 2);
                PlayerPrefs.Save();

            }

        }
        else
        {
            PlayerPrefs.SetInt("ProjectCreationError", 1);
            PlayerPrefs.Save();
        }

    }

    public bool collectionExist(string collection_name)
    {
        var filter = new BsonDocument("name", collection_name);
        var options = new ListCollectionNamesOptions { Filter = filter };
        return Mongo.getConnection().GetDatabase(username).ListCollectionNames(options).Any();
    }


    public String currentProjectName()
    {
        return PlayerPrefs.GetString("ProjectName");
    }



    public void startNewProject()
    {

       

    }

    public void saveProject()
    {

        saveLines();
       
      //  saveObjects();

    }


    public void loadProjects()
    {
        loadLines();
        CanvasDraw.SetActive(true);
        CanvasHome.SetActive(false);
        Debug.Log("ok");
        //loadObjects();
    }

   



}
