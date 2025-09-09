using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int weaponCurrentIndex = 0;
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

    private void Start()
    {
        RefreshInventory();
        GetCurrentWeapon();
    }

    public List<Weapon> weapons = new List<Weapon>();

    public void AddWeapon(Weapon weapon)
    {
        if (!weapons.Contains(weapon))
        {
            weapons.Add(weapon);
            Debug.Log($"Weapon {weapon.name} added to inventory.");
            RefreshInventory();
        }
        else
        {
            Debug.Log($"Weapon {weapon.name} is already in inventory.");
        }
    }

    public void RefreshInventory()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var image = transform.GetChild(i).GetComponent<UnityEngine.UI.Image>();
            if (image != null)
            {
                if (i < weapons.Count && weapons[i] != null)
                {
                    image.sprite = weapons[i].icon;
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                }
                else
                {
                    image.sprite = null;
                }
            }
        }

    }

    public void GetCurrentWeapon()
    {
        if (weapons.Count == 0) return;
        else
        {
            var currentWeapon = weapons[weaponCurrentIndex];
        }
    }
}
