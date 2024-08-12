using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ChatInteraction : Interaction
{
    public string id;
    [TextArea]
    public List<string> dialog;

    public DialogManager dialogManager;

    void loadDialog()
    {
        // TODO: Load dialog
    }

    public override GameObject trigger()
    {
        loadDialog();
        dialogManager.startDialog(dialog);
        return dialogManager.gameObject;
    }

    public override Interaction InitDeserialize(InteractionData item) {
        ChatInteraction newInstance = new ChatInteraction();
        ChatInteractionData temp = (ChatInteractionData) item;
        newInstance.id = temp.id;
        // newInstance.dialog = temp.dialog;
        newInstance.dialogManager = dialogManager;
        return newInstance;
    }
}
