
using UnityEngine;

public class BossWeakSpot : MonoBehaviour
{
    public GameObject ObjectToDestroy;
    public AudioClip BossHitSound;
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(BossHitSound, transform.position);
        }
    }
}
