using UnityEngine;
using System;

[System.Serializable]
public class AddItemInteraction : Interaction
{
    public InventoryItem item;
    public PlayerInventory inventory;

    public override GameObject trigger(DialogManager dialogManager)
    {
        inventory.currentItem = item;
        inventory.items.Add(item);

        var s = String.Format("[ACQUIRED: {0}]", item.itemType.name)+ Environment.NewLine + item.name + ": " + item.itemDescription;
        dialogManager.open(s);

        return dialogManager.gameObject;
    }
}
