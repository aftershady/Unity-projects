using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Weapon")]
public class Weapon : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite icon;
    public int damage;
    public float range;
    public float attackSpeed;
    public GameObject model;

}
