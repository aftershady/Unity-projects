using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strongSpot : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Player"))
        {
            Player.transform.position = new Vector3(-11.162f, 1.5f, 0f);
        }
    }

}
