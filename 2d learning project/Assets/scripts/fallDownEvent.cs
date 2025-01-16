
using UnityEngine;

public class fallDownEvent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            // Retourner le joueur à la position de départ
            colision.transform.position = new Vector3(-11.162f, 1.5f, 0f);
        }
    }
}
