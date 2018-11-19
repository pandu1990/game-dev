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
    bool playerDisappear = false;
    [SerializeField] GenerateMaps generateMaps;

    public void Start()
    {
        DisplayScore();
        //PlayerPrefs.SetInt("Level", level);

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

    /// <summary>
    /// Reverses the direction.
    /// </summary>

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

    /// <summary>
    /// Speeds up.
    /// </summary>

    public void SpeedUp()
    {
        playerSpeedUp = playerSpeedUp == true ? false : true;
    }

    public bool PlayerSpeedUp()
    {
        return playerSpeedUp;
    }

    public void DisapperBlocks(){
        List<Vector2Int> list = new List<Vector2Int>();
        list.Add(new Vector2Int(6, 8));
        generateMaps.removeBlocks(list);
    }
}
