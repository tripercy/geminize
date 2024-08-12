using System.Collections.Generic;
using UnityEngine;

public class InteractionContainer : MonoBehaviour
{
    [SerializeReference]
    public List<Interaction> interactions;
    [SerializeReference]
    public Interaction defaultInteraction;

    public List<Interaction> InitDeserialize(InteractionContainerData data)
    {
        List<Interaction> result = new List<Interaction>();
        for (int i = 0; i < data.interactionsData.Count; i++)
        {
            if (this.interactions[i].GetType() == typeof(AddItemInteraction))
            {
                AddItemInteraction temp = (AddItemInteraction)this.interactions[i];
                temp = (AddItemInteraction) temp.InitDeserialize(data.interactionsData[i]);
                result.Add(temp);
            }
            else if (this.interactions[i].GetType() == typeof(AskInteraction))
            {
                AskInteraction temp = (AskInteraction)this.interactions[i];
                temp = (AskInteraction) temp.InitDeserialize(data.interactionsData[i]);
                result.Add(temp);
            }
            else if (this.interactions[i].GetType() == typeof(ChatInteraction))
            {
                ChatInteraction temp = (ChatInteraction)this.interactions[i];
                temp = (ChatInteraction )temp.InitDeserialize(data.interactionsData[i]);
                result.Add(temp);
            }
            else if (this.interactions[i].GetType() == typeof(GetItemInteraction))
            {
                GetItemInteraction temp = (GetItemInteraction)this.interactions[i];
                temp = (GetItemInteraction)temp.InitDeserialize(data.interactionsData[i]);
                result.Add(temp);
            }
        }
        return result;
    }

    public Interaction InitDeserializeDefault(InteractionContainerData data)
    {
        if (defaultInteraction is AddItemInteraction)
        {
            AddItemInteraction result = new AddItemInteraction();
            result = (AddItemInteraction) result.InitDeserialize(data.defaultInteractionData);
            return result;
        }
        else if (defaultInteraction is AskInteraction)
        {
            AskInteraction result = new AskInteraction();
            result = (AskInteraction) result.InitDeserialize(data.defaultInteractionData);
            return result;
        }
        else if (defaultInteraction is ChatInteraction)
        {
            ChatInteraction result = new ChatInteraction();
            result = (ChatInteraction)result.InitDeserialize(data.defaultInteractionData);
            return result;
        }
        else if (defaultInteraction is GetItemInteraction)
        {
            GetItemInteraction result = new GetItemInteraction();
            result = (GetItemInteraction)result.InitDeserialize(data.defaultInteractionData);
            return result;
        }
        return null;
    }
}

