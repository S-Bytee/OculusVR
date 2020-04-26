using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectsLoadingNavigator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onUpClick()
    {
            
        if(transform.parent.GetChild(0).GetChild(0).transform.position.y<=36 )
        {
            transform.parent.GetChild(0).GetChild(0).transform.position = new Vector3(transform.parent.GetChild(0).GetChild(0).transform.position.x, transform.parent.GetChild(0).GetChild(0).transform.position.y+0.2f, transform.parent.GetChild(0).GetChild(0).transform.position.z);
        }

    }

    public void onDownClick()
    {
        if (transform.parent.GetChild(0).GetChild(0).transform.position.y >= -36)
        {
            transform.parent.GetChild(0).GetChild(0).transform.position = new Vector3(transform.parent.GetChild(0).GetChild(0).transform.position.x, transform.parent.GetChild(0).GetChild(0).transform.position.y - 0.2f, transform.parent.GetChild(0).GetChild(0).transform.position.z);
        }
    }


}
