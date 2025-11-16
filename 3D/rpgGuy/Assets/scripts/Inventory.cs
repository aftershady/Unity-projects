using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool weaponIsInInventory { get; private set; } = false;
    [SerializeField] int weaponCurrentIndex = 0;
    [SerializeField] List<Weapon> weapons = new List<Weapon>();

    [SerializeField] List<GameObject> uiSelectors = new List<GameObject>();

    [SerializeField] List<GameObject> weaponsSkins = new List<GameObject>();
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



    public void AddWeapon(Weapon weapon)
    {
        if (!weapons.Contains(weapon))
        {
            weapons.Add(weapon);
            Debug.Log($"Weapon {weapon.name} added to inventory.");
            RefreshInventory();
            weaponIsInInventory = false;
        }
        else
        {
            Debug.Log($"Weapon {weapon.name} is already in inventory.");
            weaponIsInInventory = true;
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

            foreach (GameObject selector in uiSelectors)
            {
                if (selector != null)
                {
                    selector.SetActive(false);
                }
            }
            foreach (GameObject skin in weaponsSkins)
            {
                if (skin != null)
                {
                    skin.SetActive(false);
                }
            }
            if (weaponCurrentIndex < uiSelectors.Count && uiSelectors[weaponCurrentIndex] != null)
            {
                uiSelectors[weaponCurrentIndex].SetActive(true);
            }

            //active the weapon skin in hand
            if (weaponCurrentIndex >= 0 && weaponCurrentIndex < weapons.Count && weapons[weaponCurrentIndex] != null)
            {
                int skinIndex = weapons[weaponCurrentIndex].id;
                if (skinIndex >= 0 && skinIndex < weaponsSkins.Count && weaponsSkins[skinIndex] != null)
                {
                    weaponsSkins[skinIndex].SetActive(true);
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

    //move index to the right
    public void moveCurrentIndex()
    {
        weaponCurrentIndex++;
        if (weaponCurrentIndex > 5)
        {
            weaponCurrentIndex = 0;
        }
        RefreshInventory();
    }

    //move index to the left
    public void moveCurrentIndexBack()
    {
        weaponCurrentIndex--;
        if (weaponCurrentIndex < 0)
        {
            weaponCurrentIndex = 5;
        }
        RefreshInventory();
    }
}
