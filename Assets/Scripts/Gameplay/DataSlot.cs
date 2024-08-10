using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DataSlot : MonoBehaviour
{
    [Header("UI to change")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI iteminfo;

    [Header("Item variables")]
    public InventoryItem thisItem;
    public DataInventoryManager thisManager;

    public void SetUp(InventoryItem item, DataInventoryManager manager)
    {
        thisItem = item;
        thisManager = manager;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemSprite;
            iteminfo.text = thisItem.itemDescription;
        }
    }

    public void OnClickBtn()
    {
        if (thisItem)
        {
            thisManager.SetCurrentItem(thisItem);
        }
    }
}
