using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class DataInventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory dataInventory;
    public PlayerInventory queryBoardInventory;
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
        if (currentItem)
        {
            GameObject temp = Instantiate(emptyQuerySlot, queryBoardPanel.transform.position, Quaternion.identity);
            temp.AddComponent<UIDraggable2D>();
            QueryInputSlot newSlot = temp.GetComponent<QueryInputSlot>();

            newSlot.transform.SetParent(queryBoardPanel.transform);
            temp.GetComponent<UIDraggable2D>().parent = newSlot.transform.parent.gameObject;
            if (newSlot)
            {
                newSlot.SetUp(currentItem);
                // Make the slot draggable
                newSlot.AddComponent<BoxCollider2D>(); // Ensure BoxCollider2D is attached
                queryBoardInventory.items.Add(currentItem);
            }
        }
    }
}
