using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    public bool isInRange = false;
    private GameObject talkToPnjUI;
    public string pnjName;
    public Item[] itemsToSell;

    void Awake()
    {
        talkToPnjUI = GameObject.FindGameObjectWithTag("TalkPnjUI");
    }
    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.T) && ShopManager.instance.pannelIsOpen == false)
        {
            ShopManager.instance.OpenShop(itemsToSell, pnjName);
        }
        if (ShopManager.instance.pannelIsOpen == true)
        {
            talkToPnjUI.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (talkToPnjUI != null)
            {
                talkToPnjUI.transform.GetChild(0).gameObject.SetActive(true);
            }
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShopManager.instance.EndDialogue();
            talkToPnjUI.transform.GetChild(0).gameObject.SetActive(false);
            isInRange = false;
        }
    }

}
