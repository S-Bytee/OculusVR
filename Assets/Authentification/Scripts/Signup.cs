using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
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
        }
    }

    public bool verif()
    {
        if(password!="" && email!="" && phone_number!="" && username != ""){
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
