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

    public Animator animator;


    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (Input.GetKey(inputFront) && !Input.GetKey(inputRun) && !Input.GetKey(inputJump))
        {
            transform.Translate(0, 0, walkSpeeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
        }
        else if (Input.GetKey(inputFront) && Input.GetKey(inputRun))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
            animator.SetBool("isJumping", false);
        }
        else if (Input.GetKey(inputFront) && Input.GetKey(inputJump))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);

        }

        if (Input.GetKeyDown(inputBack) && !Input.GetKey(inputJump))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isBack", true);
        }

        if (Input.GetKeyDown(inputJump))
        {
            GetComponent<Rigidbody>().AddForce(jumpspeed, ForceMode.Impulse);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isBack", false);
        }

        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeeed / 2) * Time.deltaTime);
        }

        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
    }
}
