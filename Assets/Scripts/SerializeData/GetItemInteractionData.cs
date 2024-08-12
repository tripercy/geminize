using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemInteractionData : InteractionData
{
    public string id;

    public string item_name;
    public PlayerInventory inventory;
    public bool takeItem = true;

    public List<string> haveItemDialog;
    public List<string> noItemDialog;

    private bool haveItem = false;

    public override void InitSerialize(Interaction interaction)
    {
        GetItemInteraction temp = (GetItemInteraction) interaction;
        id = temp.id;
        item_name = temp.item_name;
        inventory = temp.inventory;
        takeItem = temp.takeItem;
        haveItemDialog = temp.haveItemDialog;
        noItemDialog = temp.noItemDialog;
    }
}
