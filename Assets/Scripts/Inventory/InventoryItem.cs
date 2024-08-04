using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    public string itemname;
    public string itemDescription;
    public Sprite itemSprite;
    public bool isUnique;
    public bool usable;
}
