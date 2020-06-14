using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateObject : MonoBehaviour
{

    bool IsFadeActive=false;
    float x = 255f;
    public float FadeSpeed=0.2f;
    public float FadeLimit=150f;


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
       // if (IsFadeActive)
            Animate();
    }


    private void OnEnable()
    {
        ActivateFadeInObjects();
    }

    private void OnDisable()
    {
        DisactiveFadeInObjects();
    }



    void Animate()
    {
        x -= FadeSpeed;

        if(x<FadeLimit)
        {
            Debug.Log("FadeLimit");
            x =  254f;
        }
        Debug.Log(x);
        GetComponent<Renderer>().material.color = Color.Lerp(new Color(0.5f, 0.5f, 0.5f, 0.5f), new Color(0f, 0f, 0f, 0f), x);
    }

    void ActivateFadeInObjects()
    {

        transform.GetComponent<Renderer>().material.SetFloat("_Mode", 2f);
        IsFadeActive = true;
    }

    void DisactiveFadeInObjects()
    {
        IsFadeActive = false;
        transform.GetComponent<Renderer>().material.SetFloat("_Mode", 0f);

        /* for (int i = 0; i < transform.childCount; i++)
         {
             if (transform.GetChild(i).gameObject.tag == "object")
             {
                 transform.GetChild(i).GetChild(0).GetComponent<Renderer>().material.SetFloat("_Mode", 0f);
             }
             else if (transform.GetChild(i).gameObject.tag == "lineRenderer")
             {
                 transform.GetChild(i).GetComponent<Renderer>().material.SetFloat("_Mode", 0f);

             }
         }*/


    }
}
