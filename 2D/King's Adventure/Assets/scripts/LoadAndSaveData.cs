using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance LoadAndSaveData");
        }
        instance = this;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("PlayerHealth", PlayerHealth.instance.currentHealth);
        PlayerPrefs.SetInt("CoinsCount", Inventory.instance.coinsCount);
        if (SceneManager.GetActiveScene().name == "Level 01")
        {
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        }
        else if (SceneManager.GetActiveScene().name == "Level 02")
        {
            PlayerPrefs.SetInt("Level", 3); // Assuming "Level 02-2" corresponds to build index 3
        }
        else if (SceneManager.GetActiveScene().name == "Level 03")
        {
            PlayerPrefs.SetInt("Level", 5); // Assuming "Level 03" corresponds to build index 5
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
        int levelIndex = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(levelIndex);
        float playerPosX = PlayerPrefs.GetFloat("PlayerPositionX");
        float playerPosY = PlayerPrefs.GetFloat("PlayerPositionY");
        PlayerMovement.instance.transform.position = new Vector3(playerPosX, playerPosY, 0);
        TimerDisplay.instance.minutes = PlayerPrefs.GetInt("TimerMinutes");
        TimerDisplay.instance.seconds = PlayerPrefs.GetInt("TimerSeconds");
    }

}
