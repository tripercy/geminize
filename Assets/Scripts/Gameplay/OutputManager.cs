using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI outputContent;
    public GameObject querysomesome;

    public void OnSetContent() {

    }
    public void SetContent() {
        // Set content after query successful with signal raise
        outputContent.text = "";
    }
}
