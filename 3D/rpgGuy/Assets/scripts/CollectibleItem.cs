using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public Weapon weapon;


    private void Start()
    {
        if (weapon != null && weapon.model != null)
        {
            GameObject modelInstance = Instantiate(weapon.model, this.transform);
        }

        StartCoroutine(moveItem());
    }

    // oscillate the item up and down
    private IEnumerator moveItem()
    {
        float amplitude = 0.5f; // height of movement
        float frequency = 1f;   // speed of movement
        Vector3 startPos = transform.position;

        while (true)
        {
            float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
            transform.position = startPos + new Vector3(0, yOffset, 0);
            yield return null;
        }
    }

    // add weapon on collision with player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.Instance.AddWeapon(weapon);
            if (!Inventory.Instance.weaponIsInInventory)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
