using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class users_book : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemTemplate;
    public GameObject project_content;
    public GameObject project_template;
    public GameObject user_content;
    public GameObject text;
    public Component[] hingeJoints;
    List<string> collectionNames = new List<string>();
        
    private void Start() {
         var docu = Mongo.getConnection().GetDatabase("SpatterDB").GetCollection<BsonDocument>("users").Find(_ => true).ToList();
        print(docu.Count);
        foreach (var doc in docu)
        {
            var copy = Instantiate(itemTemplate);
            //print(doc.GetValue(2));
            copy.GetComponentInChildren<Text>().text="Username : "+ doc.GetValue(2);
            hingeJoints = copy.GetComponentsInChildren<Component>();
            foreach (Component joint in hingeJoints)
            {
                if(joint.name.Equals("user_username") && !doc.GetValue(2).Equals(""))
                    joint.GetComponent<Text>().text = doc.GetValue(2)+"'s artist card";
                if(joint.name.Equals("user_email") && !doc.GetValue(1).Equals(""))
                    joint.GetComponent<Text>().text = "email : "+ doc.GetValue(1);  
                if(joint.name.Equals("last_login") && !doc.GetValue(6).Equals(""))
                    joint.GetComponent<Text>().text = "Last Login : "+ doc.GetValue(6);  
            }
            copy.transform.parent=user_content.transform;
        }
    }

    private void Update() {
            if (Input.GetMouseButtonDown (0)) {    
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
            print("no");
             if (Physics.Raycast(ray, out hit,100)) {
                 // whatever tag you are looking for on your game object
                 print(hit.transform.name);
                 if(hit.collider.name == "user_content") {                           
                    hingeJoints =  hit.collider.GetComponentsInChildren<Component>();
                     foreach (Component joint in hingeJoints)
                    {
                     if(joint.name.Equals("user_username")){
                         getProjects(joint.GetComponent<Text>().text);
                         foreach(var u in collectionNames)
                         {  
                             print(u);
                            var copy = Instantiate(project_template);
                            hingeJoints = copy.GetComponentsInChildren<Component>();
                            foreach (Component j in hingeJoints)
                            {
                                j.GetComponent<Text>().text = u;
                            }
                            copy.transform.parent=project_content.transform;
                         }
                     }
                        
                    }            
                 }
                 
             }    
         }
    }


    public void getProjects(String username)
    {

        foreach (var item in Mongo.getConnection().GetDatabase(username).ListCollectionsAsync().Result.ToListAsync<BsonDocument>().Result)
        {
            if(!item["name"].ToString().Equals("Default"))
            collectionNames.Add(item["name"].ToString());
        }
    }
    public void AddButtonClick(){

        
    }

    public void ReturnButton(){
        PlayerPrefs.SetString("scene","room_user");
        SceneManager.LoadScene("loading_screen");
    }
}
