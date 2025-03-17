using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public GameObject pauseMenu;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == false)
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            PlayerMovement.instance.rigidBody.bodyType = RigidbodyType2D.Kinematic;
            PlayerMovement.instance.playerCollider.enabled = false;
            PlayerMovement.instance.rigidBody.velocity = Vector2.zero;
            pauseMenu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf)
        {
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            PlayerMovement.instance.rigidBody.bodyType = RigidbodyType2D.Dynamic;
            PlayerMovement.instance.playerCollider.enabled = true;
            PlayerMovement.instance.animator.speed = 1;
            pauseMenu.SetActive(false);
        }
    }
}
