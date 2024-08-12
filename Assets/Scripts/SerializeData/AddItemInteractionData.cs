using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AddItemInteractionData : InteractionData
{
    public string id;
    // public PlayerInventory inventory;

    // public DialogManager dialogManager;

    // private DataPiece originalData;
    public PlayerInventory playerInventory;
    public InventoryItem inventoryItem;

    public override void InitSerialize(Interaction item) {
        AddItemInteraction temp = (AddItemInteraction) item;
        playerInventory = temp.inventory;
        inventoryItem = temp.item;
    }
}
