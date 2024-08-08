using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    public Signal queryBoardSignal;
    public Signal outputTemplateSignal;
    public QueryBoardManager queryBoardManager;
    public OutputTemplateManager outputTemplateManager;
    public GameObject gameplayMenuObject;
    public GameObject waitingObject;
    public OutputManager outputmanager;
    private List<string> queryStatement;
    public GameObject executeBtn;
    public GameObject confirmBtn;

    private void OnEnable()
    {
        executeBtn.SetActive(true);
        confirmBtn.SetActive(false);
        waitingObject.SetActive(false);
    }
    public void OnClickBtn()
    {
        queryStatement = new List<string>();
        queryBoardSignal.Raise();
        outputTemplateSignal.Raise();
        queryStatement.Add(queryBoardManager.res);
        queryStatement.Add(outputTemplateManager.currentData);
        waitingObject.SetActive(true);
        AwaitForData();
    }
    public async void AwaitForData()
    {
        print("HELLO");
        await OutputObject.Instance.generateOutput(queryStatement[0], queryStatement[1]);
        print(OutputObject.Instance.output);
        executeBtn.SetActive(false);
        confirmBtn.SetActive(true);
        waitingObject.SetActive(false);
        outputmanager.SetContent();
    }

    public void OnGameplayMenuChange()
    {
        if (gameplayMenuObject.activeInHierarchy)
        {
            gameplayMenuObject.SetActive(false);
        }
        else
        {
            gameplayMenuObject.SetActive(true);
        }
    }
}
