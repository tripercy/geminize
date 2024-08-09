using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class AskInteraction : Interaction
{
    public GameplayMenu gameplayMenu;

    public override GameObject trigger()
    {
        gameplayMenu.OnGameplayMenuChange();
        return null;
    }

}
