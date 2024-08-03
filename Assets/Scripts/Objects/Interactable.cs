using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public Signal clueOn;
    public GameObject ClueOff;
    public GameObject DialogBox;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            isInRange = true;
            clueOn.Raise();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            isInRange = false;
            DialogBox.SetActive(false);
            ClueOff.SetActive(false);
        }
    }
}
