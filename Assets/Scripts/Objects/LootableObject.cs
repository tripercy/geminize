using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LootableObject : Interactable
{
    // Start is called before the first frame update
    //Access UI (tag)
    //Refference to dialog
    //Reference to text
    //String what the text
    public Item recieveditem;
    public Inventory playerInventory;
    public Signal raiseItem;
    public bool isOpened;
    private Animator chestAnimator;
    public Text dialogText;
    private void Awake()
    {
        chestAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // print(isOpened);
        if (Input.GetKeyDown(KeyCode.Space) && isInRange)
        {
            if (!isOpened)
            {
                OpenChest();
            }
            else
            {
                ChestOpened();
            }
        }
    }

    public void OpenChest()
    {
        chestAnimator.SetBool("isOpened", true);
        playerInventory.currentItem = recieveditem;
        playerInventory.currentItem.itemSprite = recieveditem.itemSprite;
        playerInventory.AddItem(recieveditem);
        DialogBox.SetActive(true);
        ClueOff.SetActive(false);
        dialogText.text = recieveditem.itemDescription;
        raiseItem.Raise();
        isOpened = true;
    }

    public void ChestOpened()
    {
        DialogBox.SetActive(false);
        playerInventory.currentItem = null;
        ClueOff.SetActive(false);
        raiseItem.Raise();
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0 && !isOpened)
        {
            isInRange = true;
            clueOn.Raise();
        }
    }
}
