using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTypingProjectCreation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         switch(PlayerPrefs.GetInt("ProjectCreationError"))
        {
            case 0:
                {
                    hideAll();
                    break;
                }
            case 1:
                {
                    hideAll();
                    transform.GetChild(0).gameObject.SetActive(true);
                    break;
                }
            case 2:
                {
                    hideAll();
                    transform.GetChild(1).gameObject.SetActive(true);
                    break;
                }


        }
    }

    public void hideAll()
    {
        for(int i =0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
