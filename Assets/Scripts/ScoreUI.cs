using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    static int score;

    static int highScore;

    public PlayerDelivery player;

    public TextMeshProUGUI ScoreText;

    public TextMeshProUGUI HighScoreText;

    public TextMeshProUGUI TimerText;

    //star rating ui//
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject Star4;
    public GameObject Star5;

    void Start()
    {
        //star rating
        Star1.SetActive(true);
        Star2.SetActive(true);
        Star3.SetActive(true);
        Star4.SetActive(true);
        Star5.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            score = player.Score;
            TimerText.SetText($"Timer: {(int)player.deliveryTimer}");
        }
        if(score > highScore)
        {
            highScore = score;
        }
        ScoreText.SetText($"Score: {score}");
        HighScoreText.SetText($"{highScore}");

        //yeah it's more than it needs to be but this way works too//
        if (player.Lives == 5)
        {
            Star5.SetActive(true);
        }
        if (player.Lives == 4)
        {
            Star4.SetActive(true);
            Star5.SetActive(false);
        }        
        if (player.Lives == 3)
        {
            Star3.SetActive(true);
            Star4.SetActive(false);
        }
        if (player.Lives == 2)
        {            
            Star2.SetActive(true);
            Star3.SetActive(false);
        }
        if (player.Lives == 1)
        {
            Star1.SetActive(true);
            Star2.SetActive(false);
        }
    }


}
