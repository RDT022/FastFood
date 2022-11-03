using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    static int score;

    public PlayerDelivery player;

    public TextMeshProUGUI ScoreText;

    public TextMeshProUGUI TimerText;

    public TextMeshProUGUI StarText;


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            score = player.Score;
            TimerText.SetText($"Timer: {(int)player.deliveryTimer}");
            StarText.SetText($"Star Rating: {player.Lives}");
        }
        ScoreText.SetText($"Score: {score}");
    }
}
