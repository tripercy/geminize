using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class OutputObject : MonoBehaviour
{
    public Dictionary<string, string> output;

    private static OutputObject _Instance;
	public static OutputObject Instance
	{
		get
		{
			if (!_Instance)
			{
				_Instance = new GameObject().AddComponent<OutputObject>();
				// name it for easy recognition
				_Instance.name = _Instance.GetType().ToString();
				// mark root as DontDestroyOnLoad();
				DontDestroyOnLoad(_Instance.gameObject);
			}
			return _Instance;
		}
	}

    void Awake() {
        output = new Dictionary<string, string>();
    }


    public async Task generateOutput(string data, string fields)
    {
        List<string> fields_list = new List<string>(fields.Split(' '));
        string resTask = await Query.Instance.query(data, "", fields_list);

        output = JsonConvert.DeserializeObject<Dictionary<string, string>>(resTask);
    }

}
