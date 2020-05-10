using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewProject : MonoBehaviour
{
    public GameObject canvasHome;
    public GameObject canvasDraw;
    public GameObject canvasNewProject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateProjects()
    {
        canvasDraw.SetActive(true);
        canvasHome.SetActive(false);
        canvasNewProject.SetActive(false);


    }
    public void BackToHome()
    {
        canvasDraw.SetActive(false);
        canvasHome.SetActive(true);
       // canvasNewProject.SetActive(false);


    }
}
