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

    void Start()
    {
        interactingObject = dialogManager.gameObject;
    }

    void Update()
    {
        if (interactingObject.activeInHierarchy) {
            return;
        }

        if (interactionContainer.interactions.Count == 0 && interactionContainer.defaultInteraction == null)
        {
            this.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isInRange && PauseManager.isReceivable)
        {
            Interaction interaction;
            int cnt = interactionContainer.interactions.Count;
            if (cnt > 0)
            {
                interaction = interactionContainer.interactions[cnt - 1];
                interactionContainer.interactions.RemoveAt(cnt - 1);
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
