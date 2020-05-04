using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPointerBehavior : MonoBehaviour
{


    PhysicsPointer laserPointer;
    Animator animator;
    Animator parentAnimator;
    GameObject mainMenu;
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
                
                if (Input.GetMouseButtonDown(0))
                {

                    

                        
                            
                                SceneManager.LoadScene(1);
                                
                            
                        
                        
                        
                    


                }

            }
            
        }
       



    }
}

