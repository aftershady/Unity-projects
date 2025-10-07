using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Inventory.Instance.weaponCurrentIndex++;
            if(Inventory.Instance.weaponCurrentIndex > 5)
            {
                Inventory.Instance.weaponCurrentIndex = 0;
            }
            Inventory.Instance.RefreshInventory();
        }
    }
}
