using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonMultiPlayer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(photonView.IsMine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
