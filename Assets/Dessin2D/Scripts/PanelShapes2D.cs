using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelShapes2D : MonoBehaviour
{

    public GameObject Panel;
    // Start is called before the first frame update
    public void openPanel()
    {

        if (Panel != null)
        {
            bool isActif = Panel.activeSelf;
            Panel.SetActive(!isActif);

        }




    }
}
