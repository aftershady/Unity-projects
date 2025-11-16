
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject ObjectToDestroy;
    public AudioClip enemyHitSound;
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Player"))
        {
            Destroy(ObjectToDestroy);
            AudioManager.instance.PlayClipAt(enemyHitSound, transform.position);
        }
    }
}
