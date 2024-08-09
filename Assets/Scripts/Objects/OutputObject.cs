using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class OutputObject : MonoBehaviour
{
    public static OutputObject Instance { get; private set; }
    public Dictionary<string, string> output;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        Instance.output = new Dictionary<string, string>();
    }

    public async Task generateOutput(string data, string fields)
    {
        List<string> fields_list = new List<string>(fields.Split(' '));
        string resTask = await Query.getInstance().query(data, "", fields_list);

        output = JsonConvert.DeserializeObject<Dictionary<string, string>>(resTask);
    }

}
