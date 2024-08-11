using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ChatInteraction : Interaction
{
    public string id;
    [TextArea]
    public List<string> dialog;

    void loadDialog()
    {
        // TODO: Load dialog
    }

    public override GameObject trigger(DialogManager dialogManager)
    {
        loadDialog();
        dialogManager.startDialog(dialog);
        return dialogManager.gameObject;
    }
}
