using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditUI;
    public GameObject menuButtons;

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
    }

    public void CloseCredits()
    {
        Debug.Log("Credits button pressed");
        creditUI.SetActive(false);
        menuButtons.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
