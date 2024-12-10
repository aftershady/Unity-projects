using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] wayPoints;
    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        target = wayPoints[0];
    }

    // Update is called once per frame
void Update()
{

    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    if (Vector3.Distance(transform.position, target.position) < 0.3f)
    {
        destPoint = (destPoint + 1) % wayPoints.Length;
        target = wayPoints[destPoint];
    }
}
}
