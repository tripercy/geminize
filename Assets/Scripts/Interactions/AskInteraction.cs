using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class AskInteraction : Interaction
{
    public string id;
    public GameplayMenu gameplayMenu;
    public Dictionary<string, string> expected;

    void loadExpected() {
        var loader = QuestionsLoader.Instance;

        foreach (var x in loader.container.questions) {
            if (x.id.CompareTo(id) == 0) {
                expected = x.dict;
            }
        }
    }

    public override GameObject trigger(DialogManager dialogManager)
    {
        loadExpected();
        gameplayMenu.OnGameplayMenuChange();
        return gameplayMenu.gameObject;
    }

    public override bool checkOutput() {
        var result = OutputObject.Instance.output;

        foreach (var key in expected.Keys) {
            if (result.GetValueOrDefault(key, "").CompareTo(expected[key]) != 0) {
                return false;
            }
        }

        return true;
    }

}
