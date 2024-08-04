using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] public GameObject emptyInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI itemDescription;
    // Start is called before the first frame update
    void Start()
    {
        SetText("");
        CreateInventorySlot();
    } 

    public void SetText(string description) {
        itemDescription.text = description;
    }

    void CreateInventorySlot() {
        if (playerInventory) {
            for (int i = 0; i < playerInventory.items.Count ; i++) {
                GameObject temp = Instantiate(emptyInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                newSlot.transform.SetParent(inventoryPanel.transform);
                print(playerInventory.items[i].itemSprite);
                if (newSlot) {
                    newSlot.SetUp(playerInventory.items[i], this);
                }
            }
        }
    }
}
