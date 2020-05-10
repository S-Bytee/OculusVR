﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenu : MonoBehaviour
{
    public GameObject canvasHome;
    public GameObject canvasDraw;
    public GameObject canvasCreateNewProject;
    public GameObject ScrollBar;
    // Start is called before the first frame update
    void Start()
    {
        canvasDraw.SetActive(false);
        ScrollBar.SetActive(false);
        canvasCreateNewProject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateNewProject()
    {
        //canvasDraw.SetActive(true);
        // canvasHome.SetActive(false);
        //canvasCreateNewProject.SetActive(true);
        if (canvasCreateNewProject != null)
        {

            bool isActive = canvasCreateNewProject.activeSelf;
            canvasCreateNewProject.SetActive(!isActive);
        }


    }
    public void UploadProject()
    {
        //canvasDraw.SetActive(true);
        //canvasHome.SetActive(false);
       // ScrollBar.SetActive(true);
        if (ScrollBar != null)
        {

            bool isActive = ScrollBar.activeSelf;
            ScrollBar.SetActive(!isActive);
        }

    }
    public void BackMain()
    {
       

    }

}