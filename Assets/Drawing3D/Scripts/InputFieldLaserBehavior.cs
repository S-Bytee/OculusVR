using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldLaserBehavior : MonoBehaviour
{

    PhysicsPointer laserPointer;
    // Start is called before the first frame update
    void Start()
    {
        laserPointer = PhysicsPointer.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(laserPointer.hit.collider)
        {
            if(laserPointer.hit.collider.gameObject == this.gameObject)
            {

                    EventSystem.current.SetSelectedGameObject(gameObject, null);
                    GetComponent<InputField>().OnPointerClick(new PointerEventData(EventSystem.current));

            }

        }
        
    }
}
