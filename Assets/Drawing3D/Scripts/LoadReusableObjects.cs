using PaintIn3D;
using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class LoadReusableObjects : MonoBehaviour
{
    string ReusableObjectsPath;
    Material mat;

    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        mat = new Material(Shader.Find("ColorPicker/SolidColor"));
        ReusableObjectsPath = Application.dataPath + "/Drawing3D/Prefabs/ReusableObjects/";
        if (!Directory.Exists(ReusableObjectsPath))
        {
            Directory.CreateDirectory(ReusableObjectsPath);
            UnityEditor.AssetDatabase.Refresh();
        }
        else
        {
            for (int i = 0; i < Directory.GetDirectories(ReusableObjectsPath).Length; i++)
            {
                string[] tabs = Directory.GetDirectories(ReusableObjectsPath)[i].Split('/');
                string ObjectName = tabs[tabs.Length - 1];
                GameObject currGo;
              
                currGo= Instantiate(Object, Vector3.zero, Quaternion.identity);

                string name = ObjectName.Split('_')[0];
                string date = ObjectName.Split('_')[1];
                currGo.name = ObjectName;
                currGo.transform.GetChild(0).GetComponent<Text>().text = currGo.transform.GetChild(0).GetComponent<Text>().text +" "+name ;
                currGo.transform.GetChild(1).GetComponent<Text>().text = currGo.transform.GetChild(1).GetComponent<Text>().text+" "+ date.Replace('-', ' ');
                currGo.transform.SetParent(gameObject.transform.GetComponent<HorizontalLayoutGroup>().transform, false);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void InstanciateObject(string ObjectName)
    {
        if(Directory.Exists(ReusableObjectsPath+ObjectName))
        {
            foreach(string PathToPrefab in Directory.GetFiles(ReusableObjectsPath+ObjectName))
            {
                GameObject go;
                GameObject currGo;
                if (PathToPrefab.EndsWith(".prefab"))
                {
                    go= PrefabUtility.LoadPrefabContents(PathToPrefab);
                    //go.GetComponent<Renderer>().material = mat;
                    Color color = go.transform.GetChild(0).GetComponent<P3dPaintableTexture>().Color;
                    if (go.tag == "object")
                    {
                       currGo = Instantiate(go,go.transform.position,Quaternion.identity);
                       currGo.transform.GetChild(0).GetComponent<Renderer>().material = mat;
                       currGo.transform.GetChild(0).GetComponent<Renderer>().material.color = color;

                    }
                    else if(go.tag == "lineRenderer")
                    {

                    }
                    
                
                
                }
                
            }
        }
    }



}
