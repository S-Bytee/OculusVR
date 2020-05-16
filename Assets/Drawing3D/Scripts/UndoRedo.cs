using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct Changement
{


}


public class UndoRedo : MonoBehaviour
{


    public int undoRedoCapacity;
    Stack undoRedoStack;
    // Start is called before the first frame update
    void Start()
    {
        undoRedoStack = new Stack(undoRedoCapacity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
