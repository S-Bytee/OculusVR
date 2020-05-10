using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resizing_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Display;
    public Button plus, minus;

    PhysicsPointer laserPointer;
    Animator animator;
    Animator parentAnimator;
    GameObject mainMenu;


    void Start()
    {

        laserPointer = PhysicsPointer.Instance;
        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    Plus_size();

                }

            }

        }

        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    Minus_size();

                }

            }

        }

        
    }

    // Update is called once per frame
    public void Plus_size()
    {

        Display.gameObject.transform.localScale += new Vector3(0.01F, 0.01f, 0.01f);

      
    }
    public void Minus_size()
    {
        Display.gameObject.transform.localScale -= new Vector3(0.01F, 0.01f, 0.01f);

    }

   
    
}
