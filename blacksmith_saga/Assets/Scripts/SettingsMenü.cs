using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.Fullscreen = isFullscreen;
    }
}
