using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    [SerializeField] private CanvasGroup UIPhone;
    [SerializeField] private CanvasGroup UIPlayButton;
    [SerializeField] private CanvasGroup TitleOval;
    [SerializeField] private CanvasGroup TitleWords;

    public float timerValue1 = 1;
    public float timerValue2 = 2;

    void Start()
    {

    }

    void Update()
    {
        if (timerValue1 > 0)
        {
            timerValue1 -= Time.deltaTime;
        }
        else 
        {
            timerValue1 = 0;
        }
        
        if (timerValue1 == 0)
        {
            UIPhone.alpha += Time.deltaTime;
            UIPlayButton.alpha += Time.deltaTime;
        }        
        
        if (timerValue2 > 0)
        {
            timerValue2 -= Time.deltaTime;
        }
        else 
        {
            timerValue2 = 0;
        }
        
        if (timerValue2 == 0)
        {
            TitleOval.alpha += Time.deltaTime;
            TitleWords.alpha += Time.deltaTime;
        }
    }
    
}
