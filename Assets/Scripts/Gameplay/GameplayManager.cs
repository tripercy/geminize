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
    public List<string> queryStatement;
    public GameObject executeBtn;
    public GameObject confirmBtn;

    private void OnEnable()
    {
        executeBtn.SetActive(true);
        confirmBtn.SetActive(false);
    }
    public void OnClickBtn()
    {
        queryStatement = new List<string>();
        queryBoardSignal.Raise();
        outputTemplateSignal.Raise();
        queryStatement.Add(queryBoardManager.res);
        queryStatement.Add(outputTemplateManager.currentData);
    }
    public async void awaitForData()
    {
        
        executeBtn.SetActive(false);
        confirmBtn.SetActive(true);
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
