using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasHandler : MonoBehaviour
{
    public GameObject Panel;
    public GameObject uiCube;
    public Dictionary<string, Image> uiTargets;
    public Button backButton;
    public Button clearButton;

    public void Start()
    {
        //Store all Transforms from all ui cube buttons
        uiTargets = new Dictionary<string, Image>();
        foreach (Transform child in uiCube.transform)
        {
            foreach (Transform xy in child)
            {
                uiTargets.Add(child.name + xy.name, xy.GetComponent<Image>());
            }
        }
        BallSpawner bs = GameObject.Find("3D Container").GetComponent<BallSpawner>();
        backButton.onClick.AddListener(() => bs.DeleteBall());
        clearButton.onClick.AddListener(() => bs.ClearBoard());
    }

    public void ToggleUI(bool toggled)
    {
        Panel.SetActive(toggled);
    }

    public Image Get3dImage (string s)
    {
        return uiTargets[s];
    }

}
