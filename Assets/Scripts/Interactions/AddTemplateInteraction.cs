using UnityEngine;
using System;

[System.Serializable]
public class AddTemplateInteraction : Interaction
{
    public string id;
    public string name;
    public string template;
    public PlayerInventory inventory;
    public DialogManager dialogManager;

    public override GameObject trigger()
    {
        var item = ScriptableObject.CreateInstance<InventoryItem>();
        item.itemName = name;
        item.itemDescription = template;
        item.isUnique = true;
        item.usable = true;
        item.itemSprite = Resources.LoadAll<Sprite>("Art/objects")[12];

        item.itemType = ScriptableObject.CreateInstance<ItemType>();
        item.itemType.typeName = "OutputTemplate";
        
        inventory.currentItem = item;
        inventory.items.Add(item);

        var s = "[TEMPLATE ACQUIRED]" + Environment.NewLine + template;
        dialogManager.open(s);

        return dialogManager.gameObject;
    }
}
