using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testmanager : MonoBehaviour
{

    public Signal hello;
    public string res = "";
    private void Start() {
        Hello();
    }

    public void Hello() {
        print("hello");
        hello.Raise();
    }

    public void Hello2() {
        print("hello2");
    }

    
}
