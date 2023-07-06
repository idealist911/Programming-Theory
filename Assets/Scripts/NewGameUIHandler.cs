using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NewGameUIHandler : MonoBehaviour
{
    Button createGameButton;
    GameObject errorText;
    TMP_InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        nameInputField = GameObject.Find("NameInputField").GetComponent<TMP_InputField>();
        nameInputField.onEndEdit.AddListener(LockInput);
        createGameButton = GameObject.Find("CreateGameButton").GetComponent<Button>();
        createGameButton.onClick.AddListener(StartNew);
        errorText = GameObject.Find("ErrorText");
        errorText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartNew()
    {
        if (GameManager.instance.playername == "")
        {
            string errorMsg = "Required field: player name";
            SetErrorMessage(errorMsg);
        }
        else if (GameManager.instance.playername.Length > 12)
        {
            string errorMsg = "Name value is too long";
            SetErrorMessage(errorMsg);
        }
        else
        {
            GameManager.instance.SavePlayerDetails();
            SceneManager.LoadScene(GameManager.scenes["Main"]);
        }
    }

    void LockInput(string input)
    {
        GameManager.instance.playername = input;
        GameManager.instance.health = 100;
    }

    void SetErrorMessage(string msg)
    {
        errorText.SetActive(true);
        errorText.GetComponent<TMP_Text>().text = msg;
    }
}
