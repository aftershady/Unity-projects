
using UnityEngine;

public class BossWeakSpot : MonoBehaviour
{
    public AudioClip BossHitSound;
    public GameObject objectToDestroy;
    public int bossIsHit = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Boss Weak Spot Hit");
            bossIsHit++;
            if(bossIsHit >= 3)
            {
                Destroy(objectToDestroy);
            }
        }
    }
}
