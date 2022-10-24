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

    void Start()
    {
        creditUI.SetActive(false);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("SampleScene");
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
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
