using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB;

public class Login : MonoBehaviour
{

    public GameObject input_email;
    public GameObject input_password;
    private string email;
    private string password;
    // Start is called before the first frame update
    void Start()
    {
        
         
    }

    // Update is called once per frame
    void Update()
    {
         email = input_email.GetComponent<InputField>().text;
         password = input_password.GetComponent<InputField>().text;
         if(Input.GetKeyDown(KeyCode.Tab)){changeInput();}
         if(Input.GetKeyDown(KeyCode.Return)){singin();}
        
    }

    public void singin(){
        print(email);
        var filter = Builders<BsonDocument>.Filter.Eq("user_email", email);
        var docu = Mongo.getConnection().GetDatabase("SpatterDB").GetCollection<BsonDocument>("users").Find(filter).ToList();
        foreach(var d in docu )
        {
            if(d.GetValue(d.IndexOfName("user_password")) == password )
            {
                print("success");
                PlayerPrefs.SetString("email",email);
                PlayerPrefs.SetString("username",d.GetValue(d.IndexOfName("user_username")).ToString());
                PlayerPrefs.SetString("createdAt",d.GetValue(d.IndexOfName("createdAt")).ToString());
                PlayerPrefs.SetString("last_login",d.GetValue(d.IndexOfName("last_login")).ToString());
                PlayerPrefs.SetString("scene","room_user");
                SceneManager.LoadScene("loading_screen");
            }
            else
            print("failure");
        }
        
    }

    void UpdateLogin()
    {
        PlayerPrefs.SetString("last_login",DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year+" "+DateTime.Now.Hour+":"+DateTime.Now.Minute);
        
    }

    public void changeInput()
    {
            if(input_email.GetComponent<InputField>().isFocused){
                input_password.GetComponent<InputField>().Select();
            }
    }
}
