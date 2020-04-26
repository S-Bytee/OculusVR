using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 80f;
    
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        
  

    }

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation += mouseY;
        yRotation += mouseX;
        
        //if(xRotation>-30f && xRotation<30f  && yRotation>-50f && yRotation<50f)
        transform.localRotation = Quaternion.Euler(-xRotation, yRotation, 0f);

    }
}
