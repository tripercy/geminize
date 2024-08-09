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
}
