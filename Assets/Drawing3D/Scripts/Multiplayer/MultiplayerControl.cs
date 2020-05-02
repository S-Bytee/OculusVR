using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;
using UnityEngine.UI;

public class MultiplayerControl : MonoBehaviourPunCallbacks
{
    private static MultiplayerControl _instance;
    public static MultiplayerControl Instance { get { return _instance; } }

    public List<RoomInfo> rooms;


    [SerializeField]
    GameObject wheelCanvas;

    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        connect();
        GameManager.print("Multiplayer Mode On");
        PlayerPrefs.SetString("RoomName", "");
        PlayerPrefs.Save();



    }
    private void Start()
    {
        if (_instance != null && _instance != this)
        {
           // Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby successfully");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
   {

   
       Debug.Log("Failed to join room" + message);

       base.OnJoinRandomFailed(returnCode, message);

   }


   public override void OnJoinedRoom()
   {
       Debug.Log("Joined a room successfully ");

       startGame();
       base.OnJoinedRoom();

   }


    
   public void connect()
   {
       Debug.Log("Trying to connect ...");
       PhotonNetwork.GameVersion = "0.0.1";
       PhotonNetwork.ConnectUsingSettings();

    }

    public void join()
   {

        string room_name = wheelCanvas.transform.GetChild(7).GetChild(1).GetChild(8).GetChild(0).GetChild(0).GetComponent<InputField>().text;
        if (!room_name.Equals(""))
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = byte.MaxValue;
            PhotonNetwork.JoinOrCreateRoom(room_name, options, TypedLobby.Default);
            

        } 
        else
        {
            wheelCanvas.transform.GetChild(7).GetChild(1).GetChild(8).GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(true);
        }
        //PhotonNetwork.JoinRandomRoom();
    }

    public void startGame()
   {

       if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
       {
           PhotonNetwork.LoadLevel("MultiplayerDrawing");
           Debug.Log("Name ======> "+PhotonNetwork.CurrentRoom.Name);
       }

   }

   

   public override void OnConnectedToMaster()
    {

        Debug.Log("Connected successfully ");

        PhotonNetwork.JoinLobby(TypedLobby.Default);
      
    }

    public override void OnCreatedRoom()
    {

        base.OnCreatedRoom();
        GameManager.print("Created Room successfully");
        Debug.Log("Created Room");

    }

 

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        Debug.Log("Room count ---->  " + roomList.Count);


        rooms = roomList;

        /*foreach (var room in roomList)
        {
            Debug.Log(room.Name);
        }*/
        
       
    }

    /*  public void OnClick_CreateRoom()
      {
          RoomOptions options = new RoomOptions();
          options.MaxPlayers = byte.MaxValue;
          PhotonNetwork.JoinOrCreateRoom("NAMMMEEE", options, TypedLobby.Default);
      }


      public override void OnCreatedRoom()
      {

          base.OnCreatedRoom();
          GameManager.print("Created Room successfully");
          Debug.Log("Created Room");

      }

      public override void OnCreateRoomFailed(short returnCode, string message)
      {

          base.OnCreateRoomFailed(returnCode, message);
          GameManager.print("Room Creation Failed");

      }



      **/



}
