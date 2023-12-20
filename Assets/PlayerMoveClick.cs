using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMoveClick : MonoBehaviourPun
{
    private BallSpawner bs;
    private bool isP1;

    // Start is called before the first frame update
    void Start()
    {
        bs = GameObject.Find("3D Container").GetComponent<BallSpawner>();
        isP1 = GameObject.Find("PhotonPlayerHandler").GetComponent<PhotonPlayersHandler>().isP1;
    }


    public void OnClick()
    {
        string target = gameObject.transform.parent.name + gameObject.name;
        bs.SpawnBall(target, isP1); //change ui image by storing map once 
    }
}
