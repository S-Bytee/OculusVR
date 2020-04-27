using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB;

public class Signup : MonoBehaviour
{

    public GameObject input_email;
    public GameObject input_username;
    public GameObject input_password;
    public GameObject input_phonenumber;

    private string email;
    private string username;
    private string password;
    private string form;
    private bool ValidEmail = false ;
    private string phone_number;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){changeInput();}
        if(Input.GetKeyDown(KeyCode.Return)){Register();}
        username = input_username.GetComponent<InputField>().text;
        email = input_email.GetComponent<InputField>().text;
        password = input_password.GetComponent<InputField>().text;
        phone_number = input_phonenumber.GetComponent<InputField>().text;
    }

    public void Register()
    {
        if(verif())
        {
            print("Registration successful");
            BsonDocument user = new BsonDocument();
            user.Add(new BsonDocument{{"user_email", email}});
            user.Add(new BsonDocument{{"user_username", username}});
            user.Add(new BsonDocument{{"user_phonenumber", phone_number}});
            user.Add(new BsonDocument{{"user_password", password}});
            user.Add(new BsonDocument{{"createdAt",DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year}});
            user.Add(new BsonDocument{{"last_login",DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year+" "+DateTime.Now.Hour+":"+DateTime.Now.Minute}});
            user.AddRange(new BsonDocument{{"2D_projects",""}});
            user.AddRange(new BsonDocument{{"3D_projects",""}});
            user.AddRange(new BsonDocument{{"friends",""}});

            Mongo.getConnection().GetDatabase("SpatterDB").GetCollection<BsonDocument>("users").InsertOneAsync(user);
            print("success");
        }
    }

    public bool verif()
    {
        // Password RegEx & Validation
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMinimum8Chars = new Regex(@".{8,}");
        var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
        // Email Regex && Validation
        var email_regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");

        if(password!="" && email!="" && phone_number!="" && username != ""){
            if(!isValidated)
            return false;

            if(email_regex.IsMatch(email))
            return false;
            
            return true;
        }
        return false;
    }

    public void changeInput()
    {
            if(input_email.GetComponent<InputField>().isFocused){
                input_username.GetComponent<InputField>().Select();
            }
            if(input_username.GetComponent<InputField>().isFocused){
                input_phonenumber.GetComponent<InputField>().Select();
            }
            if(input_phonenumber.GetComponent<InputField>().isFocused){
                input_password.GetComponent<InputField>().Select();
            }
    }
}

