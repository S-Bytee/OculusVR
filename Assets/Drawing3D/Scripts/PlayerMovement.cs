using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController controller;

    public float speed = 12f;

    public float gravity = -9.81f;

    Vector3 velocity;


    float altitude;

    private void Start()
    {

        controller = GetComponent<CharacterController>();
        altitude = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("fly");
        if(y==1)
        {
            altitude += 0.5f;
        }
        else
        {
            altitude = 0;
        }

      //  Debug.Log(transform.up * y);

        Vector3 move = transform.right * x + transform.forward * Z+ transform.up*y*5;

        controller.Move(move*speed*Time.deltaTime);

        //transform.Translate(move);

        //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X")*80f);

        //velocity.y += gravity * Time.deltaTime;
//
       // controller.Move(velocity * Time.deltaTime);

    }
}
