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

public class Signup : MonoBehaviour
{

    public Component[] hingeJoints;
    public GameObject popup;
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
    PhysicsPointer laserPointer;

    // Start is called before the first frame update
    void Start()
    {
        laserPointer = PhysicsPointer.Instance;
        // GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
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
        if (laserPointer.hit.collider && Input.GetMouseButtonDown(0))
        {
            if (laserPointer.hit.collider.gameObject == GameObject.Find("register_button")) { Register(); }
        }
    }

    public void Register()
    {
        if(verif())
        {
            print("Registration successful");
             BsonDocument user = new BsonDocument();
            user.Add(new BsonDocument { { "user_email", email } });
            user.Add(new BsonDocument { { "user_username", username } });
            user.Add(new BsonDocument { { "user_password", password } });
            user.Add(new BsonDocument { { "createdAt", DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year } });
            user.Add(new BsonDocument { { "last_login", DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute } });

            user.AddRange(new BsonDocument{{"2D_projects",""}});
            user.AddRange(new BsonDocument{{"3D_projects",""}});
            user.AddRange(new BsonDocument{{"friends",new BsonArray{
                new BsonDocument{{"email","email"}}
            }
            }});
            PlayerPrefs.SetString("email",email);
            PlayerPrefs.SetString("username",username);
            PlayerPrefs.SetString("createdAt",DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year);
            PlayerPrefs.SetString("last_login",DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year+" "+DateTime.Now.Hour+":"+DateTime.Now.Minute);
            PlayerPrefs.SetString("scene","room_user");
            SceneManager.LoadScene("loading_screen");

            Mongo.getConnection().GetDatabase(username).GetCollection<BsonDocument>("Default").InsertOneAsync(new BsonDocument { });
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
        print("passworld is "+isValidated);
        // Email Regex && Validation
        var email_regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        print("email is"+email_regex.IsMatch(email));
        if(password!="" && email!="" && phone_number!="" && username != ""){

            
            if(!email_regex.IsMatch(email))
            {
                openPopup(2);
                return false;
            }
            if(!isValidated)
            {
                openPopup(1);
                return false;
            }

            
            return true;
        }else{openPopup(3);
        return false;}
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


    public void openPopup(int i)
    {
        String body ="";
        switch(i)
        {
            case 1 : body = "password minimum length must be 8 characters,have at least 1 number and an Uppercase.";
            break;
            case 2 : body = "you typed a wrong email, please respect its structure 'test@spatter.com' ";
            break;
            case 3 : body = "Please fill the input with your credentials/informations.";
            break;
        }
            hingeJoints = popup.GetComponentsInChildren<Component>();
            foreach (Component joint in hingeJoints)
            {
                if(joint.name.Equals("body_popup"))
                    joint.GetComponent<Text>().text = body;
            }
            popup.SetActive(true);
    }
    public void closePopup(){
        popup.SetActive(false);
    }
}

