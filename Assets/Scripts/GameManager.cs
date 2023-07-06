using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; } /* for persistence */ // ENCAPSULATION
    public static Dictionary<string, int> scenes = new Dictionary<string, int>()
    {
        { "Menu", 0 },
        { "Main", 1 },
        { "NewGame", 2 },
        { "Safari", 3 }
    };
    public string playername;
    public float health;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); /* destroy if scene already has an instance */
            return;              /* so only one instance exists */
        }
        instance = this;
        DontDestroyOnLoad(gameObject); /* keep it when switching scenes */

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string playername;
        public float health;
    }

    // ENCAPSULATION: since instance is restricted to private set, we can only change its variables by calling a function
    public void SetPlayerHealth(float value)
    {
        GameManager.instance.health = value;
    }

    public void SavePlayerDetails()
    {
        SaveData data = new SaveData();
        data.playername = GameManager.instance.playername;
        data.health = GameManager.instance.health;
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/" + "savefile.json";
        File.WriteAllText(path, json);
    }

    public void LoadPlayerDetails()
    {
        string path = Application.persistentDataPath + "/" + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            GameManager.instance.playername = data.playername;
            GameManager.instance.health = data.health;
        }
        else /* player is new */
        {
            SceneManager.LoadScene(GameManager.scenes["NewGame"]);
        }
    }

    
}
