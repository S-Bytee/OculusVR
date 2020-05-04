using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayUI : MonoBehaviour
{
    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;
    public GameObject photos;
    public Button save;

    PhysicsPointer laserPointer;
    Animator animator;
    Animator parentAnimator;
    GameObject mainMenu;

    void Start()
    {
        laserPointer = PhysicsPointer.Instance;
        myText = GameObject.Find("Text").GetComponent<Text>();
    
    }

    // Update is called once per frame
    void Update()
    {
        FadeText();
        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    
                        photos.SetActive(false);

                    
                    
                }

            }

        }
        
            
        
        
        //save.onClick.AddListener(delegate { 

        //  photos.SetActive(false);


        //});

    }

    public void OnMouseOver()
    {
        if (photos.active)
        {
            displayInfo = false;
            
        }
        else
        {
            displayInfo = true;
            if (Input.GetMouseButtonDown(0))
            {
                photos.SetActive(true);

            }
        }
        
        
    }
    

    private void OnMouseExit()
    {
        displayInfo = false;
    }

    void FadeText()
    {
        if (displayInfo)
        {
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
        }
        else
        {
            myText.color= Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }

    public void Save_state()
    {
        
    }


}
