using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public GameObject ShopPanel;
    public bool pannelIsOpen = false;
    public Text PNJnameText;

    public GameObject sellButtonPrefab;
    public Transform itemsToSellParent;

    public Queue<string> sentences;
    public static ShopManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance ShopManager");
        }
        instance = this;

    }

    public void OpenShop(Item[] items, string pnjName)
    {
        PNJnameText.text = pnjName;
        ShopPanel.SetActive(true);
        UpdateItemsToSell(items);
        pannelIsOpen = true;
    }

    public void UpdateItemsToSell(Item[] items)
    {
        // Clear existing buttons
        for (int i = 0; i < itemsToSellParent.childCount; i++)
        {
            Destroy(itemsToSellParent.GetChild(i).gameObject);
        }
        for (int i = 0; i < items.Length; i++)
        {
            GameObject button = Instantiate(sellButtonPrefab, itemsToSellParent);
            SellButtonItem buttonSript = button.GetComponent<SellButtonItem>();
            buttonSript.itemName.text = items[i].itemName;
            buttonSript.itemImage.sprite = items[i].image;
            buttonSript.itemPrice.text = items[i].price.ToString();
            buttonSript.item = items[i];
        }
    }

    public void EndDialogue()
    {
        pannelIsOpen = false;
        ShopPanel.SetActive(false);
    }
}
