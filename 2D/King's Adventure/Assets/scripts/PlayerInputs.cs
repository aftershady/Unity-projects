using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsWindow;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == false && PlayerHealth.instance.currentHealth > 0)
        {
            pauseMenu.GetComponent<PauseMenu>().Paused();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf)
        {
            if (settingsWindow.activeSelf)
            {
                settingsWindow.SetActive(false);
            }
            else
            {
            pauseMenu.GetComponent<PauseMenu>().Resume();
            }
        }
    }
}
