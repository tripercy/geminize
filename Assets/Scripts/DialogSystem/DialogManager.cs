using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public Text text;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            this.gameObject.SetActive(false);
        }
    }

    public void toggle() {
        var isActive = this.gameObject.activeInHierarchy;
        this.gameObject.SetActive(!isActive);
    }

    public void open(string s) {
        text.text = s;
        this.gameObject.SetActive(true);
    }

    public void close() {
        this.gameObject.SetActive(false);
    }
}
