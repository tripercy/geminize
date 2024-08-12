using UnityEngine;
using UnityEditor;

[System.Serializable]
public class AddItemInteraction : Interaction
{
    public string id;
    public PlayerInventory inventory;

    public DialogManager dialogManager;

    private DataPiece originalData = new DataPiece();

    void LoadData()
    {
        DataPiecesLoader dpl = DataPiecesLoader.Instance;
        var container = dpl.container;
        
        foreach (var dataPiece in container.data_pieces) {
            if (dataPiece.id == id) {
                originalData = dataPiece;
                break;
            }
        }
    }

    public override GameObject trigger()
    {
        LoadData();
        Adapter<DataPiece, InventoryItem> adt = new DataToInvenItem();
        InventoryItem item = adt.from(originalData);

        inventory.currentItem = item;
        inventory.items.Add(item);

        var s = originalData.name + ": " + originalData.content;
        dialogManager.open(s);

        return dialogManager.gameObject;
    }

    public DataPiece GetDataPiece() {
        return this.originalData;
    }

    public override Interaction InitDeserialize(InteractionData item) {
        AddItemInteraction newInstance = new AddItemInteraction();
        AddItemInteractionData temp = (AddItemInteractionData) item;
        newInstance.id = temp.id;
        newInstance.inventory = inventory;
        newInstance.dialogManager = dialogManager;
        Debug.Log(this.dialogManager);
        DataPiece newDatapiece = new()
        {
            id = temp.dataId,
            name = temp.dataName,
            content = temp.content
        };
        newInstance.originalData = newDatapiece;
        return newInstance;
    }
}
