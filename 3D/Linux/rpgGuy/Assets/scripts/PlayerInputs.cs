using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Inventory.Instance.moveCurrentIndex();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Inventory.Instance.moveCurrentIndexBack();
        }

        if(Input.GetMouseButtonDown(0))
        {
            CharacterMotor.Instance.animator.SetTrigger("Attack");
        }
    }
}
