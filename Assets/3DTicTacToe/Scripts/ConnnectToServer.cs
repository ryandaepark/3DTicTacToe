using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnnectToServer : MonoBehaviourPunCallbacks
{
    public GameObject Loading;
    public GameObject Buttons;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Loading.SetActive(false);
        Buttons.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("3DTicTacToe");
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom("3DTicTacToe", roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("3DTicTacToe");
    }
}
    
   
