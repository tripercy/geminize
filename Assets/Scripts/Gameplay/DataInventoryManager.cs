using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DataInventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory dataInventory;
    [SerializeField] public GameObject emptyDataSlot;
    [SerializeField] public GameObject emptyQuerySlot;
    [SerializeField] private GameObject dataPanel;
    [SerializeField] private GameObject queryBoardPanel;
    public InventoryItem currentItem;

    public void OnEnable()
    {
        ClearDataInventory();
        CreateDataInventorySlot();
    }

    void ClearDataInventory()
    {
        for (int i = 0; i < dataPanel.transform.childCount; i++)
        {
            Destroy(dataPanel.transform.GetChild(i).gameObject);
        }
    }

    void CreateDataInventorySlot()
    {
        for (int i = 0; i < dataInventory.items.Count; i++)
        {
            if (dataInventory.items[i].itemType.typeName.CompareTo("Data") == 0)
            {
                GameObject temp = Instantiate(emptyDataSlot, dataPanel.transform.position, quaternion.identity);
                DataSlot newSlot = temp.GetComponent<DataSlot>();
                newSlot.transform.SetParent(dataPanel.transform);
                if (newSlot)
                {
                    newSlot.SetUp(dataInventory.items[i], this);
                }
            }
        }
    }

    public void SetCurrentItem(InventoryItem item)
    {
        currentItem = item;
    }

    public void OnClickAdd()
    {
        
        GameObject temp = Instantiate(emptyQuerySlot, queryBoardPanel.transform.position, Quaternion.identity);
        QueryInputSlot newSlot = temp.GetComponent<QueryInputSlot>();

        newSlot.transform.SetParent(queryBoardPanel.transform);
        print(temp);
        if (newSlot)
        {
            newSlot.SetUp(currentItem);
            // Make the slot draggable
            newSlot.AddComponent<Draggable2D>();
            newSlot.AddComponent<BoxCollider2D>(); // Ensure BoxCollider2D is attached
        }
    }
}
