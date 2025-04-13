using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatern : MonoBehaviour
{
    /*******************************************************************************/
    //MOVEMENT
    /*******************************************************************************/
    //speed of enemy
    public float speed;
    // array of the class transform to set waypoints
    public Transform[] wayPoints;
    // point targeted by the enemy movement
    private Transform target;
    // index of the waypoints array
    private int destPoint = 0;

    public Rigidbody2D rb;
    /*******************************************************************************/
    //GIVE DAMAGE
    /*******************************************************************************/
    public int damageOnCollision = 20;
    /*******************************************************************************/
    //ANIMATION
    /*******************************************************************************/
    public SpriteRenderer graphics;
    // store SpriteRenderer in a variable for flip
    private bool isJumping = false;
    private bool jumpingAnimation = false;
    public Animator animator;

    public bool istouched = false;

    public static BossPatern instance;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance BossPatern");
        }
        instance = this;
    }

    void Start()
    {
        //target start in the dirrection of the first waypoint
        target = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(istouched)
        {
            return;
        }

        animator.SetBool("jumpingAnimation", jumpingAnimation);
        Vector3 dir = target.position - transform.position;
        //position of enemy = move with position of enemy has init, target.position has target, speed * fps for the delay
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


        // if the distance between the enemy and the actual targeted waypoint is < of 0.3 (to avoid error)
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            // the index of target is calculated with modulo
            // if the despoint is the index 0 of waypoints destpoint = 0 + 1 / number of index (ex 2)
            // 0 + 1 / 2 = 1 go to the waypoint 1
            // 1 + 1 / 2 = 0 got to the waypoint 0
            destPoint = (destPoint + 1) % wayPoints.Length;
            target = wayPoints[destPoint];

            if (!isJumping)
            {
                isJumping = true;
                jumpingAnimation = true;
                StartCoroutine(Jump());
            }
            if (destPoint == 0)
            {
                graphics.flipX = false;
            }
            else if (destPoint == 1)
            {
                graphics.flipX = true;
            }
        }

        if (PlayerHealth.instance.isInvincible)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), true);
        }
        else
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), false);
        }
    }

    private IEnumerator Jump()
    {
        // Set the Rigidbody2D's velocity to a jump force
        rb.velocity = new Vector2(rb.velocity.x, 10f);
        // Wait for 0.5 seconds before continuing
        yield return new WaitForSeconds(0.6f);
        // Reset the Rigidbody2D's velocity to zero
        rb.velocity = Vector2.zero;
        jumpingAnimation = false;
        yield return new WaitForSeconds(Random.Range(0.5f, 5f));
        isJumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the enemy touch the player
        if (collision.gameObject.CompareTag("Player"))
        {
            if(istouched)
            {
                return;
            }
            PlayerHealth.instance.TakeDamage(damageOnCollision);
        }
    }

    public void Istouched()
    {
        istouched = true;
        animator.SetTrigger("BossTouched");
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
        //CREATE TOUCH ANIMATION bossGraphics.animator.SetTrigger("Touched");
    }

    public void ResetBoss()
    {
        animator.SetTrigger("ResetBoss");
        graphics.enabled = true;
        rb.isKinematic = false;
        gameObject.GetComponent<Collider2D>().enabled = true;
        istouched = false;
    }

    public void Die()
    {
        istouched = true;
        //CREATE DEATH ANIMATION bossGraphics.animator.SetTrigger("Die");
        OnBossDeath.instance.openDoor();
        Destroy(gameObject);
    }

}


