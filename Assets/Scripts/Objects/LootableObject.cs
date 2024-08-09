using UnityEngine;
using UnityEngine.UI;

public class LootableObject : Interactable
{
    public InventoryItem receivedItem;
    public PlayerInventory playerInventory;
    public Signal raiseItem;
    public bool isOpened;
    private Animator chestAnimator;
    public Text dialogText;
    public static bool isOpening = false;
    public GameObject DialogBox;

    private void Awake()
    {
        chestAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInRange && PauseManager.isReceivable)
        {
            if (!isOpened)
            {
                OpenChest();
                isOpening = true;
            }
            else
            {
                ChestOpened();
                isOpening = false;
            }
        }
    }

    public void OpenChest()
    {
        chestAnimator.SetBool("isOpened", true);
        playerInventory.currentItem = receivedItem;
        playerInventory.items.Add(receivedItem);
        DialogBox.SetActive(true);
        ClueOff.SetActive(false);
        dialogText.text = receivedItem.itemDescription;
        raiseItem.Raise();
        isOpened = true;
    }

    public void ChestOpened()
    {
        DialogBox.SetActive(false);
        ClueOff.SetActive(false);
        playerInventory.currentItem = null;
        raiseItem.Raise();
    }

}
