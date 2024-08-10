using UnityEngine;

public class DataPiecesLoader : MonoBehaviour
{
    public DataPieceContainer container;
    public static DataPiecesLoader Instance;

    void Start()
    {
        var jsonFile = Resources.Load<TextAsset>("data_pieces");
        container = JsonUtility.FromJson<DataPieceContainer>(jsonFile.text);
        Instance = this;
    }

    public static DataPiecesLoader getInstance()
    {
        return Instance;
    }
}
