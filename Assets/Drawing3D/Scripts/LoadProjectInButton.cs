using MongoDB.Bson;
using MongoDB.Driver;
using Shapes2D;
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

                if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    
                    DestroyAll();

                    PlayerPrefs.SetString("ProjectName", GetComponent<Button>().name);
                    PlayerPrefs.Save();

                    this.gameObject.GetComponent<Button>().onClick.Invoke();
                    Debug.Log("ProjectClicked");

                }

            }


        }

    }

    void DestroyAll()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("object"))
        {
            Destroy(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("lineRenderer"))
        {
            Destroy(go);
        }


        foreach (GameObject go in GameObject.FindGameObjectsWithTag("reusableObject"))
        {
            Destroy(go);
        }

    }
}
