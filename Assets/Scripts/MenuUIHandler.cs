using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
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
        SceneManager.LoadScene(GameManager.scenes["NewGame"]);
    }

    void PlayGame()
    {
        SceneManager.LoadScene(GameManager.scenes["Main"]);
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
