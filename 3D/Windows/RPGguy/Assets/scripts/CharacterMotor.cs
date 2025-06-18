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

    public Vector3 jumpspeed;
    CapsuleCollider playerCollider;


    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (Input.GetKey(inputFront))
        {
            transform.Translate(0, 0, walkSpeeed * Time.deltaTime);
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
