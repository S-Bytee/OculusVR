﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldKeyBoard : MonoBehaviour
{


    PhysicsPointer laserPointer;
    public GameObject KeyboardVR;
    // Start is called before the first frame update
    void Start()
    {
        laserPointer = PhysicsPointer.Instance;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (laserPointer.hit.collider)
        {
            if (Input.GetMouseButtonDown(0))
                {
                     EventSystem.current.SetSelectedGameObject(gameObject, null);
                    GetComponent<InputField>().OnPointerClick(new PointerEventData(EventSystem.current));
                    KeyboardVR.SetActive(true);
                }
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                
            }

        }

        if (KeyboardVR.activeSelf)
            GetComponent<InputField>().text = KeyboardVR.GetComponent<KeyboardVRManager>().Text;
    }
}