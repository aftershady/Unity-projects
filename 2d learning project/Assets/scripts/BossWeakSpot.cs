using UnityEngine;
using System.Collections;

public class BossWeakSpot : MonoBehaviour
{
    public BoxCollider2D weakSpotCollider1;
    public BoxCollider2D weakSpotCollider2;
    public AudioClip BossHitSound;
    public GameObject objectToDestroy;
    private bool bossIsHit = false;

    public int countOfHit = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(countOfHit >= 3)
            {
                BossPatern.instance.Die();
                return;
            }
            if(!bossIsHit)
            {
                bossIsHit = true;
                StartCoroutine(FlashBoss());
            }
        }
    }

    private IEnumerator FlashBoss()
    {
        weakSpotCollider1.enabled = false;
        weakSpotCollider2.enabled = false;
        BossPatern.instance.Istouched();
        countOfHit++;
        bossIsHit = false;
        yield return new WaitForSeconds(2f); // Add a delay of 1 second (adjust as needed)
        BossPatern.instance.ResetBoss();
        weakSpotCollider1.enabled = true;
        weakSpotCollider2.enabled = true;
    }
}
