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


    public Component[] hingeJoints;
    public GameObject popup;    public GameObject input_email;
    public GameObject input_password;
    private string email;
    private string password;
    PhysicsPointer laserPointer;
    // Start is called before the first frame update
    void Start()
    {
        laserPointer = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {
         email = input_email.GetComponent<InputField>().text;
         password = input_password.GetComponent<InputField>().text;
         //if(Input.GetKeyDown(KeyCode.Tab)){changeInput();}
         //if(Input.GetKeyDown(KeyCode.Return)){singin();}
         if(laserPointer.hit.collider && Input.GetMouseButtonDown(0))
        {
            if(laserPointer.hit.collider.gameObject == GameObject.Find("login_button")) { singin(); }
        }
        
    }

    public void singin(){
        print("hey");
        if(verif()){
        var filter = Builders<BsonDocument>.Filter.Eq("user_email", email);
        var docu = Mongo.getConnection().GetDatabase("SpatterDB").GetCollection<BsonDocument>("users").Find(filter).ToList();
        foreach(var d in docu )
        {
            if(d.GetValue(d.IndexOfName("user_password")) == password )
            {
                PlayerPrefs.SetString("email",email);
                PlayerPrefs.SetString("username",d.GetValue(d.IndexOfName("user_username")).ToString());
                PlayerPrefs.SetString("createdAt",d.GetValue(d.IndexOfName("createdAt")).ToString());
                PlayerPrefs.SetString("last_login",d.GetValue(d.IndexOfName("last_login")).ToString());
                PlayerPrefs.SetString("scene","room_user");
                SceneManager.LoadScene("loading_screen");
                
            }
            else
            openPopup(4);
        }
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
        if(password!="" && email!=""){

            
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
            case 4 : body = "Wrong password, please try again.";
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
