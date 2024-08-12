using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ChatInteractionData : InteractionData
{
    public string id;
    public List<string> dialog;

    // public DialogManager dialogManager;
    public override void InitSerialize(Interaction item) {
        ChatInteraction temp = (ChatInteraction) item;
        id = temp.id;
        dialog = temp.dialog;
    }
}
