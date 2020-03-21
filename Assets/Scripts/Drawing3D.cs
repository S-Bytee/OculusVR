using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing3D : MonoBehaviour
{


    PhysicsPointer laserInstance;

    public GameObject sphere;
    bool draw = false;

    // Start is called before the first frame update
    void Start()
    {
        
        laserInstance = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        drawing();
    }



    public void drawing()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            draw = true;
            
        }

        if (Input.GetButtonUp("Fire1"))
        {
            draw = false;

        }

        if (draw)
        {
            Instantiate(sphere, this.laserInstance.DefaultEnd(this.laserInstance.defaultLength), Quaternion.identity);
        }
        
    }

}
