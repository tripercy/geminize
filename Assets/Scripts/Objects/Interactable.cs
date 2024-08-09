using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public Signal clueOn;
    public GameObject ClueOff;
    public DialogManager dialogManager;

    public InteractionContainer interactionContainer;
    private GameObject interactingObject;
    private Interaction interacted;

    void Update()
    {
        if (interactingObject != null && interactingObject.activeInHierarchy)
        {
            return;
        }

        int cnt = interactionContainer.interactions.Count;

        if (interacted != null)
        {
            if (interacted.checkOutput())
            {
                interactionContainer.interactions.RemoveAt(cnt - 1);
                cnt -= 1;
            }
            interacted = null;
        }

        if (interactionContainer.interactions.Count == 0 && interactionContainer.defaultInteraction == null)
        {
            dialogManager.close();
            ClueOff.SetActive(false);
            this.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isInRange && PauseManager.isReceivable)
        {
            Interaction interaction;
            if (cnt > 0)
            {
                interaction = interactionContainer.interactions[cnt - 1];
                interacted = interaction;
            }
            else
            {
                interaction = interactionContainer.defaultInteraction;
            }

            interactingObject = interaction.trigger();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            isInRange = true;
            clueOn.Raise();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (this.gameObject.activeInHierarchy && other.tag.CompareTo("Player") == 0)
        {
            isInRange = false;
            dialogManager.close();
            ClueOff.SetActive(false);
        }
    }
}
