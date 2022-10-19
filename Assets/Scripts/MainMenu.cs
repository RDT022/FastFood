using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsGame()
    {
        Debug.Log("Credits button pressed");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
