using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // Reference to the player's transform to follow their position
    public Transform player;

    // Distance of the camera from the player
    public float distanceFromPlayer = 10f;

    // Mouse sensitivity to adjust the rotation speed
    public float mouseSensitivity = 100f;

    // Variables to track the current rotation
    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;

    void Start()
    {
        // Locks the cursor at the center of the screen and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Get the mouse movement values
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust the horizontal rotation (around the Y-axis) based on mouse movement
        horizontalRotation += mouseX;

        // Adjust the vertical rotation (up/down) and limit the angle to avoid flipping
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -0f, 60f); // Limit the view up and down

        // Apply the calculated rotation to the camera
        transform.position = player.position - transform.forward * distanceFromPlayer;
        transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);

        // Position the camera behind the player based on the rotation
        transform.position = player.position - transform.forward * distanceFromPlayer;
    }
}
