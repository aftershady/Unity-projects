using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CharacterMotor : MonoBehaviour
{

    //speed
    [SerializeField] float walkSpeeed;
    [SerializeField] float runSpeed;
    [SerializeField] float turnSpeed;

    //inputs
    [SerializeField] string inputFront;
    [SerializeField] string inputBack;
    [SerializeField] string inputLeft;
    [SerializeField] string inputRight;
    [SerializeField] string inputRun;

    [SerializeField] string inputJump;

    [SerializeField] Vector3 jumpspeed;
    CapsuleCollider playerCollider;

    [SerializeField] bool isGroundedBool;
    [SerializeField] bool isAttacking  = false;

    public Animator animator;
    public static CharacterMotor Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Duplicate CharacterMotor instance found. Destroying the new one.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

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

    public void attack()
    {
        if (isAttacking) return;
        isAttacking = true;
        StartCoroutine(resetAttack());
        CharacterMotor.Instance.animator.SetTrigger("Attack");

    }

    IEnumerator resetAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
