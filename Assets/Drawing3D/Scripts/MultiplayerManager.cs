 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MultiplayerManager : MonoBehaviourPunCallbacks
{

    public string player_prefab;
    public Transform spawn_point;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }
    public void spawn()
    {
        PhotonNetwork.Instantiate(player_prefab, spawn_point.position, spawn_point.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void leaveRoom()
    {

        if(photonView.IsMine)
        {
            PhotonNetwork.LoadLevel("Drawing_3D");
            PhotonNetwork.LeaveRoom();

        }


    }
}
