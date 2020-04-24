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

    void singin(){

    }

    public void changeInput()
    {
            if(input_email.GetComponent<InputField>().isFocused){
                input_password.GetComponent<InputField>().Select();
            }
    }
}
