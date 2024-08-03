using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel;
    private bool isPaused;
    // Update is called once per frame
    private void Start()
    {
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseChange();
        }
    }

    public void pauseChange()
    {

        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void exitToMenu() {
        SceneManager.LoadScene("MainMenu");
        if (Time.timeScale == 0f) {
            Time.timeScale = 1f;
        }
    }
}
