using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class StoryInteractableObject : ScriptableObject
{
    public List<GameObject> interactablesCurrentMap = new List<GameObject>();
    public List<GameObject> interactablesArc01 = new List<GameObject>();
    public List<GameObject> interactablesArc02 = new List<GameObject>();
    public List<GameObject> interactablesArc03 = new List<GameObject>();
    public List<GameObject> interactablesArc04 = new List<GameObject>();
}
