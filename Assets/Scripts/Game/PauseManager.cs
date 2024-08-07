using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public GameObject queryPanel;
    public Signal querySignal;
    public static bool isReceivable = true;
    private bool isPaused;
    // Update is called once per frame
    private void Start()
    {
        isPaused = false;
        inventoryPanel.SetActive(false);
        pausePanel.SetActive(false);
        queryPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseChange();
        }
        else if (Input.GetKeyDown(KeyCode.B) && !LootableObject.isOpening) 
        {
            BagChange();
        }
        // else if (Input.GetKeyDown(Ke)) {

        // }
    }

    public void PauseChange()
    {
        if (inventoryPanel.activeInHierarchy && queryPanel.activeInHierarchy) {
            return;
        }
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            isReceivable = false;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            isReceivable = true;
        }
    }

    public void ExitToMenu() {
        SceneManager.LoadScene("MainMenu");
        if (Time.timeScale == 0f) {
            Time.timeScale = 1f;
            isReceivable = true;
        }
    }

    public void BagChange() {
        if (pausePanel.activeInHierarchy && queryPanel.activeInHierarchy) {
            return;
        }
        isPaused = !isPaused;
        if (isPaused)
        {
            inventoryPanel.SetActive(true);
            Time.timeScale = 0f;
            isReceivable = false;
        }
        else
        {
            inventoryPanel.SetActive(false);
            Time.timeScale = 1f;
            isReceivable = true;
        }
    }

    public void OnQueryBoardChange() {
        if (pausePanel.activeInHierarchy && inventoryPanel.activeInHierarchy) {
            return;
        }
        isPaused = !isPaused;
        if (isPaused)
        {
            queryPanel.SetActive(true);
            Time.timeScale = 0f;
            isReceivable = false;
        }
        else
        {
            queryPanel.SetActive(false);
            Time.timeScale = 1f;
            isReceivable = true;
        }
    }
}
