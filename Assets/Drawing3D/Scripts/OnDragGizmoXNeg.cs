using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDragGizmoXNeg : MonoBehaviour
{

    PhysicsPointer lasetInstance;
    float x;
    bool onDrag = false;
    Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        lasetInstance = PhysicsPointer.Instance;
        parent = GameObject.Find("newCube").transform;
    
    }

    // Update is called once per frame
    void Update()
    {
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
            if(lasetInstance.hit.collider.gameObject==this.gameObject)
            {
                if(onDrag)
                {
                    x++;
                    parent.localScale = new Vector3(parent.localScale.x * -x, parent.localScale.y,parent.localScale.z );

                }
            }
        }
    }
}
