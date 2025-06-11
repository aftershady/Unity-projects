using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class Inventory : MonoBehaviour
{
    public Text noItemText;
    public List<Item> content = new List<Item>();
    private int contentCurrentIndex = 0;
    //counter of coins
    public int coinsCount;
    //text who display number of coins
    public Text coinsCountText;
    public Image itemImageUI;
    public Text itemNameUI;

    public PlayerEffect playerEffect;

    //create singleton
    public static Inventory instance;

    private void Awake()
    {
        //if multiple call of singleton, result and error
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance Inventory");
        }
        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void consumeItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        playerEffect.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
            noItemText.gameObject.SetActive(false);
        }
        else
        {
            itemImageUI.sprite = null;
            noItemText.gameObject.SetActive(true);
            itemNameUI.text = "";
        }
    }

    public void AddCoins(int count)
    {
        //add number of coins send to the coinsCount
        coinsCount += count;
        //send the coinsCount to the canva to display is, convert int in string
        coinsCountText.text = coinsCount.ToString();
    }

    public void ResetCoins()
    {
        coinsCount = 0;
        coinsCountText.text = coinsCount.ToString();
    }

}
