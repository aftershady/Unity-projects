using UnityEngine;
using System.Collections;

public class BossWeakSpot : MonoBehaviour
{
    public AudioClip BossHitSound;
    public GameObject objectToDestroy;
    private bool bossIsHit = false;

    public int countOfHit = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Boss Weak Spot Hit");
            if(countOfHit >= 3)
            {
                Destroy(objectToDestroy);
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
        BossPatern.instance.Istouched();
        BossPatern.instance.Blink();
        countOfHit++;
        bossIsHit = false;
        yield return new WaitForSeconds(8f); // Add a delay of 1 second (adjust as needed)
        BossPatern.instance.ResetBoss();
    }
}
