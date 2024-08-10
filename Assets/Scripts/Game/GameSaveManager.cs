using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager gameSave;
    public VectorValue position;
    public PlayerController player;
    public List<ScriptableObject> scriptableObjects = new List<ScriptableObject>();

    //Lootable objects
    //Player Inventory
    //PlayerPosition

    // private void OnEnable()
    // {
    //     LoadGame();
    // }

    private void OnDisable()
    {
        SaveGame();
    }

    public void SaveGame()
    {
        // position.initialValue = player.gameObject.transform.position;
        // SceneManager.GetActiveScene();
        for (int i = 0; i < scriptableObjects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(scriptableObjects[i]);
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
