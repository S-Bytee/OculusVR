using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InputControl : MonoBehaviour
{

    string ReusableObjectsPath;

    public Button btn;
    public GameObject err;
    // Start is called before the first frame update
    void Start()
    {
        ReusableObjectsPath = Application.dataPath + "/Drawing3D/Prefabs/ReusableObjects/";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ControlChange()
    {
        
        string text = GetComponent<InputField>().text;
        //Debug.Log(text);
    
        foreach (string ObjectName in Directory.GetDirectories(ReusableObjectsPath))
        {

            if (GetDirectoryName(ObjectName).Split('_')[0] == text)
            {

                GetComponent<Image>().color = Color.red;
                btn.interactable = false;
                err.SetActive(true);
                return;
            }
            else
            {
             
                GetComponent<Image>().color = Color.white;
                btn.interactable = true;
                err.SetActive(false);


            }


        }

    }


    string GetDirectoryName(string DirectoryName)
    {
        return DirectoryName.Split('/')[DirectoryName.Split('/').Length - 1];
    }

}
