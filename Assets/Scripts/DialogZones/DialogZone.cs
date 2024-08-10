using System.Collections.Generic;
using UnityEngine;

class DialogZone : MonoBehaviour
{
    [TextArea]
    public List<string> dialogs;
    public bool activeOnce = true;
    public DialogManager dialogManager;

    void OnTriggerEnter2D()
    {
        if (this.gameObject.activeInHierarchy)
        {
            dialogManager.startDialog(dialogs);
            if (activeOnce) {
                Destroy(this.gameObject);
            }
        }
    }
}
