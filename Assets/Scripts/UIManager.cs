using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class UIManager : MonoBehaviour
{
    public GameObject playGame;
    public Button[] buttons;
    public GameObject gamerNameInput;
    public TMP_Text welcomeText;


    // Start is called before the first frame update
    void Start()
    {
      
        playGame.SetActive(false);
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

    public void TurnButtonsOff()
    {
        foreach (Button obj in buttons)
        {
            obj.GetComponent<Button>().gameObject.SetActive(false);
            gamerNameInput.SetActive(true);
        }
    }

    public void WelcomeUser()
    {
        
        welcomeText.enabled = true;
        welcomeText.text = "Welcome: " + GameManager.Instance.inputName;
        playGame.SetActive(true);
    }
}
