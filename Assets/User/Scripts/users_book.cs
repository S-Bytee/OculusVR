using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using MongoDB.Bson.Serialization;
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
    GraphicRaycaster raycaster;
    String FriendEmail = "";
    
    void Awake()
     {
         // Get both of the components we need to do this
         this.raycaster = GetComponent<GraphicRaycaster>();
     }

    private void Start() {
         var docu = Mongo.getConnection().GetDatabase("SpatterDB").GetCollection<BsonDocument>("users").Find(_ => true).ToList();
        print(docu.Count);
        foreach (var doc in docu)
        {
            var copy = Instantiate(itemTemplate);
            print(doc.GetValue(2));
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

            //Check if the left Mouse button is clicked
         if (Input.GetKeyDown(KeyCode.Mouse0))
         {
             //Set up the new Pointer Event
             PointerEventData pointerData = new PointerEventData(EventSystem.current);
             List<RaycastResult> results = new List<RaycastResult>();
 
             //Raycast using the Graphics Raycaster and mouse click position
             pointerData.position = Input.mousePosition;
             this.raycaster.Raycast(pointerData, results);
 
             //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
             foreach (RaycastResult result in results)
             {

                 Debug.Log("Hit " + result.gameObject.name);
                 if(result.gameObject.name=="User_card(Clone)")
                 {
                     
                     hingeJoints = result.gameObject.GetComponentsInChildren<Component>();
                     foreach (Component joint in hingeJoints){

                        if(joint.name.Equals("user_email")){
                            FriendEmail = joint.GetComponent<Text>().text.Substring(8,joint.GetComponent<Text>().text.Length-8);
                        }

                        if(joint.name.Equals("user_username")){
                             String text = joint.GetComponent<Text>().text.Substring(0,joint.GetComponent<Text>().text.IndexOf("'"));
                             print(text);
                             getProjects(text);
                             var copy = Instantiate(project_template);
                                /* hingeJoints = copy.GetComponentsInChildren<Component>();
                                 print(hingeJoints.Length);
                                foreach (Component j in hingeJoints)
                                {
                                    print(j.name);
                                    if(j.name.Equals("Panel(Clone)"))
                                    DestroyImmediate(j);
                                }
                                copy.transform.parent = project_content.transform;*/
                             if(collectionNames.Count==0)
                             {
                                copy = Instantiate(project_template);
                                 hingeJoints = copy.GetComponentsInChildren<Component>();
                                foreach (Component j in hingeJoints)
                                {
                                    j.GetComponentInChildren<Text>().text = "No projects available";
                                }
                                copy.transform.parent = project_content.transform;
                             }
                             else{
                            foreach(var u in collectionNames)
                            {  
                                print(u);
                                copy = Instantiate(project_template);
                                print(collectionNames.Count);
                                hingeJoints = copy.GetComponentsInChildren<Component>();
                                foreach (Component j in hingeJoints)
                                {
                                    print(j.name);
                                    j.GetComponentInChildren<Text>().text = u;
                                }
                                copy.transform.parent=project_content.transform;
                            }
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

        var filter = Builders<BsonDocument>.Filter.Eq("user_email", PlayerPrefs.GetString("email"));
        
        var users = Mongo.getConnection().GetDatabase("SpatterDB").GetCollection<BsonDocument>("users").Find(filter).ToList();
        print(users.Count);
        foreach(var d in users)
        {
            BsonArray friendList = d.GetValue(9).AsBsonArray ;
           /* if(friendList.Count != 0)
            foreach(BsonDocument t in friendList )
            {
                print("hedhi loula " +t.GetValue(t.IndexOfName("email")));
            }*/
           // friends.Add(new BsonDocument{{"email",FriendEmail}});
            friendList.Add(new BsonDocument{{"email",FriendEmail}});
            BsonDocument data = new BsonDocument() ;
            data.AddRange(new BsonDocument{{"friends",friendList}});
            var update = Builders<BsonDocument>.Update.Push("friends",new BsonDocument{{"email",FriendEmail}});
            Mongo.getConnection().GetDatabase("SpatterDB").GetCollection<BsonDocument>("users").UpdateOneAsync(filter,update);
        }
            print("email : "+FriendEmail);
    }

    public void ReturnButton(){
        PlayerPrefs.SetString("scene","room_user");
        SceneManager.LoadScene("loading_screen");
    }
}
