using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ReusableObjects : MonoBehaviour
{
    PhysicsPointer laserInstance;
    string ReusableObjectsPath;
    GameObject rootGo;
    string CurrentObjectName;
    string CurrentPath;
    public bool IsCreated=false;
    // Start is called before the first frame update
    void Start()
    {
        ReusableObjectsPath = Application.dataPath + "/Drawing3D/Prefabs/ReusableObjects/"; 
        laserInstance = PhysicsPointer.Instance;
        InitializeDirectory();

    }
    private void OnEnable()
    {
  
    }
    // Update is called once per frame
    void Update()
    {

        AddObject();

    }

    public void SetCurrentObjectName(string objName)
    {
        CurrentObjectName = objName;
    }

   public void CreateObject()
    {

        string datetime = DateTime.Now.ToString("dddd-dd-MMMM-yyyy-HH-mm-ss");
        CurrentPath = ReusableObjectsPath + CurrentObjectName + "_" + datetime.ToString();
        Directory.CreateDirectory(CurrentPath);
        UnityEditor.AssetDatabase.Refresh();
        rootGo = new GameObject();
        rootGo.name = CurrentObjectName;
        rootGo.AddComponent<StyleObjects>();
        rootGo.AddComponent<ShowObjectName>();

        if (Directory.Exists(CurrentPath))
        {
            IsCreated = true;
        }
        else
        {
            IsCreated = false;
        }


    }
    void AddObject()
    {
        if(laserInstance.hit.collider)
        {
            
            if(laserInstance.hit.collider.tag == "lineRenderer")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    laserInstance.hit.collider.gameObject.transform.parent = rootGo.transform;
                }
            }

            if(laserInstance.hit.collider.tag == "object")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    laserInstance.hit.collider.gameObject.transform.parent.transform.parent = rootGo.transform;
                }
            }

        }
    }

    void LoadObjects()
    {


    }

   public void SaveObject()
    {
  

        if (!Directory.Exists(CurrentPath))
        {
            Directory.CreateDirectory(CurrentPath);
            UnityEditor.AssetDatabase.Refresh();

        }


        PrefabUtility.SaveAsPrefabAsset(rootGo.gameObject, CurrentPath + "/" + rootGo.GetInstanceID() + ".prefab");
        UnityEditor.AssetDatabase.Refresh();


    }

    void InitializeDirectory()
    {

        if (!Directory.Exists(ReusableObjectsPath))
        {
            Directory.CreateDirectory(ReusableObjectsPath);
            UnityEditor.AssetDatabase.Refresh();

        }
        else 
        {
        
        }
    }


}
