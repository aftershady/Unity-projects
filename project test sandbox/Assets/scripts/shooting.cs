using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Shooting class detects a left mouse click, casts a ray from the camera,
// and destroys an enemy GameObject if it is hit.
public class Shooting : MonoBehaviour
{
    private void Update()
    {
        // Detects a left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Creates a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Draws the ray in the Scene view for visualization, extending 50 units in red
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);

            // Checks if the ray hits any object within a 50-unit range
            if (Physics.Raycast(ray, out hit, 50f))
            {
                // If the object hit has the tag "enemy," it will be destroyed
                if (hit.transform.gameObject.tag == "enemis")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
