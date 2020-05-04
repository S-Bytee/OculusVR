using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    string word = null;
    int wordIndex = 0;
    string alpha;
    public Text myTitle = null;

    public void alphabetFunction(string alphabet)
    {
        wordIndex++;
        word = word + alphabet;
        myTitle.text = word;
    }
    void Start()
    {

    }

    // Make Game objects clickable
    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            alphabetFunction(alpha);
        }
    }
    
}
