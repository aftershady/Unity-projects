using UnityEngine;
using System.Collections;
public class Lader : MonoBehaviour
{
    public bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topCollider;
    private GameObject ladderText;

    public AudioSource audioSource;
    public AudioClip ladderSound;

    private bool soundIsPlaying;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        ladderText = GameObject.FindGameObjectWithTag("ladderText");
    }

    void Update()
    {
        if(isInRange && playerMovement.isClimbing && playerMovement.isGrounded && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow)
        || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }

        if(isInRange && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
            foreach (Transform child in ladderText.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        if (playerMovement.isClimbing )
        {
            playerMovement.rigidBody.gravityScale = 0f;
        }

        if (isInRange && playerMovement.isClimbing && !soundIsPlaying)
        {
            soundIsPlaying = true;
            StartCoroutine(ClimbSound(ladderSound));
        }

        if(isInRange && playerMovement.isClimbing  && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            playerMovement.animator.speed = 0f;
        }
        else if(isInRange && playerMovement.isClimbing && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
        {
            playerMovement.animator.speed = 1f;
        }


    }

    public IEnumerator ClimbSound(AudioClip LadderSound)
    {
        while(playerMovement.isClimbing == true)
        {
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                audioSource.PlayOneShot(LadderSound);
            }
            yield return new WaitForSeconds(0.25f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;

            foreach (Transform child in ladderText.transform)
            {
            child.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement.rigidBody.gravityScale = 1f;
            isInRange = false;
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            soundIsPlaying = false;

            foreach (Transform child in ladderText.transform)
            {
                child.gameObject.SetActive(false);
            }
            playerMovement.animator.speed = 1f;
        }
    }
}
