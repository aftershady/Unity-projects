using UnityEngine;

public class enemyPatrol : MonoBehaviour
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
    /*******************************************************************************/
    //GIVE DAMAGE
    /*******************************************************************************/
    public int damageOnCollision = 20;
    /*******************************************************************************/
    //ANIMATION
    /*******************************************************************************/
    public SpriteRenderer graphics;
    // store SpriteRenderer in a variable for flip

    void Start()
    {
        //target start in the dirrection of the first waypoint
        target = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
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
            //flip the 2d model
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            // PlayerHealth playerHealth = create a new variable of type Playerhealth
            // = variable colision.//directional coordinates//.//get an atached script of type playerhealth//
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            // give damage to player
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
