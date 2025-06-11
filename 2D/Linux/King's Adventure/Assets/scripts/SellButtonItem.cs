using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;

    public Item item;
    public void buyItem()
    {
        Inventory inventory = Inventory.instance;
        if (inventory.coinsCount >= item.price)
        {
            inventory.content.Add(item);
            inventory.UpdateInventoryUI();
            inventory.coinsCount -= item.price;
            inventory.coinsCountText.text = inventory.coinsCount.ToString();
            inventory.UpdateInventoryUI();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not enough coins to buy this item.");
        }
    }

}
