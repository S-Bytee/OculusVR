using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProject : MonoBehaviour
{

    List<Vector3> pointsList;
    public LineRenderer lineRendererLoaded;
    public LineRenderer currLine ;
    List<Vector3> loadedPoints;
    bool ok= false;
    // Start is called before the first frame update
    void Start()
    {
        pointsList = new List<Vector3>();
        loadedPoints = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            //saveLines();
            loadLines();

        }

    }


    public void saveLines()
    {
        BsonDocument documentGlobal ;
        List<BsonDocument> docs = new List<BsonDocument>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("lineRenderer"))
        {

             documentGlobal = new BsonDocument();

            var documentId = new BsonDocument { { "instanceID", go.GetInstanceID() }};

            var documentType = new BsonDocument { { "type", "LineRenderer" } };
            var documentColors = new BsonDocument { { "R", go.GetComponent<Renderer>().material.color.r}, { "G", go.GetComponent<Renderer>().material.color.g },{ "B", go.GetComponent<Renderer>().material.color.b }, { "A", go.GetComponent<Renderer>().material.color.a } } ;
            var documentPoints = new BsonDocument();

          
            for(int i = 0;i<go.GetComponent<LineRenderer>().positionCount-1; i++)
            {
                var docu = new BsonDocument { { "x", go.GetComponent<LineRenderer>().GetPosition(i).x }, { "y", go.GetComponent<LineRenderer>().GetPosition(i).y }, { "z", go.GetComponent<LineRenderer>().GetPosition(i).z } };
                Dictionary<string, BsonDocument> p = new Dictionary<string, BsonDocument>();
                p.Add(i.ToString(), docu);
                documentPoints.Add(p);

            }

            documentGlobal.Add(documentId);
            documentGlobal.Add(documentType);
            documentGlobal.Add(new BsonDocument() { { "Color", documentColors } });
            documentGlobal.Add(new BsonDocument() { {"Points", documentPoints } });

            docs.Add(documentGlobal);
        } 
        
        foreach(BsonDocument d in docs)
        {
            Mongo.getConnection().GetDatabase("SpatterDB").GetCollection<BsonDocument>("projects").InsertOneAsync(d);

        }







    }

    public void loadLines()
    {

        var filter = Builders<BsonDocument>.Filter.Eq("type", "LineRenderer");
        var document = Mongo.getConnection().GetDatabase("SpatterDB").GetCollection<BsonDocument>("projects").Find(filter);


        foreach (var doc in document.ToCursor().ToEnumerable())
        {
            GameObject go = new GameObject();
            go.AddComponent<LineRenderer>();
            go.GetComponent<Renderer>().material.color = new Color(Convert.ToSingle(doc["Color"]["R"].AsDouble),Convert.ToSingle(doc["Color"]["G"].AsDouble),Convert.ToSingle(doc["Color"]["B"].AsDouble),Convert.ToSingle(doc["Color"]["A"].AsDouble));
            loadedPoints.Clear();
            
            for (int i =0; i< doc["Points"].AsBsonDocument.ElementCount; i++)
            {

                loadedPoints.Add(new Vector3(Convert.ToSingle(doc["Points"][i.ToString()]["x"].AsDouble), Convert.ToSingle(doc["Points"][i.ToString()]["y"].AsDouble), Convert.ToSingle(doc["Points"][i.ToString()]["z"].AsDouble)));
                
            }

            go.GetComponent<LineRenderer>().SetPosition(0, loadedPoints.ToArray()[0]);
            go.GetComponent<LineRenderer>().SetPosition(1, loadedPoints.ToArray()[1]);
            for (int i =2; i<loadedPoints.ToArray().Length;i++)
            {
                go.GetComponent<LineRenderer>().positionCount++;
                go.GetComponent<LineRenderer>().SetPosition(i, loadedPoints.ToArray()[i]);
            }

            //Debug.Log(loadedPoints.Count);

        }

        /*
        document.ForEachAsync(doc => {


            //Debug.Log();

            for (int i = 0;i< doc.GetValue("Points").AsBsonDocument.ElementCount; i++ )
            {
                double x = doc.GetValue("Points")[i.ToString()]["x"].AsDouble;
                double y = doc.GetValue("Points")[i.ToString()]["y"].AsDouble;
                double z = doc.GetValue("Points")[i.ToString()]["z"].AsDouble;




    this.loadedPoints.Add(new Vector3(Convert.ToSingle(x), Convert.ToSingle(y), Convert.ToSingle(z)));
                
            }
            
            Debug.Log(loadedPoints.Count);
        
        });
       */
        /*           
          */
        /*
        */
    }

}
