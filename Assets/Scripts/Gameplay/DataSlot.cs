using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSlot : MonoBehaviour
{
    [Header("UI to change")]
    [SerializeField] private Image itemImage;

    [Header("Item variables")]
    public InventoryItem thisItem;
    public DataInventoryManager thisManager;

    public void SetUp(InventoryItem item, DataInventoryManager manager) {
        thisItem = item;
        thisManager = manager;
        if (thisItem) {
            itemImage.sprite = thisItem.itemSprite;
        }
    }

    public void OnClickBtn() {
        if (thisItem) {
            thisManager.SetCurrentItem(thisItem);
        }
    }
}
