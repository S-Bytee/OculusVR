using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObjectBlink : MonoBehaviour
{


    public float a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = new Color(212, 0, 255, a);
    }


}
