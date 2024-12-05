using UnityEngine;

// This script handles player movement using Unity's Rigidbody2D for physics-based control.
public class PlayerMovement : MonoBehaviour
{
    /*----------------------MOVING-----------------------------------------*/
    // Speed at which the player moves, adjustable in the Unity Inspector.
    public float moveSpeed;
    // Reference to the Rigidbody2D component that manages the player's physics.
    public Rigidbody2D rigidBody;
        // A private variable used to store velocity for smooth transitions (SmoothDamp).
    private Vector3 velocity = Vector3.zero;

    /*----------------------JUMPING-----------------------------------------------*/
    public bool isGrounded;
    public bool isJumping = false;
    public float jumpForce;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    /*----------------------ANIMATION-----------------------------------------------*/
    public Animator animator;




    // FixedUpdate is called at a consistent time interval and is used for physics calculations.
    void FixedUpdate()
    {
        //creat a zone between the two elements who calculate the ground, if it touch something, physics will return true to is grounded
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        // Retrieve horizontal input (-1 for left, 1 for right, and values in between for smooth input).
        // Not the same movement as Input.Getkey condition
        // Multiply by moveSpeed and Time.deltaTime for frame rate-independent movement.
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButton("Jump"))
        {
            isJumping = true;
        }

        // Call the method to apply the calculated horizontal movement.
        MovePlayer(horizontalMovement);

        /* transform x value in absolute value (* -1) */
        float characterVelocity = Mathf.Abs(rigidBody.velocity.x);
        /* send to animator the speed of the character, setFloat send a float value to a variable
        the move animation is active only when characterVelocity is greater than 0.3 because rigidBody
        can make numeric noise to 0.1 or 0.2*/
        animator.SetFloat("speed", characterVelocity);
    }

    // Method to handle player movement based on horizontal input.
    void MovePlayer(float _horizontalMovement)
    {
        // Create a target velocity combining horizontal movement and the current vertical velocity.
        //assign vector 2 to vector 3 to ingore Z Axis and can apply SmoothDamp vector3 static method
        //for Y axis, we use the rigid body gravity of the y axis.
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rigidBody.velocity.y);

        // Smoothly adjust the player's velocity toward the target velocity over time.
        // The ref keyword allows SmoothDamp to modify the velocity variable.
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, 0.05f);

        if(isJumping == true && isGrounded == true)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}
