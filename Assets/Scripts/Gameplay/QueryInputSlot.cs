using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QueryInputSlot : MonoBehaviour
{
    [Header("UI to change")]
    [SerializeField] private TextMeshProUGUI dataText;

    [Header("Item variables")]
    public InventoryItem thisItem;
    public DataInventoryManager dataInventoryManager;
    public QueryBoardManager queryBoardManager;

    public void SetUp(InventoryItem item)
    {
        thisItem = item;
        if (thisItem)
        {
            dataText.text = thisItem.itemDescription;
        }
    }

    public void OnClickBtn()
    {
        dataInventoryManager.SetCurrentItem(thisItem);
        queryBoardManager.SetCurrentItem(thisItem);
    }
}
