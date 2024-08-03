using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject lootableObject;
    public GameObject hintObject;
    
    public void EnableLootable()
    {
        hintObject.SetActive(false);
        lootableObject.SetActive(true);
    }

    public void EnableHint()
    {
        lootableObject.SetActive(false);
        hintObject.SetActive(true);
    }

    public void Diable()
    {
        lootableObject.SetActive(false);
        hintObject.SetActive(false);
    }
}
