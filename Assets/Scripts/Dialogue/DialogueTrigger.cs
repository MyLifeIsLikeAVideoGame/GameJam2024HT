using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

    private void OnTriggerStay2D(Collider2D other)
    {
		if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
		{
			Debug.Log("interacted");
			TriggerDialogue();
		}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
		if (other.CompareTag("Player"))
		{
		FindObjectOfType<DialogueManager>().EndDialogue();

        }
    }

}
