
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public Sprite image;
    public int hpGiven;
    public int speedGiven;
    public float speedDuration;
    public AudioClip pickItemSound;

}

