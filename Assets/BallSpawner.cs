using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    
    public GameObject redSphere;
    public GameObject blueSphere;
    public string ballTransform;

    private Dictionary<string, Dictionary<string, GameObject>> targets;

    // Start is called before the first frame update
    void Start()
    {
        //Store all Transforms from all cube gameobjects into Dictionary for quick retrieval
        targets = new Dictionary<string, Dictionary<string, GameObject>>();
        foreach (Transform child in transform)
        {
            Dictionary<string, GameObject> layer = new Dictionary<string, GameObject>();
            foreach(Transform xy in child)
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

    //Needs to be tested if functional!!!!
    private GameObject ReadString()
    {
        string[] xyz = ballTransform.Split(' ');

        Dictionary<string, GameObject> layer = targets[xyz[0]];

        return layer[xyz[1]];
    }
}