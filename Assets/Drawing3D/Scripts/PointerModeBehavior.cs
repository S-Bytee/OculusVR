using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

public class PointerModeBehavior : MonoBehaviour
{

    Transform mode;

    public int drawing_index=0;
    public int grabbing_index=1;
    public int spray_index=2;
    public int spatter_index=3;
    public int erasing_index=4;
    

    // Start is called before the first frame update
    void Start()
    {
        mode = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2);

       // mode.GetChild(2).gameObject.SetActive(true);
            
    }


    public void Update()
    {
        
    }

    public void updateOnHoverBtn()
    {
        for (int i = 0; i <= mode.childCount - 1; i++)
        {
            if(mode.GetChild(i).gameObject.activeInHierarchy)
            {
                GameObject.Find("WheelCanvas").transform.GetChild(5).GetChild(0).GetChild(i).gameObject.GetComponent<Image>().sprite = GameObject.Find("WheelCanvas").transform.GetChild(5).GetChild(0).GetChild(i).gameObject.GetComponent<WheelPointerBehavior>().select_sprite; 
            }
        }
    }

    public void disableAll()
    {
        for(int i = 0;i<= mode.childCount-1;i++)     
        {
            mode.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void enableDrawing()
    {
        disableAll();
        mode.GetChild(drawing_index).gameObject.SetActive(true);
        updateOnHoverBtn();
    
    }

    public void enableGrabbing()
    {
        disableAll();
        mode.GetChild(grabbing_index).gameObject.SetActive(true);
        updateOnHoverBtn();
    }

    public void enableSpray()
    {

        disableAll();
        mode.GetChild(spray_index).gameObject.SetActive(true);
        updateOnHoverBtn();
    }


    public void enableSpatter()
    {

        disableAll();
        mode.GetChild(spatter_index).gameObject.SetActive(true);
        updateOnHoverBtn();
    }
    public void enableErasing()
    {

        disableAll();
        mode.GetChild(erasing_index).gameObject.SetActive(true);
        updateOnHoverBtn();

    }



    public void enableStylized()
    {

        disableAll();
        mode.GetChild(5).gameObject.SetActive(true);
        updateOnHoverBtn();

    }

}
