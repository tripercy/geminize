using UnityEngine;

public class OutputTemplatesLoader : MonoBehaviour
{
    public OutputTemplateContainer container;

    private static OutputTemplatesLoader _Instance;
	public static OutputTemplatesLoader Instance
	{
		get
		{
			if (!_Instance)
			{
				_Instance = new GameObject().AddComponent<OutputTemplatesLoader>();
				// name it for easy recognition
				_Instance.name = _Instance.GetType().ToString();
				// mark root as DontDestroyOnLoad();
				DontDestroyOnLoad(_Instance.gameObject);
			}
			return _Instance;
		}
	}

    void Awake()
    {
        var jsonFile = Resources.Load<TextAsset>("output_templates");
        container = JsonUtility.FromJson<OutputTemplateContainer>(jsonFile.text);
    }

    public static OutputTemplatesLoader getInstance()
    {
        return Instance;
    }
}
