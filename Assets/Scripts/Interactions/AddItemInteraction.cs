using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class AddItemInteraction : Interaction
{
    public string id;
    public PlayerInventory inventory;

    public DialogManager dialogManager;

    private DataPiece originalData;

    public AddItemInteraction()
    {
        // TODO: Load data piece
        originalData = new DataPiece()
        {
            id = id,
            name = "hi",
            content = "Hello world"
        };
    }

    public override GameObject trigger()
    {
        Adapter<DataPiece, InventoryItem> adt = new DataToInvenItem();
        InventoryItem item = adt.from(originalData);

        inventory.currentItem = item;
        inventory.items.Add(item);

        var s = originalData.name + ": " + originalData.content;
        dialogManager.open(s);

        return dialogManager.gameObject;
    }
}
