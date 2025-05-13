using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public static DialogueManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance DialogueManager");
        }
        instance = this;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
    }
}
