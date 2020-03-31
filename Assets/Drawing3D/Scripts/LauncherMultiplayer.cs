using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LauncherMultiplayer : MonoBehaviourPunCallbacks
{

    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        connect();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected successfully ");

        join();
        base.OnConnectedToMaster();
    }



    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        create();

        Debug.Log("Failed to join room" + message);

        base.OnJoinRandomFailed(returnCode, message);
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room successfully ");

        startGame();
        base.OnJoinedRoom();
    }


    public void create()
    {
        PhotonNetwork.CreateRoom("");
    }
    public void connect()
    {
        Debug.Log("Trying to connect ...");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void join()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void startGame()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.LoadLevel(1);
        }
    }




}
