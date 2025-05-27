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
        UpdateItemsToSell(items);
        ShopPanel.SetActive(true);
        pannelIsOpen = true;
        sentences = new Queue<string>();
    }

    public void UpdateItemsToSell(Item[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Instantiate(sellButtonPrefab, itemsToSellParent);
        }
    }

    public void EndDialogue()
    {
        ShopPanel.SetActive(false);
        pannelIsOpen = false;
    }
}
