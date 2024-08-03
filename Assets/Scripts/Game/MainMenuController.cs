using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    private int sceneIndex = 1;

    public void newGame() {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void exit() {
        Application.Quit();;
    }
}
