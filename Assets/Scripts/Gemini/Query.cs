using System.Collections.Generic;
using UnityEngine;
using Uralstech.UGemini.Schema;
using Uralstech.UGemini.Chat;
using Uralstech.UGemini.Models;
using Uralstech.UGemini;
using System.Threading.Tasks;

public class Query : MonoBehaviour
{
    private const string sys_ins = "You are an assistance that helps the user to solve riddles using the input data.";

    private static Query _Instance;
    public static Query Instance
    {
        get
        {
            if (!_Instance)
            {
                _Instance = new GameObject().AddComponent<Query>();
                // name it for easy recognition
                _Instance.name = _Instance.GetType().ToString();
                // mark root as DontDestroyOnLoad();
                DontDestroyOnLoad(_Instance.gameObject);
            }
            return _Instance;
        }
    }

    private GeminiSchema buildSchema(string description, List<string> fields)
    {
        Dictionary<string, GeminiSchema> properties = new Dictionary<string, GeminiSchema>();
        foreach (var field in fields)
        {
            properties[field] = new GeminiSchema() { Type = GeminiSchemaDataType.String, };
        }

        return new GeminiSchema()
        {
            Type = GeminiSchemaDataType.Object,
            Properties = properties,
            Description = description,
            Required = fields.ToArray(),
        };
    }

    private GeminiChatRequest buildRequest(string content, string description, List<string> fields)
    {
        GeminiSchema schema = buildSchema(description, fields);

        return new GeminiChatRequest(GeminiModel.Gemini1_5Pro, useBetaApi: true)
        {
            Contents = new GeminiContent[]
                {
                    GeminiContent.GetContent(content, GeminiRole.User),
                },
            SystemInstruction = GeminiContent.GetContent(sys_ins),
            SafetySettings = new GeminiSafetySettings[] {
                new GeminiSafetySettings() {
                    Category = GeminiSafetyHarmCategory.DangerousContent,
                    Threshold = GeminiSafetyHarmBlockThreshold.None,
                }
            },
            GenerationConfig = new GeminiGenerationConfiguration()
            {
                Temperature = 0.0f,
                ResponseMimeType = GeminiResponseType.Json,
                ResponseSchema = schema,
            }
        };
    }

    void Awake()
    {
        // TODO: Read API key from where?
        GeminiManager.Instance.SetApiKey("");
    }

    public async Task<string> query(string content, string description, List<string> fields)
    {
        GeminiChatRequest request = buildRequest(content, description, fields);

        GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(request);

        return response.Parts[0].Text;
    }
}
