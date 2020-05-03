using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameMultiplayer : MonoBehaviourPunCallbacks,IPunObservable
{


    string playerName;

   

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.NickName = PlayerPrefs.GetString("username");
        
        transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.NickName;

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    
        if(stream.IsWriting)
        {
            stream.SendNext(transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text);
        }
        else
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = (string)stream.ReceiveNext();
        }
    

    }
}
