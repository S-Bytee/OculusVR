using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelCanvasNavigator : MonoBehaviour
{


    [SerializeField] int main_menu_index = 1;
    [SerializeField] int objects_3d_index = 2;
    [SerializeField] int objects_2d_index = 3;
    [SerializeField] int color_picker_index = 4;
    
    int x = 0;
    Transform centerWheel;

    void Start()
    {
        

    }

    void Update()
    {
        
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

        x++;
        centerWheel = transform.parent.GetChild(1).GetChild(0).GetChild(8);
        
        if(x%2==0)
        {
            this.centerWheel.GetComponent<Image>().enabled = true;
            centerWheel.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            this.centerWheel.GetComponent<Image>().enabled = false;
            centerWheel.GetChild(0).gameObject.SetActive(true);


        }

    }




}
