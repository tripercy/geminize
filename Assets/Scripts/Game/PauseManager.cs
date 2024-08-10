using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public GameObject queryPanel;
    public static bool isReceivable = true;
    private bool isPaused;
    private Vector3 closedPosition;
    private RectTransform currentGo;

    private void Start()
    {
        isPaused = false;
        inventoryPanel.SetActive(false);
        pausePanel.SetActive(false);
        queryPanel.SetActive(false);
        closedPosition = new Vector3(0, -Screen.height, 0);

        // Move all panels to the closed position initially
        inventoryPanel.GetComponent<RectTransform>().localPosition = closedPosition;
        queryPanel.GetComponent<RectTransform>().localPosition = closedPosition;
        pausePanel.GetComponent<RectTransform>().localPosition = closedPosition;
    }

    private void Update()
    {
        if (inventoryPanel.activeInHierarchy || queryPanel.activeInHierarchy || pausePanel.activeInHierarchy)
        {
            isPaused = true;
        }
        else
        {
            isPaused = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (queryPanel.activeInHierarchy)
            {
                OnQueryBoardChange();
            }
            else
            {
                PauseChange();
            }
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            BagChange();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            OnQueryBoardChange();
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
            Time.timeScale = 0f;
            isReceivable = false;
        }
        else
        {
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
            MoveObject(inventoryPanel.GetComponent<RectTransform>(), Vector3.zero);
            Time.timeScale = 0f;
            isReceivable = false;
        }
        else
        {
            MoveObject(inventoryPanel.GetComponent<RectTransform>(), closedPosition);
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
            MoveObject(queryPanel.GetComponent<RectTransform>(), Vector3.zero);
            Time.timeScale = 0f;
            isReceivable = false;
        }
        else
        {
            MoveObject(queryPanel.GetComponent<RectTransform>(), closedPosition);
            Time.timeScale = 1f;
            isReceivable = true;
        }
    }

    public void MoveObject(RectTransform currentGO, Vector3 targetPosition)
    {
        StopAllCoroutines();
        StartCoroutine(SmoothTransition(currentGO, targetPosition));
    }

    private IEnumerator SmoothTransition(RectTransform currentGo, Vector3 targetPosition)
    {
        while (Vector3.Distance(currentGo.localPosition, targetPosition) > 0.01f)
        {
            currentGo.localPosition = Vector3.Lerp(currentGo.localPosition, targetPosition, 5f * Time.unscaledDeltaTime);
            yield return null;
        }
        currentGo.localPosition = targetPosition;

        // Deactivate the panel if it's moved to the closed position
        if (targetPosition == closedPosition)
        {
            currentGo.gameObject.SetActive(false);
        }
    }
}
