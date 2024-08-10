using UnityEngine;

[CreateAssetMenu(fileName = "Output Template Loader", menuName = "Loader/OutputTemplate")]
public class OutputTemplatesLoader : ScriptableObject
{
    public OutputTemplateContainer container;
    // Start is called before the first frame update
    void OnEnable()
    {
        var jsonFile = Resources.Load<TextAsset>("output_templates");
        container = JsonUtility.FromJson<OutputTemplateContainer>(jsonFile.text);
    }
}
