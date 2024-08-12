using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractionContainerData
{
    [SerializeReference]
    public List<InteractionData> interactionsData;
    [SerializeReference]
    public InteractionData defaultInteractionData;

}
