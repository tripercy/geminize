using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Inventory/Items")]
[System.Serializable]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    [SerializeField]public Sprite itemSprite;
     public bool isUnique;
    public bool usable;
    [SerializeField] public ItemType itemType;
}
