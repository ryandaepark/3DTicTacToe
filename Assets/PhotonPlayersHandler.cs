using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class PhotonPlayersHandler : MonoBehaviourPunCallbacks
{
    public bool isP1 = false;
    public bool myTurn = false;
    
    void Awake()
    {
        if(PhotonNetwork.IsMasterClient) {isP1 = true; } 
        if(isP1) { myTurn = true; }
    }
}
