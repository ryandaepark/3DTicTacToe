using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class PhotonPlayersHandler : MonoBehaviour
{
    public bool isP1 = false;
    public bool myTurn = false;

    void Start()
    {
        if(PhotonNetwork.CountOfPlayers == 1) { isP1 = true; } 
        if(isP1) { myTurn = true; }
    }

    void Update()
    {
        
    }

}
