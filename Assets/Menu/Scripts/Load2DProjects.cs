using MongoDB.Bson;
using MongoDB.Driver;
using Shapes2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load2DProjects : MonoBehaviour
{
    public string username;
    List<Vector3> loadedPoints;
    public GameObject lineRendererLoaded;
    GameObject ProjectParent;
    List<String> ProjectNamesList;
    public GameObject spawnPosition;
    string currProjectName;
    // Start is called before the first frame update
    void Start()
    {
        ProjectNamesList = new List<string>();
        username = PlayerPrefs.GetString("username");
        PlayerPrefs.Save();

        loadedPoints = new List<Vector3>();

        //FetchFor2DProject("ffff_2D");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public string currentProjectName()
    {
        return PlayerPrefs.GetString("ProjectName");
    }
    public void loadLines()
    {

        var filter = Builders<BsonDocument>.Filter.Eq("type", "LineRenderer");
        var document = Mongo.getConnection().GetDatabase(username).GetCollection<BsonDocument>(currProjectName).Find(filter);
        Debug.Log("LoadedLines1");
        Debug.Log(currentProjectName());

        foreach (var doc in document.ToCursor().ToEnumerable())
        {
            GameObject go;
            go = Instantiate(lineRendererLoaded, Vector3.zero, Quaternion.identity);
            go.GetComponent<LineRenderer>().useWorldSpace = false;
            go.transform.SetParent(ProjectParent.transform);
            go.GetComponent<Renderer>().material.color = new Color(Convert.ToSingle(doc["Color"]["R"].AsDouble), Convert.ToSingle(doc["Color"]["G"].AsDouble), Convert.ToSingle(doc["Color"]["B"].AsDouble), Convert.ToSingle(doc["Color"]["A"].AsDouble));

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

        ProjectParent.transform.position = spawnPosition.transform.position;
        ProjectParent.transform.rotation= spawnPosition.transform.rotation;

    }

    public void FetchFor2DProject(string projectName)
    {

        currProjectName = projectName;
        ProjectParent = new GameObject();
        ProjectParent.tag = "InstanciatedProject";
        ProjectParent.transform.parent = transform;
        ProjectParent.name = projectName.Split('_')[0];
        loadLines();

    }




}
