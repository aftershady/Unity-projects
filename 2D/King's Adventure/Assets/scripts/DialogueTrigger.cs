using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isInRange = false;

    private GameObject talkToPnjUI;

    void Awake()
    {
        talkToPnjUI = GameObject.FindGameObjectWithTag("TalkPnjUI");
    }
    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.T) && DialogueManager.instance.pannelIsOpen == false)
        {
            TriggerDialogue();
        }

        if (DialogueManager.instance.pannelIsOpen == true)
        {
            talkToPnjUI.transform.GetChild(0).gameObject.SetActive(false);
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (talkToPnjUI != null)
            {
                talkToPnjUI.transform.GetChild(0).gameObject.SetActive(true);
            }
            isInRange = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            DialogueManager.instance.EndDialogue();
            talkToPnjUI.transform.GetChild(0).gameObject.SetActive(false);
            isInRange = false;
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
