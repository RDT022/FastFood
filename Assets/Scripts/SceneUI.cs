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
    public GameObject minimapCamera;
    public GameObject defaultButton;
    public GameObject controlsButton;

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
        if (Input.GetButtonDown("Fire2"))
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
        minimapCamera.transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Minimap.SetActive(true);
        Buttons.SetActive(false);
        ControlImage.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;        
        Minimap.SetActive(false);
        Buttons.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

    public void OpenControls()
    {
        Buttons.SetActive(false);
        ControlImage.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlsButton);
    }

    public void CloseControls()
    {
        Buttons.SetActive(true);
        ControlImage.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultButton);
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
        Time.timeScale = 1;
        SceneManager.LoadScene("Main_Menu");                
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();   

    }
}
