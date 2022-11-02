using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneUI : MonoBehaviour
{
    public GameObject PhoneUI;
    public GameObject Minimap;
    public GameObject Buttons;
    public GameObject ControlImage;

    public static bool isPaused = false;

    void Start()
    {
        Minimap.SetActive(true);
        ControlImage.SetActive(false);
        Buttons.SetActive(false);
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenUI();
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Minimap.SetActive(true);
        Buttons.SetActive(false);
        ControlImage.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;        
        Minimap.SetActive(false);
        Buttons.SetActive(true);
    }

    public void OpenControls()
    {
        Buttons.SetActive(false);
        ControlImage.SetActive(true);
    }

    public void CloseControls()
    {
        Buttons.SetActive(true);
        ControlImage.SetActive(false);        
    }

    public void OpenUI()
    {
        if (PhoneUI != null)
        {
            Animator animator = PhoneUI.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene("Main_Menu");                
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();   

    }
}
