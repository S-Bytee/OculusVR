using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook2D : MonoBehaviour
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
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation += mouseX;
        yRotation += mouseY;
        transform.localRotation = Quaternion.Euler(-yRotation, xRotation, 0f);
        Debug.Log(transform.localRotation);
    }
}
