using System.Collections;
using UnityEngine;

public class fallDownEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip fallSound;
    private Transform playerSpawn;
    private Animator fadeSystem;
    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        audioSource.PlayOneShot(fallSound);
        PlayerMovement.instance.enabled = false;
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        // player return to the start position
        collision.transform.position = playerSpawn.position;
        PlayerMovement.instance.rigidBody.velocity = Vector2.zero;
        PlayerMovement.instance.enabled = true;
        if (PlayerHealth.instance.currentHealth - 20 > 0 )
        {
            PlayerHealth.instance.TakeDamage(20);
        }
    }
}
