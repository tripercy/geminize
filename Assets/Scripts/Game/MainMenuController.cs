using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameSaveManager gameSaveManager;

    public void NewGame() {
        gameSaveManager.ResetGame();
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void Exit() {
        Application.Quit();;
    }
}
