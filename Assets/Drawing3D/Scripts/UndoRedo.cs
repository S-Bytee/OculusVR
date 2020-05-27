using Shapes2D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;



public enum ChangementType
{
    INSTANCIATE_LINERENDERER,DESTROYED_LINERENDERER,COLOR_CHANGE_LINERENDERER
}

public class Changement
{
    public long InstanceID { get; set; }


    public GameObject NewInstance{get;set;}
    public GameObject PreviousInstance { get; set; }

    public Vector3 NewPosition { get; set; }
    public Vector3 PreviousPosition { get; set; }

    public Color NewColor { get; set; }
    public Color PreviousColor { get; set; }

    public Color LineColor { get; set; }
    
    public ChangementType Changementtype { get; set; }
    public Changement()
    {

    }
    public Changement(long instanceID, ChangementType changementType)
    {
        this.InstanceID = instanceID;
        this.Changementtype = changementType;

    }

    public Changement(long instanceID, Color LineColor, ChangementType changementType)
    {
        this.InstanceID = instanceID;
        this.Changementtype = changementType;
        this.LineColor = LineColor;

    }

    public Changement(long instanceID, GameObject newInstance, Color LineColor, ChangementType changementType)
    {
        this.InstanceID = instanceID;
        this.NewInstance = newInstance;
        this.LineColor = LineColor;
        this.Changementtype = changementType;
    }


    public Changement(long instanceID, Color NewColor,Color PreviousColor, ChangementType changementType)
    {

        this.InstanceID = instanceID;
        this.Changementtype = changementType;
        this.NewColor = NewColor;
        this.PreviousColor = PreviousColor;

    }

    public override bool Equals(object obj)
    {
        return obj is Changement changement &&
               NewColor.Equals(changement.NewColor) &&
               PreviousColor.Equals(changement.PreviousColor) &&
               Changementtype == changement.Changementtype;
    }

    public override int GetHashCode()
    {
        int hashCode = -1941313032;
        hashCode = hashCode * -1521134295 + NewColor.GetHashCode();
        hashCode = hashCode * -1521134295 + PreviousColor.GetHashCode();
        hashCode = hashCode * -1521134295 + Changementtype.GetHashCode();
        return hashCode;
    }
}


public class UndoRedo : MonoBehaviour
{

    private static UndoRedo _instance;
    string UndoRedoPath;
    public static UndoRedo Instance { get { return _instance; } }
    
    Mesh mesh;
    MeshCollider meshCollider;

    public int UndoRedoCapacity;
   
    
    static Stack<Changement> UndoStack;
    static Stack<Changement> RedoStack;
    public GameObject RedoLineRenderer;


    public Material MatLine;
    // Start is called before the first frame update
    void Start()
    {
        UndoRedoPath = Application.dataPath + "/Drawing3D/Prefabs/UndoRedo/";
        ClearRedoFolder();


        if (_instance != null && _instance != this)
        {
            
        }
        else
        {
            _instance = this;
        }

        UndoStack = new Stack<Changement>(UndoRedoCapacity);
        RedoStack = new Stack<Changement>(UndoRedoCapacity);
        
        UndoStack.Push(new Changement());
        RedoStack.Push(new Changement());

    }
    
    string GetUndoRedoPathFor(ChangementType changementType)
    {
        string changementTypePath;

        changementTypePath = UndoRedoPath + changementType+"/";

        return changementTypePath;
    }

    // Besh nstockiw l changement fel stack undo (Changement fih l gameobject mtaa haja li saar aaleha changement)
    //Changement inajem ikoun instance jdida tzedet ouala size tbadel ouala couleur jdid ...
    public void AddChangementToUndo(Changement changement)
    {
    
        switch(changement.Changementtype)
        {
            case ChangementType.DESTROYED_LINERENDERER:
                {
                    SaveGameObjectInPrefab(changement.NewInstance, ChangementType.DESTROYED_LINERENDERER);

                    break;
                }
            case ChangementType.COLOR_CHANGE_LINERENDERER:
                {

                    if (!ChangementColorExist(changement))
                    {

                        //Pour eviter le cas ouin ki taamel undo aala couleur iaawed izid changement aal couleur lekdim o hakeka on boucle fel feragh 
                        if (changement.PreviousColor != GetInstanceById(changement.InstanceID).GetComponent<Renderer>().material.GetColor("_TintColor"))
                        {
                            UndoStack.Push(changement);

                        }

                    }

                    break;
                }

            default: {

                    UndoStack.Push(changement);

                    break;
                }
                
        }

    }

    // Besh nstockiw l changement fel stack redo (Changement fih l gameobject mtaa haja li saar aaleha changement)
    public void AddChangementToRedo(Changement changement)
    {
            
        RedoStack.Push(changement);
       
    }
    
    public void Undo()
    {
        //Nekhdhou ekher changement tzeed
        Changement changement = UndoStack.Pop();
        //Selon type mtaa changement besh naamlou traitement
        switch(changement.Changementtype)
        {
        
            //Ken changement sar fel LineRenderer
            case ChangementType.INSTANCIATE_LINERENDERER:
                {

                    DestroyLineRendererAndSaveToPrefab(changement);

                    break;

                }
            case ChangementType.DESTROYED_LINERENDERER:
                {

                    UndoErasedLineRenderer(changement);

                    break;
                }
            case ChangementType.COLOR_CHANGE_LINERENDERER:
                {

                    UndoColorChangedLineRenderer(changement);

                    break;
                }


        }
    }


    public void Redo()
    {

        Changement changement = RedoStack.Pop();
     
        switch (changement.Changementtype)
        {
            case ChangementType.INSTANCIATE_LINERENDERER:
                {

                    ReturnDestroyedLineRendererFromPrefab(changement);

                    break;
                
                }
            case ChangementType.DESTROYED_LINERENDERER:
                {
                    RedoErasedLineRenderer(changement);

                    break;
                }
        }
        
    }

    void DestroyLineRendererAndSaveToPrefab(Changement changement)
    {
        // l gameobject en question (li howa ekher changement taamal) on va le sauvegarder fi dossier "redo"
        SaveGameObjectInPrefab(changement);
        // o nzidou l changement hedha fel stack Redo, khater ki yaamel undo o baadha yaamel redo laazem yaarjaa ouin ken 
        AddChangementToRedo(new Changement(changement.InstanceID, changement.LineColor, ChangementType.INSTANCIATE_LINERENDERER));
        // aprés qu'on a sauvegarder l gameobject en question naamelou destroy aaleha khater l gameobject khabineh fel dossier "redo"
        Destroy(GetInstanceById(changement.InstanceID));


    }


    void RedoErasedLineRenderer(Changement changement)
    {

        UndoStack.Push(changement);
        SaveGameObjectInPrefab(changement);
        Destroy(GetInstanceById(changement.InstanceID));

    }

    void UndoColorChangedLineRenderer(Changement changement)
    {
        GameObject go;
        
        go = GetInstanceById(changement.InstanceID);
        Debug.Log(go.GetComponent<Renderer>().material.GetColor("_TintColor"));
        go.GetComponent<Renderer>().material.SetColor("_TintColor", changement.PreviousColor);

    }

    void ReturnDestroyedLineRendererFromPrefab(Changement changement)
    {
        GameObject go;
        GameObject currGo;

        // nloadiw l prefab mel dossier "redo" o nhotouh fi variable go
        go = PrefabUtility.LoadPrefabContents(GetUndoRedoPathFor(changement.Changementtype) + changement.InstanceID + ".prefab");

        // Naamelou instance aal go besh yerjaa ouin ken
        currGo = Instantiate(go, Vector3.zero, Quaternion.identity);

        // Probleme houni: ki terjaa l instance, li heya kenet stocké fel dossier "redo" 
        // terjaa maghir mesh o maghir material 

        // donc narj3oulhom l mesh o material
        ReturnMeshToLineRenderer(currGo.GetComponent<LineRenderer>());
        ReturnMaterialToLineRenderer(currGo, changement.LineColor);

        // benesba lel cas mtaa nzelt undo o baad redo lazem ki taawed tenzel undo mara okhra  
        // l gameobject iwaaed isirlou undo (donc yetkhaba fel dossier "redo" mara okhra)
        ResaveToUndo(currGo);
        //nfaskhou l prefab lekdim
        File.Delete(GetUndoRedoPathFor(ChangementType.INSTANCIATE_LINERENDERER) + changement.InstanceID + ".prefab");

        UnityEditor.AssetDatabase.Refresh();


    }

    bool ChangementColorExist(Changement changement)
    {
        foreach(Changement ch in UndoStack)
        {
            if(changement.NewColor == ch.NewColor && changement.PreviousColor == ch.PreviousColor && changement.Changementtype == ch.Changementtype)
            {
                return true;
            }
        }

        return false;
    }

    void UndoInstanciatedObjects()
    {

    }

    void RedoInstanciatedObjects()
    {

    }

    void UndoErasedLineRenderer(Changement changement)
    {
        GameObject go;
        GameObject currGo;

        // nloadiw l prefab mel dossier "redo" o nhotouh fi variable go
        go = PrefabUtility.LoadPrefabContents(GetUndoRedoPathFor(changement.Changementtype) + changement.InstanceID + ".prefab");

        // Naamelou instance aal go besh yerjaa ouin ken
        currGo = Instantiate(go, Vector3.zero, Quaternion.identity);

        // Probleme houni: ki terjaa l instance, li heya kenet stocké fel dossier "redo" 
        // terjaa maghir mesh o maghir material 

        // donc narj3oulhom l mesh o material
        ReturnMeshToLineRenderer(currGo.GetComponent<LineRenderer>());
        ReturnMaterialToLineRenderer(currGo, changement.LineColor);

        // benesba lel cas mtaa nzelt undo o baad redo lazem ki taawed tenzel undo mara okhra  
        // l gameobject iwaaed isirlou undo (donc yetkhaba fel dossier "redo" mara okhra)
        AddChangementToRedo(new Changement(currGo.GetInstanceID(), currGo.GetComponent<Renderer>().material.GetColor("_TintColor"), ChangementType.DESTROYED_LINERENDERER));
        //nfaskhou l prefab lekdim
        File.Delete(GetUndoRedoPathFor(ChangementType.INSTANCIATE_LINERENDERER) + changement.InstanceID + ".prefab");

        UnityEditor.AssetDatabase.Refresh();

    }

     void ReturnMeshToLineRenderer(LineRenderer lineRenderer)
    {
        mesh = new Mesh();
        lineRenderer.BakeMesh(mesh, true);
        MeshCollider meshCollider = lineRenderer.gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
        lineRenderer.gameObject.GetComponent<MeshFilter>().mesh = mesh;

    }

     void ReturnMaterialToLineRenderer(GameObject go,Color color)
    {

        go.GetComponent<Renderer>().material = MatLine;
        go.GetComponent<Renderer>().material.SetColor("_TintColor", color);
    }

     void ResaveToUndo(GameObject currGo)
    {
        AddChangementToUndo(new Changement(currGo.GetInstanceID(), currGo, currGo.GetComponent<Renderer>().material.GetColor("_TintColor"), ChangementType.INSTANCIATE_LINERENDERER));

        SaveGameObjectInPrefab(new Changement(currGo.GetInstanceID(),ChangementType.INSTANCIATE_LINERENDERER));

    }

     void ClearRedoFolder()
    {
        
        if(Directory.Exists(UndoRedoPath))
        {
            if(!Directory.Exists(GetUndoRedoPathFor(ChangementType.INSTANCIATE_LINERENDERER)))
            {
                Directory.CreateDirectory(GetUndoRedoPathFor(ChangementType.INSTANCIATE_LINERENDERER));
            }
            else
            {
                foreach (string path in Directory.GetFiles(GetUndoRedoPathFor(ChangementType.INSTANCIATE_LINERENDERER)))
                {
                    if (File.Exists(path))
                        File.Delete(path);
                }
            }

            if (!Directory.Exists(GetUndoRedoPathFor(ChangementType.DESTROYED_LINERENDERER)))
            {
                Directory.CreateDirectory(GetUndoRedoPathFor(ChangementType.DESTROYED_LINERENDERER));
            }
            else
            {
                foreach (string path in Directory.GetFiles(GetUndoRedoPathFor(ChangementType.DESTROYED_LINERENDERER)))
                {
                    if (File.Exists(path))
                        File.Delete(path);
                }
            }

            UnityEditor.AssetDatabase.Refresh();

        }
        else
        {

            Directory.CreateDirectory(UndoRedoPath);
            UnityEditor.AssetDatabase.Refresh();

            if (!Directory.Exists(GetUndoRedoPathFor(ChangementType.INSTANCIATE_LINERENDERER)))
                Directory.CreateDirectory(GetUndoRedoPathFor(ChangementType.INSTANCIATE_LINERENDERER));

            if(!Directory.Exists(GetUndoRedoPathFor(ChangementType.DESTROYED_LINERENDERER)))
                Directory.CreateDirectory(GetUndoRedoPathFor(ChangementType.DESTROYED_LINERENDERER));

            UnityEditor.AssetDatabase.Refresh();

        }

    }




      void SaveGameObjectInPrefab(Changement changement)
    {

        PrefabUtility.SaveAsPrefabAsset(GetInstanceById(changement.InstanceID), "Assets/Drawing3D/Prefabs/UndoRedo/"+changement.Changementtype+"/" + changement.InstanceID+".prefab");
        
    }

     void SaveGameObjectInPrefab(GameObject go,ChangementType changementType)
    {

        PrefabUtility.SaveAsPrefabAsset(go, "Assets/Drawing3D/Prefabs/UndoRedo/"+changementType+"/" + go.GetInstanceID() + ".prefab");

    }

     GameObject GetInstanceById(long id)
    {
        GameObject go = null;

        foreach(GameObject g in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if(g.GetInstanceID() == id)
            {
                go = g;
            }
        }

        return go;
    }

}

