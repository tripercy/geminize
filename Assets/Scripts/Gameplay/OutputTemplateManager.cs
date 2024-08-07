using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OutputTemplateManager : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public PlayerInventory templateInventory;
    public string currentData;

    private void OnEnable()
    {
        ClearOptions();
        CreateOptions();
    }

    public void CreateOptions()
    {
        for (int i = 0; i < templateInventory.items.Count; i++)
        {
            if (templateInventory.items[i].itemType.typeName.CompareTo("OutputTemplate") == 0)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData(templateInventory.items[i].itemDescription, null));
            }
        }
    }

    public void ClearOptions()
    {
        if (dropdown.options.Count != 1)
        {
            for (int i = dropdown.options.Count - 1; i > 0; i--)
            {
                dropdown.options.RemoveAt(i);
            }
        }
    }

    public void GetItem()
    {
        currentData = dropdown.options[dropdown.value].text;
        // print(currentData);
    }
}
