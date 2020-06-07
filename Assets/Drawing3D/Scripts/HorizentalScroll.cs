using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizentalScroll : MonoBehaviour
{

    float MaxSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaxSize = transform.childCount * 60;
    }

    public void NextObject()
    {
        if(GetComponent<RectTransform>().localPosition.x < MaxSize)
        gameObject.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);

    }

    public void PreviousObject()
    {
        if (GetComponent<RectTransform>().localPosition.x > -MaxSize)
        gameObject.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);

    }
    
}
