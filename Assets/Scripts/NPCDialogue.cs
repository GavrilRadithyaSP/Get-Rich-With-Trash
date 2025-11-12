using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogueLines;
    private int index = 0;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                ShowDialogue();
            }
            else
            {
                NextLine();
            }
        }
    }

    void ShowDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueLines[index];
    }

    void NextLine()
    {
        index++;
        if (index < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[index];
        }
        else
        {
            dialoguePanel.SetActive(false);
            index = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialoguePanel.SetActive(false);
            index = 0;
        }
    }
}
