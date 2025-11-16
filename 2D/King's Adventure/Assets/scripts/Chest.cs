using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public GameObject openText;
    public AudioSource audioSource;
    public AudioClip openChestSound;


    private void Awake()
    {
        openText = GameObject.FindGameObjectWithTag("ChestText");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (Transform child in openText.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                animator.SetTrigger("OpenChest");
                StartCoroutine(PlayOpenChestSoundRepeatedly());
                openText.SetActive(false);
            }
        }
    }

    private IEnumerator PlayOpenChestSoundRepeatedly()
    {
        for (int i = 0; i < 5; i++)
        {
            Inventory.instance.AddCoins(1);
            audioSource.PlayOneShot(openChestSound);
            yield return new WaitForSeconds(0.1F);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (Transform child in openText.transform)
            {
                child.gameObject.SetActive(false);
            }
    }

}
