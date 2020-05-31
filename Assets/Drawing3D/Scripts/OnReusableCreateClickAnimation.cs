using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnReusableCreateClickAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void PlayAnimation()
    {

        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(2).GetComponent<Animator>().SetBool("active",true);
        transform.GetChild(2).GetComponent<Animator>().SetFloat("direction", 1);
        transform.parent.GetChild(4).GetComponent<Animator>().SetBool("active",true);
        transform.parent.GetChild(4).GetComponent<BoxCollider>().enabled=true;
             
    }

}
