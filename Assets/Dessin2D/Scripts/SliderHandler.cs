using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SliderHandler : MonoBehaviour
{
    PhysicsPointer laserPointer;

    // Variable hedhaa besh ihot fih l position mtaa awel matenzel bel lazer aal slider 
    Vector3 firstPosition;
    //Variable  
    Vector3 updatedPosition;
    // l variable hedha fih ouakteli enty nezel aal souris 
    bool ondrag = false;
    void Start()
    {
        laserPointer = PhysicsPointer.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        //Ken fama collision
        if (laserPointer.hit.collider)
        {
            //Idha l laser mteena mass fi objet mawjoud fih l script hedhaa 
            if (laserPointer.hit.collider.gameObject == this.gameObject)
            {
         
                //Awel matenzel bel souris aal slider besh tkhabi l postion mtaa nazla
                if (Input.GetMouseButtonDown(0))
                {

                    firstPosition = laserPointer.hit.point;    
                           
                }
                //Tant que enty nezeel aal slider besh tkhabi l position mtaa nazla
                if(Input.GetMouseButton(0))
                {

                    updatedPosition = laserPointer.hit.point;
                    ondrag = true;
                }
                else
                {
                    ondrag = false;
                }

                //Tant que enty nazel aamel comparaison bin l x mtaa aweeel manzelt aal slider 
                //                   o l x mtaa ouin enty kaaaed thaarek fel souris aal slider
                
                if (ondrag)
                {

                    //Idha ken awel manzel o aamalt drag aal lisaar donc naakes fel value mtaa slider
                    if (firstPosition.x > updatedPosition.x) GetComponent<Slider>().value -= 1f;
                    if (firstPosition.x < updatedPosition.x) GetComponent<Slider>().value += 1f;

                }
            }

        }
    }
}
