using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("UI to change")]
    [SerializeField] private Image itemImage;

    [Header("Item variables")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void SetUp(InventoryItem item, InventoryManager manager) {
        thisItem = item;
        thisManager = manager;
        if (thisItem) {
            itemImage.sprite = thisItem.itemSprite;
        }
    }

    public void OnClickBtn() {
        if (thisItem) {
            thisManager.SetUpDescription(thisItem.itemDescription, thisItem);
        }
    }
}
