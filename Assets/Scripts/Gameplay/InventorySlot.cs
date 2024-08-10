using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("UI to change")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI iteminfo;

    [Header("Item variables")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void SetUp(InventoryItem item, InventoryManager manager) {
        thisItem = item;
        thisManager = manager;
        if (thisItem) {
            itemImage.sprite = thisItem.itemSprite;
            iteminfo.text = thisItem.itemDescription;
        }
    }

    public void OnClickBtn() {
        if (thisItem) {
            thisManager.SetUpDescription(thisItem);
        }
    }
}
