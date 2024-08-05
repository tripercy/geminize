using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class QueryBoardManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory dataInventory;
    [SerializeField] public GameObject emptyDataSlot;
    [SerializeField] private GameObject queryBoardPanel;
    public InventoryItem currentItem;

    public void OnEnable()
    {
        ClearDataInventory();
    }

    void ClearDataInventory()
    {
        for (int i = 0; i < queryBoardPanel.transform.childCount; i++)
        {
            Destroy(queryBoardPanel.transform.GetChild(i).gameObject);
        }
    }

    public void SetCurrentItem(InventoryItem item)
    {
        currentItem = item;
    }
}
