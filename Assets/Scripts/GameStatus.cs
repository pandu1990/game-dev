﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    [SerializeField] int totalPoints = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text WinLoseText;
    [SerializeField] int level = 1;

    public void Start()
    {
        WinLoseText.text = "";
        DisplayScore();
        PlayerPrefs.SetInt("Level", level);
    }

    public void addToScore(int points)
    {
        totalPoints += points;
        if (totalPoints < 0)
        {
            WinLoseText.text = "You Lose!";
            WinLoseText.color = Color.red;
            SceneManager.LoadScene("Lose Scene");
        } 
        else if (totalPoints > 100)
        {
            WinLoseText.text = "You Win!";
            SceneManager.LoadScene("Win Scene");
        }
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = totalPoints.ToString();
    }
}