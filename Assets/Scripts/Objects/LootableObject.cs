using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootableObject : Interactable
{
        // Start is called before the first frame update
    //Access UI (tag)
    //Refference to dialog
    //Reference to text
    //String what the text
    private Animator chestAnimator;
    public Text dialogText;
    public String dialog;
    private void Awake() {
        chestAnimator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isInRange) {
            chestAnimator.SetBool("isOpened", true);
            if (DialogBox.activeInHierarchy) {
                DialogBox.SetActive(false);
                if (chestAnimator.GetBool("isOpened") == false) {
                    clueOn.Raise();
                }
            } else {
                ClueOff.SetActive(false);
                DialogBox.SetActive(true);
                dialogText.text = "DialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialog";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0  && chestAnimator.GetBool("isOpened") == false) {
            isInRange = true;
            clueOn.Raise();
        }
    } 
}
