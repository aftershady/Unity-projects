using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Transform checkPoint;
    public GameObject gameOverUI;
    public static GameOverManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance GameOverManager");
        }
        instance = this;
    }

    public void OnPlayerDeath()
    {
        if(CurrentSceneManager.instance.isPlayerPresentByDefault == true)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        gameOverUI.SetActive(true);
        TimerDisplay.instance.PauseTimer();
    }

    public void RetryButton()
    {
        TimerDisplay.instance.Continue();
        // if the player has taken the checkpoint, respawn at the checkpoint
        if(CurrentSceneManager.instance.isPlayerHaveTakenTheCheckpoint)
        {
            checkPoint = GameObject.FindGameObjectWithTag("CheckPoint").transform;
            PlayerHealth.instance.transform.position = checkPoint.position;
        }
        // if the player has not taken the checkpoint, respawn at the start of the level
        else if(CurrentSceneManager.instance.isPlayerPresentByDefault == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerHealth.instance.Respawn();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Inventory.instance.ResetCoins();
        gameOverUI.SetActive(false);

        // Reset the player position and health if player is not present by default
        if(CurrentSceneManager.instance.isPlayerPresentByDefault == false && SceneManager.GetActiveScene().name != "Level 03")
        {
            PlayerHealth.instance.Respawn();
            AudioManager.instance.audioSource.clip = AudioManager.instance.playlist[0];
        }
        // if level is level 03 do the same as above but with the second clip
        else if (CurrentSceneManager.instance.isPlayerPresentByDefault == false && SceneManager.GetActiveScene().name == "Level 03")
        {
            PlayerHealth.instance.Respawn();
            AudioManager.instance.audioSource.clip = AudioManager.instance.playlist[1];
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
