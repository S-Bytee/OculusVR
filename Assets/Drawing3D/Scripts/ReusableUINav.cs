using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReusableUINav : MonoBehaviour
{

    GameObject ReusableUI;

    // Start is called before the first frame update
    void Start()
    {
        ReusableUI = transform.GetChild(0).gameObject;      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ShowCenterText()
    {
        DisableReusableUI();
        GetComponent<TextMeshProUGUI>().enabled = true;
    }


    void DisableReusableUI()
    {
        for (int i = 0; i < ReusableUI.transform.childCount; i++)
        {
            ReusableUI.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void ShowReusableUI()
    {
        GetComponent<TextMeshProUGUI>().enabled = false;

        for (int i = 0; i < ReusableUI.transform.childCount; i++)
        {
            ReusableUI.transform.GetChild(i).gameObject.SetActive(true);
        }

        transform.GetChild(0).GetComponent<Animator>().SetTrigger("active"); 
    }

}
