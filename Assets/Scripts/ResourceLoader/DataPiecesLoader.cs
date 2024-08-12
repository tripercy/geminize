using UnityEngine;

public class DataPiecesLoader : MonoBehaviour
{
    public DataPieceContainer container;

    private static DataPiecesLoader _Instance;
	public static DataPiecesLoader Instance
	{
		get
		{
			if (!_Instance)
			{
				_Instance = new GameObject().AddComponent<DataPiecesLoader>();
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
        var jsonFile = Resources.Load<TextAsset>("data_pieces");
        container = JsonUtility.FromJson<DataPieceContainer>(jsonFile.text);
    }

    public static DataPiecesLoader getInstance()
    {
        return Instance;
    }
}
