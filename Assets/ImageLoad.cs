using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoad : MonoBehaviour
{
    public Texture texture1;
    public Button btn;
    PhysicsPointer laserPointer;
    Animator animator;
    Animator parentAnimator;
    GameObject mainMenu;

    private void Start()
    {
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
        //btn.onClick.AddListener(delegate { ChangeImg(); });
    }

    private void ChangeImg()
    {
        gameObject.GetComponent<RawImage>().texture = texture1;
    }
}
