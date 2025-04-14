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
        if(collision.gameObject.CompareTag("Player") && !PlayerHealth.instance.isInvincible)
        {
            if(countOfHit >= 4)
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
        Color bossColor = BossPatern.instance.GetComponent<SpriteRenderer>().color;
        bossColor.a = 0.4f; // Set alpha to 40%
        bossColor.g *= 0.85f; // Decrease green by 15%
        BossPatern.instance.GetComponent<SpriteRenderer>().color = bossColor;
        BossPatern.instance.ResetBoss();
        yield return new WaitForSeconds(6f);
        bossColor.a = 1f;
        BossPatern.instance.GetComponent<SpriteRenderer>().color = bossColor;
        weakSpotCollider1.enabled = true;
        weakSpotCollider2.enabled = true;
    }
}
