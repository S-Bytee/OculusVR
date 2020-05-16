using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadProjectInButton : MonoBehaviour
{



    PhysicsPointer laserPointer;
    // Start is called before the first frame update
    void Start()
    {

        laserPointer = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if(laserPointer.hit.collider)
        {

            if(laserPointer.hit.collider.gameObject == this.gameObject)
            {
                Debug.Log("ProjectClicked");

                if (Input.GetMouseButtonDown(0))
                {
                    PlayerPrefs.SetString("ProjectName", GetComponent<Button>().name);
                    PlayerPrefs.Save();
                    this.gameObject.GetComponent<Button>().onClick.Invoke();

                }

            }


        }

    }


  
}
