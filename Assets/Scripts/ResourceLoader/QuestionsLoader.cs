using Newtonsoft.Json;
using UnityEngine;

public class QuestionsLoader : MonoBehaviour
{
    public QuestionContainer container;

    private static QuestionsLoader _Instance;
	public static QuestionsLoader Instance
	{
		get
		{
			if (!_Instance)
			{
				_Instance = new GameObject().AddComponent<QuestionsLoader>();
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
        var jsonFile = Resources.Load<TextAsset>("questions");
        container = JsonConvert.DeserializeObject<QuestionContainer>(jsonFile.text);
    }

    public static QuestionsLoader getInstance()
    {
        return Instance;
    }
}
