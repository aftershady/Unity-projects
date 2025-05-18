using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class Inventory : MonoBehaviour
{
    public List<Item> content = new List<Item>();
    //counter of coins
    public int coinsCount;
    //text who display number of coins
    public Text coinsCountText;
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

    public void consumeItem()
    {
        Item currentItem = content[0];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        PlayerMovement.instance.moveSpeed += currentItem.speedGiven;
        content.Remove(currentItem);
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
