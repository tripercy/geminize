using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputObject : MonoBehaviour
{
    private Dictionary<string, string> data;

    void Start()
    {
        
    }

    public void query(string input) {
        // TODO: quey gemini
        string query_res = "{}";

        data = JsonUtility.FromJson<Dictionary<string, string>>(query_res);
    }

    void display() {

    }
}
