
using System.Collections.Generic;
using UnityEngine;

public class InteractionContainer : MonoBehaviour
{
    [SerializeReference]
    public List<Interaction> interactions;
    [SerializeReference]
    public Interaction defaultInteraction;
}

