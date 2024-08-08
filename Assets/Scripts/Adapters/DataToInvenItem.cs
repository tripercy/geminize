
public class DataToInvenItem : Adapter<DataPiece, InventoryItem>
{
    public InventoryItem from(DataPiece obj)
    {
        return new InventoryItem() {
            itemName = obj.name,
            itemDescription = obj.content,
            isUnique = true,
            usable = true,
            itemType = new ItemType() {
                typeName = "Data",
                typeDescription = ""
            }
        };
    }

}
