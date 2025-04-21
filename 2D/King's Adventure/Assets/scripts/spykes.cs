using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spykes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(100);
        }
    }
}
