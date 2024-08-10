using UnityEngine;

public class StoryController : MonoBehaviour {
    public CurrentStory currentStory;
    public GameObject arc_1, arc_2, arc_3, arc_4;

    private StoryArc loadingStory;

    public void Start() {
        switchArc(currentStory.currentArc);
    }

    public void Update() {
        if (currentStory.currentArc != loadingStory) {
            switchArc(currentStory.currentArc);
        }
    }

    void switchArc(StoryArc arc) {
        arc_1.SetActive(false);
        arc_2.SetActive(false);
        arc_3.SetActive(false);
        arc_4.SetActive(false);
        switch (arc) {
            case StoryArc.ARC_1:
                arc_1.SetActive(true);
                break;
            case StoryArc.ARC_2:
                arc_2.SetActive(true);
                break;
            case StoryArc.ARC_3:
                arc_3.SetActive(true);
                break;
            case StoryArc.ARC_4:
                arc_4.SetActive(true);
                break;
        }

        loadingStory = arc;
    }
}
