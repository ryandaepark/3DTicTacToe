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
/*    public Dictionary<string, Image> uiTargets;
*/
    private Dictionary<string, Dictionary<string, GameObject>> targets;
    private PhotonView photonView;
    private bool isP1;
    private Color p1_color = new Color32(255, 66, 66, 255);
    private Color p2_color = new Color32(57, 152, 255, 255);
    private GameObject playerSphere;

    void Start()
    {
        photonView = GetComponent<PhotonView>();

        //Initialize
        lastMove = new Stack<GameObject>();
        lastMoveButtonColor = new Stack<Image>();
/*        uiTargets = new Dictionary<string, Image>();
*/
        isP1 = GameObject.Find("PhotonPlayerHandler").GetComponent<PhotonPlayersHandler>().isP1;
        playerSphere = isP1 ? redSphere : blueSphere;
       

        //Store all Transforms from all cube gameobjects into Dictionary for quick retrieval from 3D game model
        targets = new Dictionary<string, Dictionary<string, GameObject>>();
        foreach (Transform child in transform)
        {
            Dictionary<string, GameObject> layer = new Dictionary<string, GameObject>();
            foreach (Transform xy in child)
            {
                layer.Add(xy.name, xy.gameObject);
            }
            targets.Add(child.name, layer);
        }
    }

    public void SpawnBall(string input, Image image, bool isP1)
    {
        /*Debug.Log(uiTargets.Count);
        Debug.Log("RPC  spawn ball");
        photonView.RPC(nameof(RPC_SpawnBall), RpcTarget.AllBuffered, new object[] { input, isP1 });*/

        string[] xyz = input.Split(' ');
        Dictionary<string, GameObject> layer = targets[xyz[0]];
        GameObject target = layer[xyz[1]];

        //change color later
        if (target.transform.childCount < 1)
        {
            //update 3d model
            var spawned = isP1 ? Instantiate(redSphere, target.transform) : Instantiate(blueSphere, target.transform);
            lastMove.Push(spawned);
            lastMoveButtonColor.Push(image);
            image.color = isP1 ? p1_color : p2_color;

            //update ui 
            /*  if (uiTargets.TryGetValue(input, out Image value))
              {

                  lastMoveButtonColor.Push(value);
                  value.color = isP1 ? p1_color : p2_color;
              }
              else
              {
                  Debug.Log("ui target not found");
              }*/

        }
    }

    public void DeleteBall()
    {
        Debug.Log("RPC  delete ball");
        photonView.RPC(nameof(RPC_DeleteBall), RpcTarget.AllBuffered);
    }

/*    [PunRPC]
    private void RPC_SpawnBall(string input, bool isP1)
    {
        string[] xyz = input.Split(' ');
        Dictionary<string, GameObject> layer = targets[xyz[0]];
        GameObject target = layer[xyz[1]];

        //change color later
        if (target.transform.childCount < 1)
        {
            //update 3d model
            var spawned = isP1 ? Instantiate(redSphere, target.transform) : Instantiate(blueSphere, target.transform);
            lastMove.Push(spawned);

            //update ui 
            if (uiTargets.TryGetValue(input, out Image value))
            {

                lastMoveButtonColor.Push(value);
                value.color = isP1 ? p1_color : p2_color;
            }
            else
            {
                Debug.Log("ui target not found");
            }

        }
    }*/

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
