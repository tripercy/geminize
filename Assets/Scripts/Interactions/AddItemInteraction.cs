using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class AddItemInteraction : Interaction
{
    public string id;
    public PlayerInventory inventory;

    public GameObject dialogBox;
    public Text dialogText;

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

    public override void trigger()
    {
        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
        } else {
            Adapter<DataPiece, InventoryItem> adt = new DataToInvenItem();
            InventoryItem item = adt.from(originalData);

            inventory.currentItem = item;
            inventory.items.Add(item);

            dialogText.text = originalData.name + ": " + originalData.content;
            dialogBox.SetActive(true);
        }
    }
}
