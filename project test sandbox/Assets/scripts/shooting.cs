using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private void Update()
    {
        // detection of left click
        if (Input.GetMouseButtonDown(0))
        {
            // create a ray from camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // dray ray in scene tab
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);

            // check if ray touch something
            if (Physics.Raycast(ray, out hit, 50f))
            {
                if(hit.transform.gameObject.name != "sol")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}

