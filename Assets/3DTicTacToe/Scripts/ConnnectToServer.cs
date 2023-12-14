using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConnnectToServer : MonoBehaviourPunCallbacks
{
    public GameObject Loading;
    public GameObject Buttons;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("hello 1");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("hello 2");
        Loading.SetActive(false);
        Buttons.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Playground");
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("Playground");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("Playground");
    }
}
    // Update is called once per frame
    
   
