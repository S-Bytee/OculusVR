using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameMultiplayer : MonoBehaviourPunCallbacks
{


    string playerName;
    // Start is called before the first frame update
    void Start()
    {

        if (photonView.IsMine)
        {

        }

        playerName = PlayerPrefs.GetString("username");

        transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerName;

    }


}
