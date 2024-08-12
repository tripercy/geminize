using UnityEngine;

[System.Serializable]
public abstract class Interaction
{
    public abstract GameObject trigger();
    // Runs a check on output for completed
    public virtual bool checkOutput() {
        return true;
    }
    public virtual Interaction InitDeserialize(InteractionData interactionData) {
        return null;
    }
}
