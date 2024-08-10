using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager gameSave;
    public VectorValue position;
    public PlayerController player;
    public List<ScriptableObject> scriptableObjects = new List<ScriptableObject>();
    [SerializeField] public GameObject story;
    public StoryInteractableObject storyInteractable;

    //Lootable objects
    //Player Inventory
    //PlayerPosition

    // private void OnEnable()
    // {
    //     LoadGame();
    // }

    // private void OnDisable()
    // {
    //     SaveGame();
    // }

    public void SaveGame()
    {
        position.initialValue = player.gameObject.transform.position;
        position.sceneIndex = player.sceneIndex;
        int i = 0;
        for (; i < scriptableObjects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(scriptableObjects[i]);
            binary.Serialize(file, json);
            file.Close();
        }
        for (int j = 0; j < storyInteractable.interactablesArc01.Count; j++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            i++;
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(storyInteractable.interactablesArc01[j]);
            binary.Serialize(file, json);
            file.Close();
        }
        for (int k = 0; k < storyInteractable.interactablesArc02.Count; k++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            i++;
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(storyInteractable.interactablesArc02[k]);
            binary.Serialize(file, json);
            file.Close();
        }
        for (int l = 0; l < storyInteractable.interactablesArc03.Count; l++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            i++;
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(storyInteractable.interactablesArc03[l]);
            binary.Serialize(file, json);
            file.Close();
        }
        for (int m = 0; m < storyInteractable.interactablesArc04.Count; m++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            i++;
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(storyInteractable.interactablesArc04[m]);
            binary.Serialize(file, json);
            file.Close();
        }
        for (int n = 0; n < storyInteractable.interactablesCurrentMap.Count; n++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            i++;
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(storyInteractable.interactablesCurrentMap[n]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadGame()
    {
        int i = 0;
        for (; i < scriptableObjects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), scriptableObjects[i]);
                file.Close();
            }
        }

    }

    public void ResetGame()
    {
        int i = 0;
        for (; i < scriptableObjects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                File.Delete(Application.persistentDataPath + string.Format("/{0}.dat", i));
            }
        }
    }
}
