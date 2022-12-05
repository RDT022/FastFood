using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneUI : MonoBehaviour
{
    public GameObject phoneUI;
    public GameObject minimap;
    public GameObject buttons;
    public GameObject controlButtons;
    public GameObject controlImageKB;
    public GameObject controlImageCon;
    public GameObject minimapCamera;
    public GameObject defaultButton;
    public GameObject controlsButton;
    public GameObject optionsScreen;
    public GameObject gasMeter;

    public GameObject defaultControlsButton;
    public GameObject exitKBButton;
    public GameObject exitConButton;

    public static bool isPaused = false;

    [SerializeField]
    private AudioSource audioSource;

    public AudioClip[] musicTracks;

    private int counter = 0;


    void Start()
    {
        minimap.SetActive(true);
        controlImageKB.SetActive(false);
        controlImageCon.SetActive(false);
        buttons.SetActive(false);
        controlButtons.SetActive(false);
        optionsScreen.SetActive(false);
        audioSource.clip = musicTracks[counter];
        audioSource.Play();
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
        minimap.SetActive(true);
        buttons.SetActive(false);
        controlButtons.SetActive(false);
        controlImageKB.SetActive(false);
        controlImageCon.SetActive(false);
        gasMeter.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;        
        minimap.SetActive(false);
        buttons.SetActive(true);
        gasMeter.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

    public void Controls()
    {
        buttons.SetActive(false);
        controlButtons.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultControlsButton);
    }

    public void OpenKeyboardControls()
    {
        buttons.SetActive(false);
        controlButtons.SetActive(false);
        controlImageKB.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitKBButton);
    }
    
    public void OpenControllerControls()
    {
        buttons.SetActive(false);
        controlButtons.SetActive(false);
        controlImageCon.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitConButton);
    }

    public void CloseControls()
    {
        buttons.SetActive(true);
        controlButtons.SetActive(false);
        controlImageKB.SetActive(false);
        controlImageCon.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

    public void OpenUI()
    {
        if (phoneUI != null)
        {
            Animator animator = phoneUI.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
    }

    public void Options()
    {
        buttons.SetActive(false);
        optionsScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsScreen);
    }

    public void CloseOptions()
    {
        buttons.SetActive(true);
        optionsScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

    public void ChangeBGM()
    {
        if (counter != musicTracks.Length - 1)
        {
            counter++;
            audioSource.Stop();
            audioSource.clip = musicTracks[counter];
            audioSource.Play();
        }
        else
        {
            counter = 0;
            audioSource.Stop();
            audioSource.clip = musicTracks[counter];
            audioSource.Play();
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
