using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class StoryInteractableObject : ScriptableObject
{
    public List<Interactable> interactablesCurrentMap = new List<Interactable>();
    public List<Interactable> interactablesArc01 = new List<Interactable>();
    public List<Interactable> interactablesArc02 = new List<Interactable>();
    public List<Interactable> interactablesArc03 = new List<Interactable>();
    public List<Interactable> interactablesArc04 = new List<Interactable>();
}
