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
    private float horizontalMovement;
    /*----------------------JUMPING-----------------------------------------------*/
    public bool isGrounded;
    public bool isJumping = false;
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;

    public bool isClimbing;
    private float verticalMovement;
    public float climbSpeed;
    /*----------------------ANIMATION-----------------------------------------------*/
    public Animator animator;

    /*----------------------FLIP-----------------------------------------------*/
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        //create a circle zone who will check if the character is at the ground
        //(position of the circle, size of the circle, layer of collision to make exception for the player collider
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);
        // Retrieve horizontal input (-1 for left, 1 for right, and values in between for smooth input).
        // Not the same movement as Input.Getkey condition
        // Multiply by moveSpeed and Time.deltaTime for frame rate-independent movement.
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
        }

        Flip(Input.GetAxisRaw("Horizontal"));

        /* transform x value in absolute value (* -1) */
        float characterVelocity = Mathf.Abs(rigidBody.velocity.x);
        /* send to animator the speed of the character, setFloat send a float value to a variable
        the move animation is active only when characterVelocity is greater than 0.3 because rigidBody
        can make numeric noise to 0.1 or 0.2*/
        animator.SetFloat("speed", characterVelocity);
    }

    // FixedUpdate is called at a consistent time interval and is used for physics calculations.
    void FixedUpdate()
    {
        // Call the method to apply the calculated horizontal movement.
        MovePlayer(horizontalMovement, verticalMovement);
    }

    // Method to handle player movement based on horizontal input.
    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if(!isClimbing)
        {
            // Create a target velocity combining horizontal movement and the current vertical velocity.
            //assign vector 2 to vector 3 to ingore Z Axis and can apply SmoothDamp vector3 static method
            //for Y axis, we use the rigid body gravity of the y axis.
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rigidBody.velocity.y);

            // Smoothly adjust the player's velocity toward the target velocity over time.
            // The ref keyword allows SmoothDamp to modify the velocity variable.
            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, 0.05f);

            //create a circle zone who will check if the character is at the ground
            //(position of the circle, size of the circle, layer of collision to make exception for the player collider
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);

            if(isJumping)
            {
                rigidBody.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else
        {
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            // Smoothly adjust the player's velocity toward the target velocity over time.
            // The ref keyword allows SmoothDamp to modify the velocity variable.
            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, 0.05f);
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }

    }

    private void OnDrawGizmos()
    {
        //add a gizmos to see the overlapcircle on the scene
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
