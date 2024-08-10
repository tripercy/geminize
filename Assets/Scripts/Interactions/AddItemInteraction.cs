using UnityEngine;
using UnityEditor;

[System.Serializable]
public class AddItemInteraction : Interaction
{
    public string id;
    public PlayerInventory inventory;

    public DialogManager dialogManager;

    private DataPiece originalData;

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
}
