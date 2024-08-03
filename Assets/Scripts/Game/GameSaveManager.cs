using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager gameSave;
    public List<ScriptableObject> scriptableObjects = new List<ScriptableObject>();

    private void Awake() {
        if (gameSave == null) {
            gameSave = this;
        }
        else {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
