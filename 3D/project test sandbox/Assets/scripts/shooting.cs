using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //create reticule variable ans copy to main camera
    public RectTransform reticule;
    private Camera mainCamera;

    void Start()
    {
        //copy main camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        // check if mouse button 0 is pressed
        if (Input.GetMouseButtonDown(0))
        {
            /*point a raycast to the center of the reticule position
            Ray ray : create a Raycast
            mainCamera.ScreenPointToRay(reticule.position) : define the reticule position as raycast point*/
            Ray ray = mainCamera.ScreenPointToRay(reticule.position);
            //create a hit variable to store raycast output
            RaycastHit hit;

            // if Physics.raycast with a ray starting to the center of the reticule touche an object (store
            // out in hit, and if this object is in 50 units of distance)
            if (Physics.Raycast(ray, out hit, 50f))
            {
                // if object have the enemis tag
                if (hit.transform.gameObject.tag == "enemis")
                {
                    //destroy object
                    Destroy(hit.transform.gameObject);
                }
            }

            // for see the raycast in the scene view
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red, 1f);
        }
    }
}
