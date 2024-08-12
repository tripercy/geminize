using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class ChatInteraction : Interaction
{
    public string id;
    public string dialog;

    public DialogManager dialogManager;

    void loadDialog()
    {
        // TODO: Load dialog
    }

    public override GameObject trigger()
    {
        loadDialog();
        dialogManager.open(dialog);
        return dialogManager.gameObject;
    }

    public override Interaction InitDeserialize(InteractionData item) {
        ChatInteraction newInstance = new ChatInteraction();
        ChatInteractionData temp = (ChatInteractionData) item;
        newInstance.id = temp.id;
        newInstance.dialog = temp.dialog;
        Debug.Log(this.dialogManager);
        newInstance.dialogManager = dialogManager;
        return newInstance;
    }
}
