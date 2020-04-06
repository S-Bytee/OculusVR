using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsButtonBehavior : MonoBehaviour
{
    PhysicsPointer laserPointer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        laserPointer = PhysicsPointer.Instance;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (laserPointer.hit.collider)
        {
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {
                animator.SetBool("didSelect", true);

                if (Input.GetMouseButtonDown(0))
                {

                    this.gameObject.GetComponent<Button>().onClick.Invoke();
                  

                }

            }
            else
            {
                animator.SetBool("didSelect", false);

            }
        }
        if (!laserPointer.onCollison)
        {
            animator.SetBool("didSelect", false);

        }

    }
}
