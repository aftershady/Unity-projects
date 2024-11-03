using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject maSphere;

    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            maSphere.SetActive(true);
        }
        else
        {
           maSphere.SetActive(false);
        }

    }
}
