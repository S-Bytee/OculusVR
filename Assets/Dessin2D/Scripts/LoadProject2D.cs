using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadProject2D : MonoBehaviour
{
    public GameObject project;
    GameObject currProject;
    List<string> collectionNames = new List<string>();
    string username;

    void Start()
    {

        username = PlayerPrefs.GetString("username");
        instanciateProject();

    }
    public void instanciateProject()
    {
        getAllProjects();

        for (int i = 0; i < collectionNames.Count; i++)
        {
            string collectionName = collectionNames.ElementAt(i).ToString().Split('_')[0];

        if(collectionNames.ElementAt(i).ToString().Split('_')[1].ToString() == "2D")
            {
                currProject = Instantiate(project, Vector3.zero, Quaternion.identity);

                currProject.GetComponent<Button>().name = collectionName;

                currProject.transform.GetChild(0).GetComponent<Text>().text = collectionName;

                currProject.transform.SetParent(transform.GetChild(0).GetChild(0).GetComponent<VerticalLayoutGroup>().transform, false);

            }
        }


    }
    public void getAllProjects()
    {
        foreach (var item in Mongo.getConnection().GetDatabase(username).ListCollectionsAsync().Result.ToListAsync<BsonDocument>().Result)
        {
            if (!item["name"].ToString().Equals("Default"))
                collectionNames.Add(item["name"].ToString());
        }

    }
}
