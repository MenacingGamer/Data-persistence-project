using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class UIManager : MonoBehaviour
{
    public TMP_Text welcomeText;
    public TMP_Text highScoreText;
    public GameObject playGameButton;
    public GameObject backButton;
    public Button[] buttons;
    public GameObject gamerNameInput;
    public TMP_InputField gamerName;


    // Start is called before the first frame update
    void Start()
    {
      
        backButton.SetActive(false);
        highScoreText.enabled = false;
        playGameButton.SetActive(false);
        welcomeText.enabled = false;
        gamerNameInput.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();  
#endif
    }
    public void NewGame()
    {
        GameManager.Instance.inputName = gamerName.text;
        WelcomeUser();
        GameManager.Instance.highScore = 0;
    }

    public void NewUser()
    {
        GameManager.Instance.inputName = "";
        GameManager.Instance.highScore = 0;
        gamerNameInput.SetActive(true);
        TurnButtonsOff();
        backButton.SetActive(true);
        
        
    }

    public void BackButton()
    {
       
        gamerNameInput.SetActive(false);
        welcomeText.enabled = false;
        highScoreText.enabled = false;
        playGameButton.SetActive(false);
        backButton.SetActive(false);
        TurnButtonsOn();
    }

    public void TurnButtonsOff()
    {
        foreach (Button obj in buttons)
        {
            obj.GetComponent<Button>().gameObject.SetActive(false);
            
        }
    }

    public void TurnButtonsOn()
    {
        foreach (Button obj in buttons)
        {
            obj.GetComponent<Button>().gameObject.SetActive(true);
           
        }
    }

    public void WelcomeUser()
    {
        
        welcomeText.enabled = true;
        welcomeText.text = "Welcome: " + GameManager.Instance.inputName;
        playGameButton.SetActive(true);
    }

    public void LoadUser()
    {
        TurnButtonsOff();
        var s = PlayerPrefs.GetInt("HighScore", GameManager.Instance.highScore);
        var n =  PlayerPrefs.GetString("PlayerName", GameManager.Instance.inputName);
        welcomeText.enabled = true;
        welcomeText.text = "Welcome: " + n;
        highScoreText.enabled = true;
        highScoreText.text = "High Score: " + s;
        playGameButton.SetActive(true);
        backButton.SetActive(true);
        GameManager.Instance.highScore = s;
        GameManager.Instance.inputName = n;
    }
}
