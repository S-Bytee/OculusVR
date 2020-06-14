using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldKeyBoard : MonoBehaviour
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
            if ((Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) && laserPointer.hit.collider.gameObject == this.gameObject )
                {
                KeyboardVR.GetComponent<KeyboardVRManager>().Text = "";
                PlayerPrefs.SetString("key",this.gameObject.name);
                     EventSystem.current.SetSelectedGameObject(gameObject, null);
                    GetComponent<InputField>().OnPointerClick(new PointerEventData(EventSystem.current));
                    KeyboardVR.SetActive(true);
                }

        }

        if (KeyboardVR.activeSelf && PlayerPrefs.GetString("key").Equals(this.gameObject.name))
            GetComponent<InputField>().text = KeyboardVR.GetComponent<KeyboardVRManager>().Text;
    }
}
