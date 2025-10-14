using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CharacterMotor : MonoBehaviour
{

    //speed
    public float walkSpeeed;
    public float runSpeed;
    public float turnSpeed;

    //inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    public string inputRun;

    public string inputJump;

    public Vector3 jumpspeed;
    CapsuleCollider playerCollider;

    public bool isGroundedBool;


    public Animator animator;


    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 0.2f);
    }

    void Update()
    {
        isGroundedBool = isGrounded();

        //check if the player is grounded
        if (Input.GetKeyDown(inputJump) && isGrounded())
        {
            GetComponent<Rigidbody>().AddForce(jumpspeed, ForceMode.Impulse);
            animator.SetTrigger("isJumping");
        }

        //player is walking or running
        if (Input.GetKey(inputFront) && !Input.GetKey(inputRun))
        {
            transform.Translate(0, 0, walkSpeeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
        }
        else if (Input.GetKey(inputFront) && Input.GetKey(inputRun))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        //player is moving back
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeeed / 2) * Time.deltaTime);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isBack", true);
        }
        else
        {
            animator.SetBool("isBack", false);
        }

        //player is turning left
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        //player is turning right
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
    }
}
