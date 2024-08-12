using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class AskInteractionData : InteractionData
{
    public string id;
    // public GameplayMenu gameplayMenu;
    // public Dictionary<string, string> expected;
    public List<string> keys;
    public List<string> values;

    public override void InitSerialize(Interaction item) {
        AskInteraction temp = (AskInteraction) item;
        id = temp.id;
        foreach (KeyValuePair<string, string> kvp in temp.expected)
        {
            string key = kvp.Key;
            string value = kvp.Value;

            // Print the key and value
            keys.Add(key);
            values.Add(value);
        }
    }
}
