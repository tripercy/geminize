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
        print(thisItem.itemSprite);
        if (thisItem) {
            itemImage.sprite = thisItem.itemSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
