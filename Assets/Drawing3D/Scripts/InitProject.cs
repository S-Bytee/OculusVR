using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitProject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("ProjectName") == "")
        {
            GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color32(144, 142, 140,255);
        }
        else
        {
            gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
            GetComponent<BoxCollider>().enabled = true;

        }



    }
}
