using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;

    private bool isGameLoaded = false;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance LoadAndSaveData");
        }
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
        isGameLoaded = PlayerPrefs.GetInt("isGameLoaded", 0) == 1;
        if(isGameLoaded == true)
        {
            LoadData();
            PlayerPrefs.SetInt("isGameLoaded", 0);
        }

    }

    public void continueGame()
    {
        PlayerPrefs.SetInt("isGameLoaded", 1);
        int levelIndex = PlayerPrefs.GetInt("Level");
        if (levelIndex == 0)
        {
            levelIndex = 1;
        }
        SceneManager.LoadScene(levelIndex);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("PlayerHealth", PlayerHealth.instance.currentHealth);
        PlayerPrefs.SetInt("CoinsCount", Inventory.instance.coinsCount);
        if (SceneManager.GetActiveScene().name == "Level 02")
        {
            PlayerPrefs.SetInt("Level", 3); // Assuming "Level 02-2" corresponds to build index 3
        }
        else if (SceneManager.GetActiveScene().name == "Level 03")
        {
            
            PlayerPrefs.SetInt("Level", 5); // Assuming "Level 03" corresponds to build index 5
        }
        else
        {
            Debug.Log("LoadAndSaveData Start");
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        }
        PlayerPrefs.SetFloat("PlayerPositionX", PlayerMovement.instance.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", PlayerMovement.instance.transform.position.y);
        PlayerPrefs.SetInt("TimerMinutes", TimerDisplay.instance.minutes);
        PlayerPrefs.SetInt("TimerSeconds", TimerDisplay.instance.seconds);
    }

    public void LoadData()
    {
        PlayerHealth.instance.currentHealth = PlayerPrefs.GetInt("PlayerHealth");
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("CoinsCount");
        float playerPosX = PlayerPrefs.GetFloat("PlayerPositionX");
        float playerPosY = PlayerPrefs.GetFloat("PlayerPositionY");
        PlayerMovement.instance.transform.position = new Vector3(playerPosX, playerPosY, 0);
        TimerDisplay.instance.minutes = PlayerPrefs.GetInt("TimerMinutes");
        TimerDisplay.instance.seconds = PlayerPrefs.GetInt("TimerSeconds");
    }

}
