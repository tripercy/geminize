using UnityEngine;

[System.Serializable]
public abstract class Interaction
{
    // Returns a GameObject that stays active until the interaction is finished
    public abstract GameObject trigger();
}
