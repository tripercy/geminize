
using UnityEngine;

public class DataToInvenItem : Adapter<DataPiece, InventoryItem>
{
    public InventoryItem from(DataPiece obj)
    {
        var item = ScriptableObject.CreateInstance<InventoryItem>();
        item.itemName = obj.name;
        item.itemDescription = obj.content;
        item.isUnique = true;
        item.usable = true;
        item.itemSprite = Resources.LoadAll<Sprite>("Art/objects")[16];

        item.itemType = ScriptableObject.CreateInstance<ItemType>();
        item.itemType.typeName = "Data";
        item.itemType.typeDescription = "";

        return item;
    }

}
