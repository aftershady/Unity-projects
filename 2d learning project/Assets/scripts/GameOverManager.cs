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
    }

    public void RetryButton()
    {

        if(CurrentSceneManager.instance.isPlayerHaveTakenTheCheckpoint)
        {
            checkPoint = GameObject.FindGameObjectWithTag("CheckPoint").transform;
            PlayerHealth.instance.transform.position = checkPoint.position;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Inventory.instance.ResetCoins();
        gameOverUI.SetActive(false);
        if(CurrentSceneManager.instance.isPlayerPresentByDefault == false && SceneManager.GetActiveScene().name != "Level 03")
        {
            PlayerHealth.instance.Respawn();
            AudioManager.instance.audioSource.clip = AudioManager.instance.playlist[0];
        }
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
