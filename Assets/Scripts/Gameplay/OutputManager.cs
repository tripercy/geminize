using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI outputContent;

    private void OnEnable() {
        outputContent.text = "";
    }

    public void SetContent() {
        // Set content after query successful with signal raise
        outputContent.text = string.Join(Environment.NewLine, OutputObject.Instance.output);
    }
}
