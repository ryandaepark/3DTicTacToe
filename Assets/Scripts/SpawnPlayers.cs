using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnPlayers : MonoBehaviour
{
    public GameObject PlayerPrefab;

    void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name, transform.position, Quaternion.identity);
    }
}
