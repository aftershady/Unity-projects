using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip doorSound;
    public string sceneName;
    public Animator fadeSystem;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player tag enter in coin
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().enabled = false;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(loadNextScene(collision));
        }
    }

    public IEnumerator loadNextScene(Collider2D collision)
    {
        audioSource.PlayOneShot(doorSound);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.GetComponent<PlayerMovement>().enabled = true;
        SceneManager.LoadScene(sceneName);
    }
}
