using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
[System.Serializable]
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners;

    public void Raise() {
        for (int i = listeners.Count - 1; i >= 0 ; i--) {
            listeners[i].OnRaised();
        }
    }

    public void ResgisterListener(SignalListener listener) {
        listeners.Add(listener);
    }

    public void DeregisterListener(SignalListener listener) {
        listeners.Remove(listener);
    }
}


