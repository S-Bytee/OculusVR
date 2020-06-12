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
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<OculusRiftDetector>().ProjectType == ProjectType.DESKTOP)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject;

            }
            else if (GameObject.FindGameObjectWithTag("Player").GetComponent<OculusRiftDetector>().ProjectType == ProjectType.OCULUS)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;

            }
        }

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
