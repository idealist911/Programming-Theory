using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    Dictionary<string, int> scenes = new Dictionary<string, int>()
    {
        { "Title", 0 },
        { "Main", 1 },
        { "NewGame", 2 }
    };

    Button newGameButton;
    Button playGameButton;
    Button quitGameButton;

    // Start is called before the first frame update
    void Start()
    {
        newGameButton = GameObject.Find("NewGameButton").GetComponent<Button>();
        newGameButton.onClick.AddListener(CreateNewGame);
        playGameButton = GameObject.Find("PlayGameButton").GetComponent<Button>();
        playGameButton.onClick.AddListener(PlayGame);
        quitGameButton = GameObject.Find("QuitButton").GetComponent<Button>();
        quitGameButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateNewGame()
    {
        SceneManager.LoadScene(scenes["NewGame"]);
    }

    void PlayGame()
    {
        SceneManager.LoadScene(scenes["Main"]);
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
