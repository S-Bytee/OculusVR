﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSettingMultiplayer : MonoBehaviour
{
    // Start is called before the first frame update
    int x = 0;
    GameObject artisticTools;

    void Start()
    {
        artisticTools = transform.parent.GetChild(2).gameObject;

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
