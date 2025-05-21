using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public AudioSource audioSource;
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
        AudioManager.instance.PlayClipAt(pickItemSound, transform.position);
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        Destroy(gameObject);
    }

}
