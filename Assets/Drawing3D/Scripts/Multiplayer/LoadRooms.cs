using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadRooms : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    public GameObject roomInstance;
     GameObject currRoom;
    void Start()
    {

        Debug.Log("CountRooms====> "+MultiplayerControl.Instance.rooms.Count);
    

        foreach(var room in MultiplayerControl.Instance.rooms)
        {

            currRoom = Instantiate(roomInstance, Vector3.zero,Quaternion.identity);
            currRoom.transform.SetParent(transform.GetChild(0).GetChild(0).GetComponent<VerticalLayoutGroup>().transform, false);
            currRoom.GetComponent<Button>().name = room.Name;
            currRoom.transform.GetChild(0).GetComponent<Text>().text = room.Name;
            
        }


    }





   


}
