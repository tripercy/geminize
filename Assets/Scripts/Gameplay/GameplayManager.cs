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
    public List<string> queryStatement;

    public void OnClickBtn() {
        queryStatement = new List<string>();
        queryBoardSignal.Raise();
        outputTemplateSignal.Raise();
        queryStatement.Add(queryBoardManager.res);
        queryStatement.Add(outputTemplateManager.currentData);
        print(queryStatement[0]);
        print(queryStatement[1]);
    }
}
