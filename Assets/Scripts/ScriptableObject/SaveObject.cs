using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[System.Serializable]
public class SaveObject
{
    public float[] position;
    private InteractionContainer interactionContainer;
    [SerializeField]public InteractionContainerData interactionContainerData;
    public void InitObject(GameObject interactableObject)
    {
        interactionContainerData = new InteractionContainerData();
        position = new float[3];
        position[0] = interactableObject.transform.position.x;
        position[1] = interactableObject.transform.position.y;
        position[2] = interactableObject.transform.position.z;
        interactionContainer = interactableObject.GetComponent<InteractionContainer>();
        interactionContainerData.interactionsData = new List<InteractionData>();
        for (int i = 0; i < interactionContainer.interactions.Count; i++)
        {
            if (interactionContainer.interactions[i].GetType() == typeof(AddItemInteraction))
            {
                AddItemInteractionData temp = new AddItemInteractionData();
                temp.InitSerialize(interactionContainer.interactions[i]);
                interactionContainerData.interactionsData.Add(temp);
            }
            else if (interactionContainer.interactions[i].GetType() == typeof(AskInteraction))
            {
                AskInteractionData temp = new AskInteractionData();
                temp.InitSerialize(interactionContainer.interactions[i]);
                interactionContainerData.interactionsData.Add(temp);
            }
            else if (interactionContainer.interactions[i].GetType() == typeof(ChatInteraction))
            {
                ChatInteractionData temp = new ChatInteractionData();
                temp.InitSerialize(interactionContainer.interactions[i]);
                interactionContainerData.interactionsData.Add(temp);
            }
            else if (interactionContainer.interactions[i].GetType() == typeof(GetItemInteraction))
            {
                GetItemInteractionData temp = new GetItemInteractionData();
                temp.InitSerialize(interactionContainer.interactions[i]);
                interactionContainerData.interactionsData.Add(temp);
            }
            
        }
        if (interactionContainer.defaultInteraction is AddItemInteraction interaction)
        {
            interactionContainerData.defaultInteractionData = new AddItemInteractionData();
            AddItemInteractionData temp = new();
            temp.InitSerialize(interaction);
            interactionContainerData.defaultInteractionData = temp;
        }
        else if (interactionContainer.defaultInteraction is AskInteraction interaction1)
        {
            interactionContainerData.defaultInteractionData = new AskInteractionData();
            AskInteractionData temp = new();
            temp.InitSerialize(interaction1);
            interactionContainerData.defaultInteractionData = temp;
        }
        else if (interactionContainer.defaultInteraction is ChatInteraction interaction2)
        {
            interactionContainerData.defaultInteractionData = new ChatInteractionData();
            ChatInteractionData temp = new();
            temp.InitSerialize(interaction2);
            interactionContainerData.defaultInteractionData = temp;
        }
        else if (interactionContainer.defaultInteraction is ChatInteraction interaction3)
        {
            interactionContainerData.defaultInteractionData = new GetItemInteractionData();
            ChatInteractionData temp = new();
            temp.InitSerialize(interaction3);
            interactionContainerData.defaultInteractionData = temp;
        }
    }
    // public InteractionContainer GetInteractionContainer()
    // {
    //     return this.interactionContainer;
    // }
}
