using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class ChatInteraction : Interaction
{
    public string id;
    public string dialog;

    public GameObject dialogBox;
    public Text dialogText;

    void Start()
    {
        // TODO: Load dialog
    }

    public override void trigger()
    {
        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
        }
        else
        {
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }
    }
}