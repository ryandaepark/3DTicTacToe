using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasHandler : MonoBehaviour
{
    public GameObject Panel;
    
    public void ToggleUI(bool toggled)
    {
        Panel.SetActive(toggled);
    }

}
