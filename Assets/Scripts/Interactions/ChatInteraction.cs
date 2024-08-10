using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ChatInteraction : Interaction
{
    public string id;
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
}
