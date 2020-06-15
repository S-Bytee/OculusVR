using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mat_Load : MonoBehaviour
{
    

    PhysicsPointer laserPointer;
    Animator animator;
    Animator parentAnimator;
    public GameObject Sol;
    public Button red, blue, yellow, purple, pink, white, black, green, save;
    


    private void Start()
    {
        laserPointer = PhysicsPointer.Instance;
        /*
                laserPointer = PhysicsPointer.Instance;
                if (laserPointer.hit.collider)
                {
                    if (laserPointer.hit.collider.isTrigger == this.gameObject)
                    {

                        if (Input.GetMouseButtonDown(0))
                        {
                            ChangeImg();

                        }

                    }

                }
                //btn.onClick.AddListener(delegate { ChangeImg(); });*/
    }
    public void Update()
    {
        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {

                   rouge();



                    


                }

            }
        }

        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    bleu();






                }

            }
        }












        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    vert();






                }

            }
        }
        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    jaune();






                }

            }
        }
        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    rose();






                }

            }
        }
        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    violet();

                }

            }
        }

        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    blanc();

                }

            }
        }

        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    noir();

                }

            }
        }

        /*save.onClick.AddListener(delegate {

            colorChanger.SetActive(false);


        }); */
    }

    

    public void rouge()
    {
        Material mat12 = Resources.Load("Red", typeof(Material)) as Material;
        Sol.GetComponent<Renderer>().material = mat12;
    }

    public void bleu()
    {
        Material mat12 = Resources.Load("bLue", typeof(Material)) as Material;
        Sol.GetComponent<Renderer>().material = mat12;
    }

    public void jaune()
    {
        Material mat12 = Resources.Load("Yellow", typeof(Material)) as Material;
        Sol.GetComponent<Renderer>().material = mat12;
    }

    public void vert()
    {
        Material mat12 = Resources.Load("Green", typeof(Material)) as Material;
        Sol.GetComponent<Renderer>().material = mat12;
    }

    public void rose()
    {
        Material mat12 = Resources.Load("Pink", typeof(Material)) as Material;
        Sol.GetComponent<Renderer>().material = mat12;
    }

    public void violet()
    {
        Material mat12 = Resources.Load("Purple", typeof(Material)) as Material;
        Sol.GetComponent<Renderer>().material = mat12;
    }

    public void noir()
    {
        Material mat12 = Resources.Load("bLack", typeof(Material)) as Material;
        Sol.GetComponent<Renderer>().material = mat12;
    }

    public void blanc()
    {
        Material mat12 = Resources.Load("White", typeof(Material)) as Material;
        Sol.GetComponent<Renderer>().material = mat12;
    }


}
    

