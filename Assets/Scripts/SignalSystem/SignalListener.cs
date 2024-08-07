using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent signalEvent;

    public void OnRaised() {
        signalEvent.Invoke();
    }

    public void OnEnable() {
        signal.ResgisterListener(this); ;
    }

    public void OnDisable() {
        signal.DeregisterListener(this);
    }
}
