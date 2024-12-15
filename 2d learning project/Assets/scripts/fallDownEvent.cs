
using UnityEngine;

public class fallDownEvent : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Player"))
        {
            //return to starting position if falling
            Player.transform.position = new Vector3(-11.162f, 1.5f, 0f);
        }
    }
}
