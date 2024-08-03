using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintObject : Interactable
{
    // Start is called before the first frame update
    //Access UI (tag)
    //Refference to dialog
    //Reference to text
    //String what the text
    public Text dialogText;
    public String dialog;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInRange)
        {
            if (DialogBox.activeInHierarchy)
            {
                clueOn.Raise();
                DialogBox.SetActive(false);
            }
            else
            {
                ClueOff.SetActive(false);
                DialogBox.SetActive(true);
                dialogText.text = "Dialog";
            }
        }
    }

}
