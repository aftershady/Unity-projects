
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject ObjectToDestroy;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Player"))
        {
            Destroy(ObjectToDestroy);
        }
    }
}
