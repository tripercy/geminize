using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Player Inventory")]
[System.Serializable]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> items = new List<InventoryItem>();
    public InventoryItem currentItem;

    void OnValidate()
    {
        items.RemoveAll(item => item == null);
    }
}
