using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCanvasSettingsMultiplayer : MonoBehaviour
{

    int x = 0;
    GameObject artisticTools;
    // Start is called before the first frame update
    void Start()
    {

        artisticTools = GameObject.Find("WheelCanvasMultiplayer");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            x++;
        }

        if (x % 2 == 0)
        {
            artisticTools.SetActive(false);
        }
        else
        {
            artisticTools.SetActive(true);
        }
    }
}
