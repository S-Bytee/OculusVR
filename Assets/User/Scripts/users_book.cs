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
    public GameObject content;
    public GameObject text;
    public Component[] hingeJoints;

        
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
                    joint.GetComponent<Text>().text = "Username : "+ doc.GetValue(2);
                if(joint.name.Equals("user_email") && !doc.GetValue(1).Equals(""))
                    joint.GetComponent<Text>().text = "email : "+ doc.GetValue(1);  
                if(joint.name.Equals("last_login") && !doc.GetValue(6).Equals(""))
                    joint.GetComponent<Text>().text = "Last Login : "+ doc.GetValue(6);  
            }
            copy.transform.parent=content.transform;
        }
    }

    private void Update() {
            
    }

    public void AddButtonClick(){

        
    }

    public void ReturnButton(){
        PlayerPrefs.SetString("scene","room_user");
        SceneManager.LoadScene("loading_screen");
    }
}
