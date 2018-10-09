using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    [SerializeField] int totalPoints = 0;
    [SerializeField] int targetPoints = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text targetText;
    [SerializeField] int level = 1;
    bool playerReverseDirection = false;
    bool playerSpeedUp = false;

    public void Start()
    {
        DisplayScore();
        PlayerPrefs.SetInt("Level", level);
    }

    public void addToScore(int points)
    {
        totalPoints += points;
        if (totalPoints <= 0)
        {
            SceneManager.LoadScene("Lose Scene");
        } 
        else if (totalPoints >= targetPoints)
        {
            SceneManager.LoadScene("Win Scene");
        }
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = "Score: \n" + totalPoints.ToString();
        targetText.text = "Target: \n" + targetPoints.ToString();
    }

    public void ReverseDirection()
    {
        if (playerReverseDirection)
        {
            playerReverseDirection = false;
        } 
        else
        {
            playerReverseDirection = true;
        }
    }

    public bool PlayerReverseDirection()
    {
        return playerReverseDirection;
    }

    public void SpeedUp()
    {
        playerSpeedUp = playerSpeedUp == true ? false : true;
    }

    public bool PlayerSpeedUp()
    {
        return playerSpeedUp;
    }
}
