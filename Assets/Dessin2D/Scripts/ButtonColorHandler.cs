using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonColorHandler : MonoBehaviour
{

    PhysicsPointer laserPointer;
    
    Vector2 initialScale;
    Vector2 newScaleWhenSelected;
    [SerializeField]
    Vector2 offsetWhenSelected;
    // Start is called before the first frame update
    void Start()
    {
     
        //Nkhabiw l scale l initial fi variable
        initialScale = this.gameObject.transform.localScale;
        //nkhabiw l scale l jdid fi variable o nzid aalih vector sghir o besh naaytoulou ouakteli tji aalih l selection
        newScaleWhenSelected = initialScale + offsetWhenSelected;
        //l instance mtaa laser mteena
        laserPointer = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        //Idha l laser mteena aamal collision
        if (laserPointer.hit.collider)
        {
            //Idha l laser mteena mass fi objet mawjoud fih l script hedhaa 
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {
                //Aatih scale jdid
                this.gameObject.transform.localScale = newScaleWhenSelected;

                //Idhaa nzelna aala bouton
                if (Input.GetMouseButtonDown(0))
                {
                    //Aaamel invoke lel bouton yaani rod l bouton tnezleet
                    this.gameObject.GetComponent<Button>().onClick.Invoke();

                }
            }
            else
            {   //idha mafamesh collision maa l gameobject eli nahna fih erjaa lel scale initial
                returnToInitialScale();
            }
        }
        //idha mafamesh collision jemlaaa erjaa lel scale initial
        if (!laserPointer.onCollison)
            returnToInitialScale();

    }


    public void returnToInitialScale()
    {
        this.gameObject.transform.localScale = initialScale;
    }
}
