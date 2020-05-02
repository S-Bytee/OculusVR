using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviourPunCallbacks
{

    PhysicsPointer laserPointer;

    // Start is called before the first frame update
    void Start()
    {
        laserPointer = PhysicsPointer.Instance;

    }
    public void Update()
    {

        if (laserPointer.hit.collider.gameObject == this.gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetString("RoomName", GetComponent<Button>().name);
                PlayerPrefs.Save();
                

                this.gameObject.GetComponent<Button>().onClick.Invoke();
            
                
            }


        }

    }
    public void joinRoom()
    {

        PhotonNetwork.JoinRoom(PlayerPrefs.GetString("RoomName", ""));
    
    }
}
