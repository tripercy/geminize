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
using Screen = UnityEngine.Screen;

public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public GameObject queryPanel;
    public Signal querySignal;
    public static bool isReceivable = true;
    private bool isPaused;
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private RectTransform pausePanelPos;
    // Update is called once per frame
    private void Start()
    {
        pausePanelPos = GetComponent<RectTransform>();
        isPaused = false;
        inventoryPanel.SetActive(false);
        pausePanel.SetActive(false);
        queryPanel.SetActive(false);
        closedPosition = new Vector3(0, -Screen.height, 0);
        openPosition = pausePanelPos.localPosition;

        this.GetComponent<RectTransform>().localPosition = closedPosition;
    }
    void Update()
    {
        if (inventoryPanel.activeInHierarchy || queryPanel.activeInHierarchy || pausePanel.activeInHierarchy)
        {
            isPaused = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (queryPanel.activeInHierarchy)
            {
                OnQueryBoardChange();
            }
            else
                PauseChange();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            BagChange();
        }
    }

    public void PauseChange()
    {
        if (inventoryPanel.activeInHierarchy || queryPanel.activeInHierarchy)
        {
            return;
        }
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            // MoveObject(pausePanel.transform.position);
            Time.timeScale = 0f;
            isReceivable = false;
        }
        else
        {
            pausePanel.SetActive(false);
            MoveObject(closedPosition);
            Time.timeScale = 1f;
            isReceivable = true;
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            isReceivable = true;
        }
    }

    public void BagChange()
    {
        if (pausePanel.activeInHierarchy || queryPanel.activeInHierarchy)
        {
            return;
        }
        isPaused = !isPaused;
        if (isPaused)
        {
            inventoryPanel.SetActive(true);
            // MoveObject(inventoryPanel.transform.position);
            Time.timeScale = 0f;
            isReceivable = false;
        }
        else
        {
            inventoryPanel.SetActive(false);
            // MoveObject(pausePanel.transform.position);
            Time.timeScale = 1f;
            isReceivable = true;
        }
    }

    public void OnQueryBoardChange()
    {
        if (pausePanel.activeInHierarchy || inventoryPanel.activeInHierarchy)
        {
            return;
        }
        isPaused = !isPaused;
        if (isPaused)
        {
            queryPanel.SetActive(true);
            // MoveObject(queryPanel.transform.position);
            Time.timeScale = 0f;
            isReceivable = false;
        }
        else
        {
            queryPanel.SetActive(false);
            // MoveObject(pausePanel.transform.position);
            Time.timeScale = 1f;
            isReceivable = true;
        }
    }

    public void MoveObject(Vector3 position)
    {
        StopAllCoroutines();
        StartCoroutine(SmoothTransition(isPaused ? openPosition : closedPosition));
    }

    private IEnumerator SmoothTransition(Vector3 targetPosition)
    {
        while (Vector3.Distance(pausePanelPos.localPosition, targetPosition) > 0.01f)
        {
            pausePanelPos.localPosition = Vector3.Lerp(pausePanelPos.localPosition, targetPosition, 20 * Time.deltaTime);
            yield return null;
        }
        pausePanelPos.localPosition = targetPosition;
    }
}
