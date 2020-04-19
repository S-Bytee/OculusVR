using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPosition : MonoBehaviour
{
    Vector3 offset;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0.5f, 6);
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        setPosition();
    }


    public void setPosition()
    {
        transform.position = player.transform.position + offset;
    }


}
