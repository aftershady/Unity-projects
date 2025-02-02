using UnityEngine;

public class Lader : MonoBehaviour
{
    public bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topCollider;
    public GameObject ladderText;

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
            isInRange = false;
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            
            foreach (Transform child in ladderText.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
