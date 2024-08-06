using UnityEngine;

public class DataPiecesLoader : MonoBehaviour
{
    public DataPieceContainer container;
    // Start is called before the first frame update
    void Start()
    {
        var jsonFile = Resources.Load<TextAsset>("data_pieces");
         container = JsonUtility.FromJson<DataPieceContainer>(jsonFile.text);
    }
}
