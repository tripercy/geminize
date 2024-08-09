using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class ChatInteraction : Interaction
{
    public string id;
    public string dialog;

    public DialogManager dialogManager;

    void Start()
    {
        // TODO: Load dialog
    }

    public override GameObject trigger()
    {
        dialogManager.open(dialog);
        return dialogManager.gameObject;
    }
}
