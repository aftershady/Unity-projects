using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Test class toggles the visibility of a specified GameObject (maSphere)
// based on whether the "R" key is pressed.
public class Test : MonoBehaviour
{
    // Reference to a GameObject (maSphere) to be shown or hidden
    public GameObject maSphere;

    void Update()
    {
        // Checks if the "R" key is being pressed
        if (Input.GetKey(KeyCode.R))
        {
            // Activates maSphere, making it visible in the scene
            maSphere.SetActive(true);
        }
        else
        {
            // Deactivates maSphere, making it invisible in the scene
            maSphere.SetActive(false);
        }
    }
}
