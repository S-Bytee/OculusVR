﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectManagerNavigator : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject project_center_wheel;
    void Start()
    {
        project_center_wheel = transform.parent.GetChild(1).GetChild(8).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

      /*  if (PlayerPrefs.GetString("ProjectName") != "")
        {
            showCenterText();
        }
        */
    }


    public void showCenterText()
    {
        disableAll();
        project_center_wheel.GetComponent<TextMeshProUGUI>().enabled = true;

    }



    public void disableAll()
    {
        project_center_wheel.GetComponent<TextMeshProUGUI>().enabled = false;

        for (int i = 0; i < project_center_wheel.transform.childCount; i++)
        {
            project_center_wheel.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    public void showCreateProject()
    {

        disableAll();
        project_center_wheel.transform.GetChild(0).gameObject.SetActive(true);

    }


    public void showLoadProjects()
    {

        disableAll();
        project_center_wheel.transform.GetChild(1).gameObject.SetActive(true);

    }

    public void showMultiplayer()
    {

        GameObject project_manager = transform.parent.gameObject;
        GameObject wheel_cancvas = transform.parent.parent.gameObject;
        wheel_cancvas.transform.GetChild(7).gameObject.SetActive(true);
        project_manager.SetActive(false);

    }


    public void disconnect()
    {

        Cursor.lockState = CursorLockMode.None;

        PlayerPrefs.SetString("username","");
        SceneManager.LoadScene("authentification");

    }

    public void moveToHome()
    {
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene("Menu_Scene");
    }


}
