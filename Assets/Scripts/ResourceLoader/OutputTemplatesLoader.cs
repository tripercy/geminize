using UnityEngine;

public class OutputTemplatesLoader : MonoBehaviour
{
    public OutputTemplateContainer container;
    // Start is called before the first frame update
    void Start()
    {
        var jsonFile = Resources.Load<TextAsset>("output_templates");
        container = JsonUtility.FromJson<OutputTemplateContainer>(jsonFile.text);
    }
}
