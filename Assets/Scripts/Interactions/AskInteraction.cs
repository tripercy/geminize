using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class AskInteraction : Interaction
{
    public string id;
    public PauseManager pauseManager;
    public Dictionary<string, string> expected = new Dictionary<string, string>();

    void loadExpected()
    {
        var loader = QuestionsLoader.Instance;

        foreach (var x in loader.container.questions)
        {
            if (x.id.CompareTo(id) == 0)
            {
                expected = x.dict;
            }
        }
    }

    public override GameObject trigger(DialogManager dialogManager)
    {
        loadExpected();
        pauseManager.OnQueryBoardChange();
        return pauseManager.gameObject.transform.GetComponentInChildren<QueryBoardManager>(true).gameObject;
    }

    public override bool checkOutput()
    {
        var result = OutputObject.Instance.output;

        foreach (var key in expected.Keys)
        {
            if (result.GetValueOrDefault(key, "").CompareTo(expected[key]) != 0)
            {
                return false;
            }
        }

        return true;
    }

    public override Interaction InitDeserialize(InteractionData item) {
        AskInteraction newInstance = new AskInteraction(); 
        AskInteractionData temp = (AskInteractionData) item;
        newInstance.id = temp.id;
        // newInstance.gameplayMenu =gameplayMenu;
        // TODO: Load pause manager
        newInstance.expected = new Dictionary<string, string>();
        for (int i = 0; i < temp.keys.Count; i++) {
            newInstance.expected[temp.keys[i]] = temp.values[i];
        }
        return newInstance;
    }
}
