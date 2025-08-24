using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Duplicate Inventory instance found. Destroying the new one.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public List<Weapon> weapons = new List<Weapon>();

}
