using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject lootableObject;
    public GameObject hintObject;
    
    public void ChangeLootable()
    {
        hintObject.SetActive(false);
        if (lootableObject.activeInHierarchy) {
            lootableObject.SetActive(false);
        } else {
            lootableObject.SetActive(true);
        }
    }

    public void ChangeHint()
    {
        lootableObject.SetActive(false);
        if (hintObject.activeInHierarchy) {
            hintObject.SetActive(false);
        }
        else {
            hintObject.SetActive(true);
        }
    }
}
