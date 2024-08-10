using System.Collections.Generic;
using UnityEngine;

class DialogZone : MonoBehaviour
{
    [TextArea]
    public List<string> dialogs;
    public bool activateOnce = true;
    public DialogManager dialogManager;

    void OnTriggerEnter2D()
    {
        if (this.gameObject.activeInHierarchy)
        {
            dialogManager.startDialog(dialogs);
            if (activateOnce) {
                Destroy(this.gameObject);
            }
        }
    }
}
