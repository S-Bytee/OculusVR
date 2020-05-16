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
    string username;
    // Start is called before the first frame update
    void Start()
    {
        username = PlayerPrefs.GetString("username");
        instanciateProject();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void instanciateProject()
    {
        
        getAllProjects();

        for (int i = 0; i < collectionNames.Count; i++)
        {
        
            string collectionName = collectionNames.ElementAt(i).ToString().Split('_')[0];

            currProject = Instantiate(project, Vector3.zero, Quaternion.identity);
            currProject.GetComponent<Button>().name = collectionName;            
            currProject.transform.GetChild(0).GetComponent<Text>().text = collectionName;
            currProject.transform.SetParent(transform.GetChild(0).GetChild(0).GetComponent<VerticalLayoutGroup>().transform, false);
            
        }

    }

    public void load(string x)
    {

    }


    public void getAllProjects()
    {
        foreach (var item in Mongo.getConnection().GetDatabase(username).ListCollectionsAsync().Result.ToListAsync<BsonDocument>().Result)
        {
        
            if(!item["name"].ToString().Equals("Default"))
            collectionNames.Add(item["name"].ToString());
        
        }

    }


}
