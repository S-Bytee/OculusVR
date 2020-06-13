using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CanvasHandler : MonoBehaviour
{
    PhysicsPointer laserPointer;
    Button btn;
    Transform initialTransform;
    float initialX=0f;
    float initialY=0f;
    float newXvalue = 0f;
    float newYvalue = 0f;

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
            if(laserPointer.hit.collider.gameObject.tag== "ButtonCanvas")
            {
                initialX = laserPointer.hit.collider.gameObject.transform.localScale.x;
                initialY = laserPointer.hit.collider.gameObject.transform.localScale.y;
                laserPointer.hit.collider.gameObject.transform.localScale =  new Vector2( 0.7f,  0.3f);


                if (Input.GetMouseButtonDown(0) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
                {                                      

                    laserPointer.hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                
                }
            }
            else
            {
                returnToInitialScale();
            }
        }
        
        if(!laserPointer.onCollison)
            returnToInitialScale();

    }

    public void returnToInitialScale()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("ButtonCanvas"))
        {
            go.transform.localScale = new Vector2(initialX, initialY);
        }
    }
}
