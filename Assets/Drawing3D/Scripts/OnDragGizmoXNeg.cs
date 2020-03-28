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
        parent = transform.parent.transform.parent;
 
    }

    // Update is called once per frame
    void Update()
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
            if(lasetInstance.hit.collider.gameObject==this.gameObject)
            {
                //Ken kaaad nezeeel aal souris o houaa fel fleche l gris mtaa -X 
                if(onDrag)
                {
             
                    x+=0.3f;
                    parent.localScale = new Vector3(-x+parent.localScale.x  , parent.localScale.y,parent.localScale.z );

                }
                else
                {
                    x = 0;
                }
            }
        }
    }
}
