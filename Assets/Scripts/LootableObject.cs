using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootableObject : MonoBehaviour
{
    // Start is called before the first frame update
    //Access UI (tag)
    //Refference to dialog
    //Reference to text
    //String what the text
    private Animator chestAnimator;
    public GameObject hintSignal;
    public GameObject DialogBox;
    public Text dialogText;
    public String dialog;
    public bool isInRange;

    private void Start() {
        hintSignal.SetActive(false);
    }

    private void Awake() {
        chestAnimator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isInRange) {
            chestAnimator.SetBool("isOpened", true);
            hintSignal.SetActive(false);
            if (DialogBox.activeInHierarchy) {
                DialogBox.SetActive(false);
            } else {
                DialogBox.SetActive(true);
                dialogText.text = "DialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialogDialog";
            }
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0  && chestAnimator.GetBool("isOpened") == false) {
            isInRange = true;
            hintSignal.SetActive(true);
        }
    } 

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0) {
            isInRange = false;
            DialogBox.SetActive(false);
            hintSignal.SetActive(false);
        }
    }   
}
