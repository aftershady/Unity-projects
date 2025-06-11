using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Moving class handles the movement of a GameObject based on player input.
public class Moving : MonoBehaviour
{
    // Camera reference to align movement with its direction
    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code here if needed
    }

    // FixedUpdate is called at a consistent rate, ideal for physics-based movement
    void FixedUpdate()
    {
        // Get movement axes based on user input
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction based on camera rotation
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Remove the vertical component so movement is only horizontal
        forward.y = 0;
        right.y = 0;

        // Normalize the vectors to avoid influencing movement speed
        forward.Normalize();
        right.Normalize();

        if (Input.GetMouseButton(1))
        {
            verticalInput = 1; // Sets verticalInput to 1 to move forward
        }

        // Calculate the final movement direction
        Vector3 moveDirection = forward * verticalInput + right * horizontalInput;

        // Apply the movement
        transform.Translate(moveDirection * 5f * Time.fixedDeltaTime, Space.World);
    }
}
