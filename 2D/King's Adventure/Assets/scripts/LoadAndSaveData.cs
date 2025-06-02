using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;

    private bool isGameLoaded = false;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance LoadAndSaveData");
        }
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
        isGameLoaded = PlayerPrefs.GetInt("isGameLoaded", 0) == 1;
        if (isGameLoaded == true)
        {
            LoadDataManually();
            LoadPlayerPosition();
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
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("TimerMinutes", TimerDisplay.instance.minutes);
        PlayerPrefs.SetInt("TimerSeconds", TimerDisplay.instance.seconds);

        //sauvegarde items
        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        Debug.Log("Items in inventory: " + itemsInInventory);
    }

    public void SaveDataManually()
    {
        PlayerPrefs.SetInt("ManPlayerHealth", PlayerHealth.instance.currentHealth);
        PlayerPrefs.SetInt("ManCoinsCount", Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("ManLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("ManTimerMinutes", TimerDisplay.instance.minutes);
        PlayerPrefs.SetInt("ManTimerSeconds", TimerDisplay.instance.seconds);
        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        Debug.Log("Items in inventory: " + itemsInInventory);
        string[] itemsSaved = itemsInInventory.Split(',');
    }

        public void LoadDataManually()
    {
        PlayerHealth.instance.currentHealth = PlayerPrefs.GetInt("ManPlayerHealth");
        PlayerHealth.instance.healthBar.SetHealth(PlayerPrefs.GetInt("ManPlayerHealth"));
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("ManCoinsCount");
        Inventory.instance.coinsCountText.text = PlayerPrefs.GetInt("ManCoinsCount").ToString();
        TimerDisplay.instance.elapsedTime = (PlayerPrefs.GetInt("ManTimerMinutes") * 60) + PlayerPrefs.GetInt("TimerSeconds");
    }



    public void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("PlayerPositionX", PlayerMovement.instance.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", PlayerMovement.instance.transform.position.y);
    }

    public void LoadData()
    {
        PlayerHealth.instance.currentHealth = PlayerPrefs.GetInt("PlayerHealth");
        PlayerHealth.instance.healthBar.SetHealth(PlayerPrefs.GetInt("PlayerHealth"));
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("CoinsCount");
        Inventory.instance.coinsCountText.text = PlayerPrefs.GetInt("CoinsCount").ToString();
        TimerDisplay.instance.elapsedTime = (PlayerPrefs.GetInt("TimerMinutes") * 60) + PlayerPrefs.GetInt("TimerSeconds");
    }

    public void LoadPlayerPosition()
    {
        float playerPosX = PlayerPrefs.GetFloat("PlayerPositionX");
        float playerPosY = PlayerPrefs.GetFloat("PlayerPositionY");
        PlayerMovement.instance.transform.position = new Vector3(playerPosX, playerPosY, 0);
    }

}
