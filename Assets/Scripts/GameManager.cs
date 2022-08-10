using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public static GameManager Instance;
    public  string inputName;
    public int highScore;
   


    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
      
        Instance = this;
        DontDestroyOnLoad(gameObject);
       
    }

 
 

   

}
