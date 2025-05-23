using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public AudioClip pickItemSound;

    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeItem();
        }
    }

    void TakeItem()
    {
        pickItemSound = item.pickItemSound;
        AudioManager.instance.PlayClipAt(pickItemSound, transform.position);
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        Destroy(gameObject);
    }

}
