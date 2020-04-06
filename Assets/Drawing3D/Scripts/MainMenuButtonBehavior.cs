using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonBehavior : MonoBehaviour
{


    PhysicsPointer laserPointer;
    Animator animator;
    Animator parentAnimator;
    GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {

        mainMenu = transform.parent.transform.parent.gameObject;
        laserPointer = PhysicsPointer.Instance;
        animator = GetComponent<Animator>();
        parentAnimator = transform.parent.GetComponent<Animator>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if(laserPointer.hit.collider)
        {
            if(laserPointer.hit.collider.gameObject == this.gameObject)
            {
                 animator.SetBool("didSelect", true);

                if(Input.GetMouseButtonDown(0))
                {

                    switch(laserPointer.hit.collider.gameObject.name)
                    {
                    
                        case "3DObjects":
                            {
                                parentAnimator.SetTrigger("didClick");
                                mainMenu.transform.GetChild(1).gameObject.SetActive(true);
                                break;
                            }
                        case "Color":
                            {
                                parentAnimator.SetTrigger("didClick");
                                mainMenu.transform.GetChild(2).gameObject.SetActive(true);
                                break;
                            }
                        case "2DObjects":
                            {
                                parentAnimator.SetTrigger("didClick");
                                mainMenu.transform.GetChild(3).gameObject.SetActive(true);

                                break;
                            }
                        case "BrushSettings":
                            {

                                parentAnimator.SetTrigger("didClick");
                                mainMenu.transform.GetChild(4).gameObject.SetActive(true);

                                break;
                            }
                    }


                }

            }
            else
            {
                animator.SetBool("didSelect", false);

            }
        }
        if(!laserPointer.onCollison)
        {
            animator.SetBool("didSelect", false);

        }



    }
}
