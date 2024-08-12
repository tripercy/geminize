using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AddItemInteractionData : InteractionData
{
    public string id;
    // public PlayerInventory inventory;

    // public DialogManager dialogManager;

    // private DataPiece originalData;
    public string dataId;
    public string dataName;
    public string content;
    public override void InitSerialize(Interaction item) {
        AddItemInteraction temp = (AddItemInteraction) item;
        id = temp.id;
        dataId = temp.GetDataPiece().id;
        dataName = temp.GetDataPiece().name;
        content = temp.GetDataPiece().content;
    }
}
