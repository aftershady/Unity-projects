using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Vector3 jumpspeed;
    CapsuleCollider playerCollider;

    public Animator animator;


    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (Input.GetKey(inputFront) && !Input.GetKey(inputRun))
        {
            transform.Translate(0, 0, walkSpeeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(inputRun) && Input.GetKey(inputFront))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
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
