using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text text;

    private Queue<string> dialogs = new Queue<string>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogs.Count == 0)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                text.text = dialogs.Dequeue();
            }
        }
    }

    public void toggle()
    {
        var isActive = this.gameObject.activeInHierarchy;
        this.gameObject.SetActive(!isActive);
    }

    public void open(string s)
    {
        text.text = s;
        this.gameObject.SetActive(true);
    }

    public void startDialog(List<string> input)
    {
        if (input.Count == 0) return;

        foreach (var s in input)
        {
            dialogs.Enqueue(s);
        }
        open(dialogs.Dequeue());
    }

    public void close()
    {
        if (this.gameObject)
        {
            this.gameObject.SetActive(false);
        }
    }
}
