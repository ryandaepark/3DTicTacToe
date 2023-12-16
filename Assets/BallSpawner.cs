using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{

    public GameObject redSphere;
    public GameObject blueSphere;
    public Stack<GameObject> lastMove;
    public Stack<Image> lastMoveButtonColor;
    
    private Dictionary<string, Dictionary<string, GameObject>> targets;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize
        lastMove = new Stack<GameObject>();
        lastMoveButtonColor = new Stack<Image>();
        

        //Store all Transforms from all cube gameobjects into Dictionary for quick retrieval
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

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBall(string input, Image buttonColor)
    {
        string[] xyz = input.Split(' ');
        Dictionary<string, GameObject> layer = targets[xyz[0]];
        GameObject target = layer[xyz[1]];

        //change color later
        if (target.transform.childCount < 1)
        {
            var spawned = Instantiate(redSphere, target.transform);
            lastMove.Push(spawned);
            lastMoveButtonColor.Push(buttonColor);
        } 
    }

    //Change the color of the button back to white if delete
    public void DeleteBall()
    {
        if(lastMove.Count > 0)
        {
            lastMoveButtonColor.Pop().color = Color.white;
            Destroy(lastMove.Pop());
        }
    }
}
