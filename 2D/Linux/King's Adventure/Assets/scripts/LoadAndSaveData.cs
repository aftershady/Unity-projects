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

        //save items
        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("ItemsInInventory", itemsInInventory);
    }

    public void SaveDataManually()
    {
        PlayerPrefs.SetInt("ManPlayerHealth", PlayerHealth.instance.currentHealth);
        PlayerPrefs.SetInt("ManCoinsCount", Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("ManLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("ManTimerMinutes", TimerDisplay.instance.minutes);
        PlayerPrefs.SetInt("ManTimerSeconds", TimerDisplay.instance.seconds);

        //save items
        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("ManItemsInInventory", itemsInInventory);
    }

        public void LoadDataManually()
    {
        PlayerHealth.instance.currentHealth = PlayerPrefs.GetInt("ManPlayerHealth");
        PlayerHealth.instance.healthBar.SetHealth(PlayerPrefs.GetInt("ManPlayerHealth"));
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("ManCoinsCount");
        Inventory.instance.coinsCountText.text = PlayerPrefs.GetInt("ManCoinsCount").ToString();
        TimerDisplay.instance.elapsedTime = (PlayerPrefs.GetInt("ManTimerMinutes") * 60) + PlayerPrefs.GetInt("TimerSeconds");

        //load items
        string[] itemsSaved = PlayerPrefs.GetString("ManItemsInInventory", "").Split(',');
        if (itemsSaved[0] == "")
        {
            return;
        }
        Inventory.instance.content.Clear();
        foreach (string itemId in itemsSaved)
        {
            int id = int.Parse(itemId);
            Item currentItem = ItemsDatabase.instance.allItems.Single(x => x.id == id);
            Inventory.instance.content.Add(currentItem);
        }
        Inventory.instance.UpdateInventoryUI();
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

        //load items
        string[] itemsSaved = PlayerPrefs.GetString("ItemsInInventory", "").Split(',');
        if (itemsSaved[0] == "")
        {
            return;
        }
        Inventory.instance.content.Clear();
        foreach (string itemId in itemsSaved)
        {
            int id = int.Parse(itemId);
            Item currentItem = ItemsDatabase.instance.allItems.Single(x => x.id == id);
            Inventory.instance.content.Add(currentItem);
        }
        Inventory.instance.UpdateInventoryUI();
    }

    public void LoadPlayerPosition()
    {
        float playerPosX = PlayerPrefs.GetFloat("PlayerPositionX");
        float playerPosY = PlayerPrefs.GetFloat("PlayerPositionY");
        PlayerMovement.instance.transform.position = new Vector3(playerPosX, playerPosY, 0);
    }

}
