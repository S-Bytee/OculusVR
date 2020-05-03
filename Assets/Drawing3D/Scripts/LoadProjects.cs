using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadProjects : MonoBehaviour
{

     public GameObject project;
     GameObject currProject;
     List<string> collectionNames = new List<string>();   

    // Start is called before the first frame update
    void Start()
    {

        instanciateProject();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void instanciateProject()
    {
        getAllProjects();

        for (int i =0;i<collectionNames.Count;i++)
        {
            
            currProject= Instantiate(project, Vector3.zero, Quaternion.identity);
            currProject.GetComponent<Button>().name = collectionNames.ElementAt(i);           
            currProject.transform.GetChild(0).GetComponent<Text>().text = collectionNames.ElementAt(i);
            currProject.transform.SetParent(transform.GetChild(0).GetChild(0).GetComponent<VerticalLayoutGroup>().transform, false);
            
        }


    }

    public void load(string x)
    {

    }


    public void getAllProjects()
    {
        foreach (var item in Mongo.getConnection().GetDatabase("SpatterProjects").ListCollectionsAsync().Result.ToListAsync<BsonDocument>().Result)
        {
            collectionNames.Add(item["name"].ToString());
        }

    }


}
