using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Moving class handles the movement of a GameObject based on player input.
public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initialization code could go here if needed in the future
    }

    // Update is called once per frame
    void Update()
    {
        // Code here would run every frame (e.g., per-frame updates)
    }

    // FixedUpdate is called at a consistent rate, making it ideal for handling physics-based movement
    void FixedUpdate()
    {
        // Moves the GameObject forward or backward based on vertical input (e.g., W/S or Up/Down keys)
        transform.Translate(Vector3.forward * 5f * Time.fixedDeltaTime * Input.GetAxis("Vertical"));

        // Moves the GameObject left or right based on horizontal input (e.g., A/D or Left/Right keys)
        transform.Translate(Vector3.left * -5f * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
    }
}

