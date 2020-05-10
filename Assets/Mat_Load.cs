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
    public GameObject colorChanger;


    private void Start()
    {
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
        
        red.onClick.AddListener(delegate {

            rouge();


        });

        blue.onClick.AddListener(delegate {

            bleu();


        });

        green.onClick.AddListener(delegate {

            vert();


        });

        yellow.onClick.AddListener(delegate {

            jaune();


        });

        pink.onClick.AddListener(delegate {

            rose();


        });

        purple.onClick.AddListener(delegate {

            violet();


        });

        black.onClick.AddListener(delegate {

            noir();


        });

        white.onClick.AddListener(delegate {

            blanc();


        });

        save.onClick.AddListener(delegate {

            colorChanger.SetActive(false);


        });
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

