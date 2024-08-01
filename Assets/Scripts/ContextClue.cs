using UnityEngine;
using UnityEngine.SceneManagement;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;

    public void OnEnable() {
        contextClue.SetActive(true);
    }

    public void OnDisable() {
        contextClue.SetActive(false);
    }
}
