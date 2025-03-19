using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == false)
        {
            pauseMenu.GetComponent<PauseMenu>().Paused();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf)
        {
            pauseMenu.GetComponent<PauseMenu>().Resume();
        }
    }

}
