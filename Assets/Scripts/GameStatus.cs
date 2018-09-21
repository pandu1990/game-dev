using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    [SerializeField] int totalPoints = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text WinLoseText;

    public void Start()
    {
        WinLoseText.text = "";
        DisplayScore();
    }

    public void addToScore(int points)
    {
        totalPoints += points;
        if (totalPoints < 0)
        {
            WinLoseText.text = "You Lose!";
            WinLoseText.color = Color.red;
        } else if (totalPoints > 100)
        {
            WinLoseText.text = "You Win!";
        }
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = totalPoints.ToString();
    }
}
