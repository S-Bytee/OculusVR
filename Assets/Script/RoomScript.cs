﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RoomScript : MonoBehaviour
{
    public GameObject users_book;
    public GameObject friend_phone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0)) {    
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
            print("no");
             if (Physics.Raycast(ray, out hit)) {
                 // whatever tag you are looking for on your game object
                 print(hit.transform.name);
                 if(hit.collider.name == "book4") {                         
                     PlayerPrefs.SetString("scene","book_scene");  
                     SceneManager.LoadScene("loading_screen");              
                 }else if(hit.collider.name == "Dimkra_Dveri_Klasik_Anya3"){
                     PlayerPrefs.SetString("scene","Menu_Scene");
                     SceneManager.LoadScene("loading_screen");
                 }
                 
             }    
         }
    }
}