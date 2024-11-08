using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The OnTrigger class detects when a specified object (named "character") enters, exits, or stays within a trigger zone.
public class OnTrigger : MonoBehaviour
{
    // Called when another collider enters the trigger zone.
    void OnTriggerEnter(Collider col)
    {
        // Checks if the object entering the trigger zone is named "character"
        if (col.name == "character")
        {
            // Prints a message indicating entry into the zone
            print("You have entered the zone");
        }
    }

    // Called when another collider exits the trigger zone.
    void OnTriggerExit(Collider col)
    {
        // Checks if the object exiting the trigger zone is named "character"
        if (col.name == "character")
        {
            // Prints a message indicating exit from the zone
            print("You have exited the zone");
        }
    }

    // Called every frame while another collider remains in the trigger zone.
    void OnTriggerStay(Collider col)
    {
        // Checks if the object staying within the trigger zone is named "character"
        if (col.name == "character")
        {
            // Prints a message indicating the object is currently within the zone
            print("You are in the zone");
        }
    }
}
