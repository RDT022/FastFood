using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject creditUI;
    public GameObject menuButtons;
    
    public GameObject exitCreditsButton;
    public GameObject creditsButton;

    public GameObject ModeOptions;
    public GameObject ModeButton;

    public GameObject MainMenuObj;

    bool timerActive = false;
    float currentTime;
    public float startTimer;

    bool lvlButtonPressed = false;
    bool MLMButtonPressed = false;
    bool quitButtonPressed = false;    

    void Start()
    {
        creditUI.SetActive(false);
        currentTime = startTimer = 0.25f;
        ModeOptions.SetActive(false);
    }

    //here//
    void Update()
    {
        if (timerActive == true) 
        {
            currentTime = currentTime - Time.deltaTime;
            Debug.Log(currentTime);

            if (currentTime <= 0)
            {
                if (lvlButtonPressed == true)
                {
                    SceneManager.LoadScene("SampleScene");
                }                
                if (MLMButtonPressed == true)
                {
                    SceneManager.LoadScene("MLMScene");
                }
                if (quitButtonPressed == true)
                {
                    Debug.Log("Quitting Game");
                    Application.Quit();    
                }
            }
        }
    }

    public void LoadNormalLevel()
    {
        lvlButtonPressed = true; 
        StartTime(); 
    }

    public void LoadMLMLevel()
    {
        MLMButtonPressed = true; 
        StartTime(); 
    }

    public void OpenCredits()
    {
        Debug.Log("Credits button pressed");
        creditUI.SetActive(true);
        menuButtons.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitCreditsButton);
    }

    public void CloseCredits()
    {
        Debug.Log("Credits button pressed");
        creditUI.SetActive(false);
        menuButtons.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsButton);
    }

    public void QuitGame()
    {           
        quitButtonPressed = true;
        StartTime();        
    }
    
    public void StartTime()
    {
        timerActive = true;
    }

    public void EndTime()
    {
        timerActive = false;
    }

    public void ModeSelect()
    {
        MainMenuObj.SetActive(false);
        ModeOptions.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ModeButton);
    }
}
