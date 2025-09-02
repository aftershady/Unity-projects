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
    }




}
