using Photon.Pun.Demo.Procedural;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiplayerDrawingNavigator : MonoBehaviour
{

    GameObject multiplayer_center_wheel;
    [SerializeField]
    int create_room_index = 0;
    int create_join_index = 1;
    // Start is called before the first frame update
    void Start()
    {
        multiplayer_center_wheel = transform.parent.GetChild(1).GetChild(8).gameObject;
        disableAll();
        enableCenterImage(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void disableAll()
    {
        enableCenterImage(false);
        for(int i =0;i<multiplayer_center_wheel.transform.childCount;i++)
        {
            multiplayer_center_wheel.transform.GetChild(i).gameObject.SetActive(false);

        }
    }

    public void enableCenterImage(bool enable)
    {
        multiplayer_center_wheel.GetComponent<TextMeshProUGUI>().enabled = enable;
    }

    public void showCreateRoom()
    {
        disableAll();
        multiplayer_center_wheel.transform.GetChild(create_room_index).gameObject.SetActive(true);
    }

    public void showJoinRoom()
    {
        disableAll();
        multiplayer_center_wheel.transform.GetChild(create_join_index).gameObject.SetActive(true);
    }

}
