using System;
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
    public PlayerInventory queryBoardInventory;
    [SerializeField] public GameObject emptyDataSlot;
    [SerializeField] private GameObject queryBoardPanel;
    [SerializeField] private GameObject dataPanelParent;
    public GameObject queryBoardAddBtn;
    public InventoryItem currentItem;
    public string res = "";
    public void OnEnable()
    {
        ClearDataInventory();
        NewQueryInventory();
    }

    void ClearDataInventory()
    {
        if (queryBoardInventory.items.Count == 0)
        {
            return;
        }
        for (int i = 0; i < queryBoardInventory.items.Count; i++)
        {
            queryBoardInventory.items.RemoveAt(i);
        }
    }

    void NewQueryInventory()
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

    public void ProcessData()
    {
        res = "";
        List<InventoryItem> tempItemInventory = new List<InventoryItem>();
        List<QueryInputSlot> tempQueryInventory = new List<QueryInputSlot>();

        for (int i = 0; i < queryBoardPanel.transform.childCount; i++)
        {
            GameObject temp = queryBoardPanel.transform.GetChild(i).gameObject;
            QueryInputSlot queryInput = temp.GetComponent<QueryInputSlot>();
            tempQueryInventory.Add(queryInput);
        }

        tempQueryInventory.Sort(delegate (QueryInputSlot q1, QueryInputSlot q2)
        {
            var v1 = Camera.main.WorldToScreenPoint(q1.gameObject.GetComponent<RectTransform>().anchoredPosition);
            var v2 = Camera.main.WorldToScreenPoint(q2.gameObject.GetComponent<RectTransform>().anchoredPosition);
            if (v1.y != v2.y)
            {
                return v2.y.CompareTo(v1.y);
            }
            return v1.x.CompareTo(v2.x);
        });

        for (int i = 0; i < queryBoardPanel.transform.childCount; i++)
        {
            res += tempQueryInventory[i].GetComponent<QueryInputSlot>().thisItem.itemDescription + " ";
        }
    }

    public void OnClickChangeDI()
    {
        if (dataPanelParent.activeInHierarchy)
        {
            queryBoardAddBtn.SetActive(true);
            dataPanelParent.SetActive(false);
        }
        else
        {
            dataPanelParent.SetActive(true);
            queryBoardAddBtn.SetActive(false);
        }
    }
}
