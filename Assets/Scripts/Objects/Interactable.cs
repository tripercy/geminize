using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public Signal clueOn;
    public GameObject ClueOff;
    public GameObject DialogBox;

    public InteractionContainer interactionContainer;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isInRange && PauseManager.isReceivable) {
            Interaction interaction;
            int cnt = interactionContainer.interactions.Count;
            if (cnt > 0) {
                interaction = interactionContainer.interactions[cnt - 1];
                interactionContainer.interactions.RemoveAt(cnt - 1);
            } else {
                interaction = interactionContainer.defaultInteraction;
            }

            interaction.trigger();
        }

        if (interactionContainer.interactions.Count == 0 && interactionContainer.defaultInteraction == null) {
            this.transform.parent.gameObject.SetActive(false);
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
        if (other.tag.CompareTo("Player") == 0)
        {
            isInRange = false;
            DialogBox.SetActive(false);
            ClueOff.SetActive(false);
        }
    }
}
