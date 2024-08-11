using UnityEngine;

public class StoryIncrementer : MonoBehaviour {
    public CurrentStory currentStory;
    public StoryArc setToArc;
    public InteractionContainer interactionContainer;

    // The incrementer activates once the interaction container runs out of interaction
    void OnDisable() {
        if (interactionContainer.interactions.Count == 0) {
            currentStory.currentArc = setToArc;
        }
    }
}
