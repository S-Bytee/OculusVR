using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WheelCanvasNavigator : MonoBehaviour
{


    [SerializeField] int main_menu_index = 1;
    [SerializeField] int objects_3d_index = 2;
    [SerializeField] int objects_2d_index = 3;
    [SerializeField] int color_picker_index = 4;
    [SerializeField] int pointer_mode_index = 5;
    [SerializeField] int pointer_child_count = 5;
    [SerializeField] int center_wheel_indew = 8;
    [SerializeField] int project_wheel_index = 6;
    
    List<Sprite> spriteWheelList ;
    List<Sprite> spriteOnSelectWheelList;
    bool showGZIMO = false;

    int x = 0;
    Transform centerWheel;

    void Start()
    {
        spriteWheelList = new List<Sprite>();
        spriteOnSelectWheelList = new List<Sprite>();


    }

    void Update()
    {
        showGizmo();
    }


    public void showMainMenu()
    {
        transform.parent.GetChild(main_menu_index).gameObject.SetActive(true);
    }

    public void hideMainMenu()
    {
        transform.parent.GetChild(main_menu_index).gameObject.SetActive(false);
    }

    public void show3DObjectsMenu()
    {
        transform.parent.GetChild(objects_3d_index).gameObject.SetActive(true);

    }
    public void hide3DObjectsMenu()
    {

        transform.parent.GetChild(objects_3d_index).gameObject.SetActive(false);

    }

    public void show2DObjectsMenu()
    {

        transform.parent.GetChild(objects_2d_index).gameObject.SetActive(true);

    }
    public void hide2DObjectsMenu()
    {

        transform.parent.GetChild(objects_2d_index).gameObject.SetActive(false);

    }

    public void showColorPickerMenu()
    {

        transform.parent.GetChild(color_picker_index).gameObject.SetActive(true);

    }
    public void hideColorPickerMenu()
    {

        transform.parent.GetChild(color_picker_index).gameObject.SetActive(false);

    }
    public void showBushSettings()
    {

        hideAllCenterWheelChildren();
        x++;
        centerWheel = transform.parent.GetChild(1).GetChild(0).GetChild(8);
        
        if(x%2==0)
        {
            centerWheel.GetChild(0).gameObject.SetActive(false);
           
        }
        else
        {
            
            this.centerWheel.GetComponent<Image>().enabled = false;
            centerWheel.GetChild(0).gameObject.SetActive(true);


        }

    }

    public void showPointerModeMenu()
    {
        transform.parent.GetChild(pointer_mode_index).gameObject.SetActive(true);
    }


    public void hidePointerModeMenu()
    {
        transform.parent.GetChild(pointer_mode_index).gameObject.SetActive(false);
    }


    public void showProjects()
    {
        transform.parent.GetChild(project_wheel_index).gameObject.SetActive(true);

    }

    public void hideProjects()
    {
        transform.parent.GetChild(project_wheel_index).gameObject.SetActive(false);

    }

    public void colorChangeWheelPointer(int wheel_index)
    {
        initWheelsList();

        backToDefaultColorWheelsPointer();

        transform.parent.GetChild(pointer_child_count).GetChild(0).GetChild(wheel_index).GetComponent<WheelPointerBehavior>().default_sprite = this.spriteOnSelectWheelList.ElementAt(wheel_index); 
    }

    public void backToDefaultColorWheelsPointer()
    {


        for (int i = 0; i < transform.parent.GetChild(pointer_child_count).GetChild(0).childCount; i++)
        {
            if (transform.parent.GetChild(pointer_mode_index).GetChild(0).GetChild(i).GetComponent<WheelPointerBehavior>() != null)
            {
               transform.parent.GetChild(pointer_child_count).GetChild(0).GetChild(i).GetComponent<WheelPointerBehavior>().default_sprite = this.spriteWheelList.ElementAt(i);
               transform.parent.GetChild(pointer_child_count).GetChild(0).GetChild(i).GetComponent<WheelPointerBehavior>().select_sprite = this.spriteOnSelectWheelList.ElementAt(i);
            // Debug.Log(this.spriteWheelList.Count);
            }
        }
    }


    public void initWheelsList()
    {
        for (int i = 0; i < transform.parent.GetChild(pointer_mode_index).GetChild(0).childCount-1; i++)
        {
            if(transform.parent.GetChild(pointer_mode_index).GetChild(0).GetChild(i).GetComponent<WheelPointerBehavior>()!=null)
            { 
                spriteWheelList.Add(transform.parent.GetChild(pointer_mode_index).GetChild(0).GetChild(i).GetComponent<WheelPointerBehavior>().default_sprite);
                spriteOnSelectWheelList.Add(transform.parent.GetChild(pointer_mode_index).GetChild(0).GetChild(i).GetComponent<WheelPointerBehavior>().select_sprite);
            }
        }

        //Debug.Log(this.spriteOnSelectWheelList.Count);
    }

    public void hideAllCenterWheelChildren()
    {
        for(int i =0;i< transform.parent.GetChild(1).GetChild(0).GetChild(center_wheel_indew).childCount; i++)
        {
            
            if (transform.parent.GetChild(1).GetChild(0).GetChild(center_wheel_indew).GetChild(i).gameObject.tag !="gizmo")
            transform.parent.GetChild(1).GetChild(0).GetChild(center_wheel_indew).GetChild(i).gameObject.SetActive(false);
        }
    }

    public void showGizmo()
    {
        showGZIMO = false;          
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("object"))
        {
         
         
            if(go.transform.childCount>0)
            {

                if (go.transform.GetChild(0).GetComponent<OnSelectObject>().isClicked)
                {
                    showGZIMO = true;
                }

            }


        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("lineRenderer"))
        {

            if (go.transform.childCount == 0)
            {

                if (go.transform.GetComponent<SelectLineRenderer>().isSelected)
                {
                    showGZIMO = true;
                }

            }


        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("reusableObject"))
        {

                if (go.transform.GetComponent<ReusableObjectSelection>().IsSelected)
                {
                    showGZIMO = true;
                }

        }

        if (showGZIMO)
        {
        
            hideAllCenterWheelChildren();
            transform.parent.GetChild(1).GetChild(0).GetChild(8).GetComponent<Image>().enabled = false;
            transform.parent.GetChild(1).GetChild(0).GetChild(8).GetChild(1).gameObject.SetActive(true);
        
        }
        else
        {
            
            transform.parent.GetChild(1).GetChild(0).GetChild(8).GetChild(1).gameObject.SetActive(false);
            if(x%2==0) // Ki yebda gizmo moush active o l brush settings zeda mahich active lazem nraj3ou l Logo
            transform.parent.GetChild(1).GetChild(0).GetChild(8).GetComponent<Image>().enabled = true;

        }


    }

    public void showProject()
    {
        transform.parent.GetChild(6).gameObject.SetActive(true);
    }

    public void hideMultiplayer()
    {
        transform.parent.GetChild(7).gameObject.SetActive(false);

    }

}
