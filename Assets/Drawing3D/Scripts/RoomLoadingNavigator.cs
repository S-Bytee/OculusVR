using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoadingNavigator : MonoBehaviour
{

    GameObject upBtn;
    GameObject downBtn;
    void Start()
    {
        upBtn = transform.parent.GetChild(1).gameObject;
        downBtn = transform.parent.GetChild(2).gameObject;
        
    }

    public void onUpClick()
    {

    }

    public void onDownClick()
    {

    }


}
