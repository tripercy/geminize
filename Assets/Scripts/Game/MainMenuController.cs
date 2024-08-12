using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameSaveManager gameSaveManager;
    public VectorValue position;

    public void NewGame() {
        // gameSaveManager.ResetGame();
        position.initialValue = position.defaultValue;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadGame() {
        // SceneManager.LoadScene(position.sceneIndex, LoadSceneMode.Single);
    }

    public void Exit() {
        Application.Quit();
    }
}
