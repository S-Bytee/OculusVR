using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDragGizmoYNeg : MonoBehaviour
{


    PhysicsPointer lasetInstance;
    float x;
    bool onDrag = false;
    Transform parent;

    // Start is called before the first frame update
    void Start()
    {

        lasetInstance = PhysicsPointer.Instance;
        parent = getSelectedObject();

    }

    // Update is called once per frame
    void Update()
    {

        scaleObject();

    }

    public void scaleObject()
    {

        //Ken kaaaad nezeel aal souris
        if (Input.GetMouseButton(0))
        {
            onDrag = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            onDrag = false;
        }

        if (lasetInstance.hit.collider)
        {
            if (lasetInstance.hit.collider.gameObject == this.gameObject)
            {
                //Ken kaaad nezeeel aal souris o houaa fel fleche l gris mtaa -X 
                if (onDrag)
                {

                    x += 0.3f * Time.deltaTime;
                    parent.localScale = new Vector3(parent.localScale.x, -x + parent.localScale.y, parent.localScale.z);

                }
                else
                {
                    x = 0;
                }
            }
        }
    }
    public Transform getSelectedObject()
    {

        GameObject selectedObject = null;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("object"))
        {

            if (go.GetComponentInChildren<OnSelectObject>().isClicked)
            {

                selectedObject = go.transform.GetChild(0).gameObject;

            }
        }

        return selectedObject.transform.parent.transform;

    }
}
