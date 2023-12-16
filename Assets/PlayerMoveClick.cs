using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveClick : MonoBehaviour
{
    private Button buttonColor;
    private Color p1_color;
    private Color p2_color;
    private BallSpawner bs;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonColor = gameObject.GetComponent<Button>();
        p1_color = new Color(255, 66, 66, 255);
        p2_color = new Color(57, 152, 255, 255);
        bs = GameObject.Find("3D Container").GetComponent<BallSpawner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        //send text of parent and button with stringbuilder to ball spawner in BallSpawner.cs
        string target = gameObject.transform.parent.name + " " + gameObject.name;

        //change later when p2 works
        buttonColor.colors.normalColor.Equals(p1_color);

        bs.SpawnBall(target);
    }
}
