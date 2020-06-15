using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadProj2D : MonoBehaviour
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
        if (laserPointer.hit.collider)
        {

            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {

                    /*PlayerPrefs.SetString("ProjectName", GetComponent<Button>().name);
                    PlayerPrefs.Save();
                    */
                    DestroyAll();
                    transform.parent.parent.parent.parent.parent.GetComponent<Load2DProjects>().FetchFor2DProject(GetComponent<Button>().name + "_2D");
                    this.gameObject.GetComponent<Button>().onClick.Invoke();
                    Debug.Log("ProjectClicked");

                }

            }


        }
    }

void DestroyAll()
    {
        for(int i =0;i< transform.parent.parent.parent.parent.parent.childCount;i++)
        {
            if(transform.parent.parent.parent.parent.parent.GetChild(i).tag == "InstanciatedProject")
            {
                Destroy(transform.parent.parent.parent.parent.parent.GetChild(i).gameObject);
            }
        }
    }
}
