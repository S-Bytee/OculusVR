using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInputLaserBehavior : MonoBehaviour
{

    PhysicsPointer laserPointer;
    public GameObject KeyboardVR;

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
                    KeyboardVR.SetActive(true);
                }
            }

        }

        if (KeyboardVR.activeSelf)
            GetComponent<InputField>().text = KeyboardVR.GetComponent<KeyboardVRManager>().Text;
    }
}
