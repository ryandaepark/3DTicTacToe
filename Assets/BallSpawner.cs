using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class BallSpawner : MonoBehaviour
{

    public GameObject redSphere;
    public GameObject blueSphere;
    public Stack<GameObject> lastMove;
    public Stack<Image> lastMoveButtonColor;
    //Fill UI targets through PlayerMoveClick in each 

    private Dictionary<string, GameObject> targets;
    private PhotonView photonView;
    private bool isP1;
    private Color p1_color = new Color32(255, 66, 66, 255);
    private Color p2_color = new Color32(57, 152, 255, 255);
    private List<PlayerCanvasHandler> uiCanvases;

    void Start()
    {
        photonView = GetComponent<PhotonView>();

        //Initialize
        lastMove = new Stack<GameObject>();
        lastMoveButtonColor = new Stack<Image>();
        uiCanvases = new List<PlayerCanvasHandler>();
        isP1 = GameObject.Find("PhotonPlayerHandler").GetComponent<PhotonPlayersHandler>().isP1;


        //Store all Transforms from all cube gameobjects into Dictionary for quick retrieval from 3D game model
        targets = new Dictionary<string, GameObject>();
        foreach (Transform child in transform)
        {
            foreach (Transform xy in child)
            {
                targets.Add(child.name + xy.name, xy.gameObject);
            }
        }
    }

    private void GetUiTargets()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("UiCube");
        foreach (GameObject player in players)
        {
            uiCanvases.Add(player.transform.GetComponentInChildren<PlayerCanvasHandler>());
            Debug.Log("Added canvas handler: " + player.transform.GetComponentInChildren<PlayerCanvasHandler>());
        }
    }

    public void SpawnBall(string input, bool isP1)
    {
        photonView.RPC(nameof(RPC_SpawnBall), RpcTarget.AllBuffered, new object[] { input, isP1 });
    }

    public void DeleteBall()
    {
        Debug.Log("RPC  delete ball");
        photonView.RPC(nameof(RPC_DeleteBall), RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void RPC_SpawnBall(string input, bool isP1)
    {
        GameObject target = targets[input];

        if(uiCanvases.Count == 0)
        {
            GetUiTargets();
        }

        //change color later
        if (target.transform.childCount < 1)
        {
            //update 3d model
            GameObject spawned = isP1 ? Instantiate(redSphere, target.transform) : Instantiate(blueSphere, target.transform);
            lastMove.Push(spawned);


            //update ui
            foreach(PlayerCanvasHandler uiCanvas in uiCanvases)
            {
                Image i = uiCanvas.Get3dImage(input);
                i.color = isP1 ? p1_color : p2_color;
                lastMoveButtonColor.Push(i);
            }
        }
    }

    [PunRPC]
    private void RPC_DeleteBall()
    {
        if (lastMove.Count > 0)
        {
            lastMoveButtonColor.Pop().color = Color.white;
            Destroy(lastMove.Pop());
        }
    }
}
