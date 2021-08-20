using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuCanvas = null;

    void Start()
    {
        pauseMenuCanvas.enabled = false;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) == true)
        {
            pauseMenuCanvas.enabled = true;
            Time.timeScale = 0;
        }
    }
}
