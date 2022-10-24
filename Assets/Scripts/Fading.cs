using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    [SerializeField] private CanvasGroup UIPhone;
    [SerializeField] private CanvasGroup UIPlayButton;

    public float timerValue = 1;

    void Start()
    {

    }

    void Update()
    {
        if (timerValue > 0)
        {
            timerValue -= Time.deltaTime;
        }
        else 
        {
            timerValue = 0;
        }
        
        if (timerValue == 0)
        {
            UIPhone.alpha += Time.deltaTime;
            UIPlayButton.alpha += Time.deltaTime;
        }
    }
    
}
