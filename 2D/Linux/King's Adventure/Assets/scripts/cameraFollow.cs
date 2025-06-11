
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player; //reference to player
    public float timeOffset; //time before camera movement

    public Vector3 posOffset; //position of camera based on player

    private Vector3 velocity; // keep track of the current rate of change (or "velocity")
    //of the camera's position as it moves towards the target position
    void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        //smoothDampMovement(position of camera -> position of player + additionnal position, vector3 as movement, time delay
    }
}
