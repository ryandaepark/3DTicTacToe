using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMoveClick : MonoBehaviourPun
{
    private BallSpawner bs;
    private Color playerColor;
    private Image image;
    private bool isP1;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        bs = GameObject.Find("3D Container").GetComponent<BallSpawner>();
        isP1 = GameObject.Find("PhotonPlayerHandler").GetComponent<PhotonPlayersHandler>().isP1;

        /*        bs.uiTargets.Add(gameObject.transform.parent.name + ' ' + gameObject.name, image);
        */
        //If performance affected, make public and assign manually
        /*if (GameObject.Find("PhotonPlayerHandler").GetComponent<PhotonPlayersHandler>().isP1)
        {
            playerColor = new Color32(255, 66, 66, 255);
        } else
        {
            playerColor = new Color32(57, 152, 255, 255);
        }*/
    }


    public void OnClick()
    {
        photonView.RPC(nameof(RPC_PlayerMove), RpcTarget.AllBuffered, new object[] { isP1 });
    }

    [PunRPC]
    private void RPC_PlayerMove(bool isP1)
    {
        //send text of parent and button with stringbuilder to ball spawner in BallSpawner.cs
        string target = gameObject.transform.parent.name + " " + gameObject.name;
/*        image.color = isP1 ? new Color32(255, 66, 66, 255): new Color32(57, 152, 255, 255);
*/        
        bs.SpawnBall(target, image, isP1);
    }
}
