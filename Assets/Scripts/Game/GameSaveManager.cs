using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager gameSave;
    public VectorValue position;
    public PlayerController player;
    public List<ScriptableObject> scriptableObjects = new();
    [SerializeField] private GameObject story;
    [SerializeField] public GameObject ClueOff;
    [SerializeField] public DialogManager dialogManager;
    [SerializeField] private PauseManager pauseManager;
    private SaveObject saveObject;

    //Lootable objects
    //Player Inventory
    //PlayerPosition

    private void Awake()
    {
        saveObject = new SaveObject();
        LoadGame();
    }

    private void Update()
    {
        ApplieObject();
    }

    public void ApplieObject()
    {
        GameSaveManager gameSaveManager = FindObjectOfType<GameSaveManager>();
        if (gameSaveManager != null)
        {
            gameSave = gameSaveManager;
        }
        PlayerController playerCurrent = FindObjectOfType<PlayerController>();
        if (playerCurrent != null)
        {
            this.player = playerCurrent;
        }
        StoryController storyCurrent = FindObjectOfType<StoryController>();
        if (storyCurrent != null)
        {
            this.story = storyCurrent.transform.gameObject;
        }
        DialogManager dialogCurrent = FindObjectOfType<DialogManager>();
        if (dialogCurrent != null)
        {
            this.dialogManager = dialogCurrent;
        }
        PauseManager pauseCurrent = FindObjectOfType<PauseManager>();
        if (pauseCurrent != null)
        {
            this.pauseManager = pauseCurrent;
        }
    }
    public void SaveGame()
    {
        position.initialValue = player.gameObject.transform.position;
        position.sceneIndex = player.sceneIndex;
        print(player);
        int i = 0;
        //
        for (; i < scriptableObjects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(scriptableObjects[i]);
            binary.Serialize(file, json);
            file.Close();
        }

        for (int a = 0; a < story.transform.childCount; a++)
        {
            if (story.transform.GetChild(a).GetComponent<Interactable>())
            {
                FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
                i++;
                BinaryFormatter binary = new BinaryFormatter();
                saveObject = new SaveObject();
                saveObject.InitObject(story.transform.GetChild(a).gameObject);
                var json1 = JsonUtility.ToJson(saveObject);
                binary.Serialize(file, json1);
                file.Close();
            }
            else if (!story.transform.GetChild(a).GetComponent<Interactable>())
            {
                if (story.transform.GetChild(a).gameObject.name.CompareTo("Arc-1") == 0)
                {

                    //
                    for (int j = 0; j < story.transform.GetChild(a).childCount; j++)
                    {
                        FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
                        i++;
                        BinaryFormatter binary = new BinaryFormatter();
                        saveObject = new SaveObject();
                        saveObject.InitObject(story.transform.GetChild(a).GetChild(j).gameObject);
                        var json2 = JsonUtility.ToJson(saveObject);
                        binary.Serialize(file, json2);
                        file.Close();
                    }
                }
                else if (story.transform.GetChild(a).gameObject.name.CompareTo("Arc-2") == 0)
                {

                    //
                    for (int k = 0; k < story.transform.GetChild(a).childCount; k++)
                    {
                        FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
                        i++;
                        BinaryFormatter binary = new BinaryFormatter();
                        saveObject = new SaveObject();
                        saveObject.InitObject(story.transform.GetChild(a).GetChild(k).gameObject);
                        var json3 = JsonUtility.ToJson(saveObject);
                        binary.Serialize(file, json3);
                        file.Close();
                    }
                }
                else if (story.transform.GetChild(a).gameObject.name.CompareTo("Arc-3") == 0)
                {

                    //
                    for (int l = 0; l < story.transform.GetChild(a).childCount; l++)
                    {
                        FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
                        i++;
                        BinaryFormatter binary = new BinaryFormatter();
                        saveObject = new SaveObject();
                        saveObject.InitObject(story.transform.GetChild(a).GetChild(l).gameObject);
                        var json4 = JsonUtility.ToJson(saveObject);
                        binary.Serialize(file, json4);
                        file.Close();
                    }
                }
                else if (story.transform.GetChild(a).gameObject.name.CompareTo("Arc-4") == 0)
                {

                    //
                    for (int m = 0; m < story.transform.GetChild(a).childCount; m++)
                    {
                        FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
                        i++;
                        BinaryFormatter binary = new BinaryFormatter();
                        saveObject = new SaveObject();
                        saveObject.InitObject(story.transform.GetChild(a).GetChild(m).gameObject);
                        var json5 = JsonUtility.ToJson(saveObject);
                        binary.Serialize(file, json5);
                        file.Close();
                    }
                }
            }
        }
    }

    public void LoadGame()
    {
        int i = 0;
        //
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
        //
        for (int a = 0; a < story.transform.childCount; a++)
        {
            if (story.transform.GetChild(a).GetComponent<Interactable>())
            {
                if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
                {
                    FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                    BinaryFormatter binary = new BinaryFormatter();
                    saveObject = new SaveObject();
                    JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), saveObject);
                    Vector3 v = new Vector3(saveObject.position[0], saveObject.position[1], saveObject.position[2]);
                    story.transform.GetChild(a).gameObject.GetComponent<Interactable>().transform.position = v;
                    story.transform.GetChild(a).gameObject.GetComponent<Interactable>().ClueOff = ClueOff;
                    story.transform.GetChild(a).gameObject.GetComponent<Interactable>().dialogManager = dialogManager;

                    Interaction defaultInterTemp = story.transform.GetChild(a).gameObject.GetComponent<InteractionContainer>().InitDeserializeDefault(saveObject.interactionContainerData);
                    if (defaultInterTemp is AskInteraction)
                    {
                        AskInteraction temp = (AskInteraction)defaultInterTemp;
                        temp.pauseManager = pauseManager;
                        defaultInterTemp = temp;
                    }

                    List<Interaction> interactionsTemp = story.transform.GetChild(a).gameObject.GetComponent<InteractionContainer>().InitDeserialize(saveObject.interactionContainerData);
                    for (int z = 0; z < interactionsTemp.Count; z++)
                    {
                        if (interactionsTemp[i] is AskInteraction)
                        {
                            AskInteraction temp = (AskInteraction)interactionsTemp[i];
                            temp.pauseManager = pauseManager;
                            interactionsTemp[i] = temp;
                        }
                    }

                    story.transform.GetChild(a).gameObject.GetComponent<InteractionContainer>().interactions
                    = interactionsTemp;

                    story.transform.GetChild(a).gameObject.GetComponent<InteractionContainer>().defaultInteraction
                    = defaultInterTemp;
                    i++;
                    file.Close();
                }
            }
            else if (!story.transform.GetChild(a).GetComponent<Interactable>())
            {
                if (story.transform.GetChild(a).gameObject.name.CompareTo("Arc-1") == 0)
                {
                    for (int j = 0; j < story.transform.GetChild(a).childCount; j++)
                    {
                        if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
                        {
                            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                            BinaryFormatter binary = new BinaryFormatter();
                            saveObject = new SaveObject();
                            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), saveObject);
                            Vector3 v = new Vector3(saveObject.position[0], saveObject.position[1], saveObject.position[2]);
                            story.transform.GetChild(a).GetChild(j).gameObject.GetComponent<Interactable>().transform.position = v;
                            story.transform.GetChild(a).GetChild(j).gameObject.GetComponent<Interactable>().ClueOff = ClueOff;
                            story.transform.GetChild(a).GetChild(j).gameObject.GetComponent<Interactable>().dialogManager = dialogManager;

                            Interaction defaultInterTemp = story.transform.GetChild(a).GetChild(j).gameObject.GetComponent<InteractionContainer>().InitDeserializeDefault(saveObject.interactionContainerData);
                            if (defaultInterTemp is AskInteraction)
                            {
                                AskInteraction temp = (AskInteraction)defaultInterTemp;
                                temp.pauseManager = pauseManager;
                                defaultInterTemp = temp;
                            }

                            List<Interaction> interactionsTemp = story.transform.GetChild(a).GetChild(j).gameObject.GetComponent<InteractionContainer>().InitDeserialize(saveObject.interactionContainerData);
                            for (int z = 0; z < interactionsTemp.Count; z++)
                            {
                                if (interactionsTemp[i] is AskInteraction)
                                {
                                    AskInteraction temp = (AskInteraction)interactionsTemp[i];
                                    temp.pauseManager = pauseManager;
                                    interactionsTemp[i] = temp;
                                }
                            }

                            story.transform.GetChild(a).GetChild(j).gameObject.GetComponent<InteractionContainer>().interactions
                            = interactionsTemp;

                            story.transform.GetChild(a).GetChild(j).gameObject.GetComponent<InteractionContainer>().defaultInteraction
                            = defaultInterTemp;

                            i++;
                            file.Close();
                        }
                    }
                }
                else if (story.transform.GetChild(a).gameObject.name.CompareTo("Arc-2") == 0)
                {
                    //
                    for (int k = 0; k < story.transform.GetChild(a).childCount; k++)
                    {
                        if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
                        {
                            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                            BinaryFormatter binary = new BinaryFormatter();
                            saveObject = new SaveObject();
                            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), saveObject);
                            Vector3 v = new Vector3(saveObject.position[0], saveObject.position[1], saveObject.position[2]);
                            story.transform.GetChild(a).GetChild(k).gameObject.GetComponent<Interactable>().transform.position = v;
                            story.transform.GetChild(a).GetChild(k).gameObject.GetComponent<Interactable>().ClueOff = ClueOff;
                            story.transform.GetChild(a).GetChild(k).gameObject.GetComponent<Interactable>().dialogManager = dialogManager;

                            Interaction defaultInterTemp = story.transform.GetChild(a).GetChild(k).gameObject.GetComponent<InteractionContainer>().InitDeserializeDefault(saveObject.interactionContainerData);
                            if (defaultInterTemp is AskInteraction)
                            {
                                AskInteraction temp = (AskInteraction)defaultInterTemp;
                                temp.pauseManager = pauseManager;
                                defaultInterTemp = temp;
                            }

                            List<Interaction> interactionsTemp = story.transform.GetChild(a).GetChild(k).gameObject.GetComponent<InteractionContainer>().InitDeserialize(saveObject.interactionContainerData);
                            for (int z = 0; z < interactionsTemp.Count; z++)
                            {
                                if (interactionsTemp[i] is AskInteraction)
                                {
                                    AskInteraction temp = (AskInteraction)interactionsTemp[i];
                                    temp.pauseManager = pauseManager;
                                    interactionsTemp[i] = temp;
                                }
                            }

                            story.transform.GetChild(a).GetChild(k).gameObject.GetComponent<InteractionContainer>().interactions
                            = interactionsTemp;

                            story.transform.GetChild(a).GetChild(k).gameObject.GetComponent<InteractionContainer>().defaultInteraction
                            = defaultInterTemp;
                            i++;
                            file.Close();
                        }
                    }
                }
                else if (story.transform.GetChild(a).gameObject.name.CompareTo("Arc-3") == 0)
                {
                    //
                    for (int l = 0; l < story.transform.GetChild(a).childCount; l++)
                    {
                        if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
                        {
                            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                            BinaryFormatter binary = new BinaryFormatter();
                            saveObject = new SaveObject();
                            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), saveObject);
                            Vector3 v = new Vector3(saveObject.position[0], saveObject.position[1], saveObject.position[2]);
                            story.transform.GetChild(a).GetChild(l).gameObject.GetComponent<Interactable>().transform.position = v;
                            story.transform.GetChild(a).GetChild(l).gameObject.GetComponent<Interactable>().ClueOff = ClueOff;
                            story.transform.GetChild(a).GetChild(l).gameObject.GetComponent<Interactable>().dialogManager = dialogManager;

                            Interaction defaultInterTemp = story.transform.GetChild(a).GetChild(l).gameObject.GetComponent<InteractionContainer>().InitDeserializeDefault(saveObject.interactionContainerData);
                            if (defaultInterTemp is AskInteraction)
                            {
                                AskInteraction temp = (AskInteraction)defaultInterTemp;
                                temp.pauseManager = pauseManager;
                                defaultInterTemp = temp;
                            }

                            List<Interaction> interactionsTemp = story.transform.GetChild(a).GetChild(l).gameObject.GetComponent<InteractionContainer>().InitDeserialize(saveObject.interactionContainerData);
                            for (int z = 0; z < interactionsTemp.Count; z++)
                            {
                                if (interactionsTemp[i] is AskInteraction)
                                {
                                    AskInteraction temp = (AskInteraction)interactionsTemp[i];
                                    temp.pauseManager = pauseManager;
                                    interactionsTemp[i] = temp;
                                }
                            }

                            story.transform.GetChild(a).GetChild(l).gameObject.GetComponent<InteractionContainer>().interactions
                            = interactionsTemp;

                            story.transform.GetChild(a).GetChild(l).gameObject.GetComponent<InteractionContainer>().defaultInteraction
                            = defaultInterTemp;
                            i++;
                            file.Close();
                        }
                    }
                }
                else if (story.transform.GetChild(a).gameObject.name.CompareTo("Arc-4") == 0)
                {
                    //
                    for (int m = 0; m < story.transform.GetChild(a).childCount; m++)
                    {
                        if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
                        {
                            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                            BinaryFormatter binary = new BinaryFormatter();
                            saveObject = new SaveObject();
                            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), saveObject);
                            Vector3 v = new Vector3(saveObject.position[0], saveObject.position[1], saveObject.position[2]);
                            story.transform.GetChild(a).GetChild(m).gameObject.GetComponent<Interactable>().transform.position = v;
                            story.transform.GetChild(a).GetChild(m).gameObject.GetComponent<Interactable>().ClueOff = ClueOff;
                            story.transform.GetChild(a).GetChild(m).gameObject.GetComponent<Interactable>().dialogManager = dialogManager;

                            Interaction defaultInterTemp = story.transform.GetChild(a).GetChild(m).gameObject.GetComponent<InteractionContainer>().InitDeserializeDefault(saveObject.interactionContainerData);
                            if (defaultInterTemp is AskInteraction)
                            {
                                AskInteraction temp = (AskInteraction)defaultInterTemp;
                                temp.pauseManager = pauseManager;
                                defaultInterTemp = temp;
                            }

                            List<Interaction> interactionsTemp = story.transform.GetChild(a).GetChild(m).gameObject.GetComponent<InteractionContainer>().InitDeserialize(saveObject.interactionContainerData);
                            for (int z = 0; z < interactionsTemp.Count; z++)
                            {
                                if (interactionsTemp[i] is AskInteraction)
                                {
                                    AskInteraction temp = (AskInteraction)interactionsTemp[i];
                                    temp.pauseManager = pauseManager;
                                    interactionsTemp[i] = temp;
                                }
                            }

                            story.transform.GetChild(a).GetChild(m).gameObject.GetComponent<InteractionContainer>().interactions
                            = interactionsTemp;

                            story.transform.GetChild(a).GetChild(m).gameObject.GetComponent<InteractionContainer>().defaultInteraction
                            = defaultInterTemp;
                            i++;
                            file.Close();
                        }
                    }
                }
            }
        }
    }

    public void ResetGame()
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
        {
            File.Delete(Application.persistentDataPath + string.Format("/{0}.dat", i));
            i++;
        }
    }
}
