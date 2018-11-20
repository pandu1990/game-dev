using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    int totalPoints = 0;
    int targetPoints = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text targetText;
    //[SerializeField] int level = 1;
    bool playerReverseDirection = false;
    bool playerSpeedUp = false;
    bool playerDisappear = false;
    [SerializeField] GenerateMaps generateMaps;

    public void Start()
    {
        DisplayScore();
        //PlayerPrefs.SetInt("Level", level);

        //int level = PlayerPrefs.GetInt("Level", 1);
        //totalPoints = generateMaps.paramDict[level].initialScores;
        //targetPoints= generateMaps.paramDict[level].totalScores;

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
        list.Add(new Vector2Int(10, 4));
        list.Add(new Vector2Int(9, 4));
        list.Add(new Vector2Int(8, 4));
        generateMaps.removeBlocks(list);
    }

    public void SetTargetScore(int score) {
        targetPoints = score;
        DisplayScore();
    }

    public void SetTotalPoints(int total) {
        totalPoints = total;
        DisplayScore();
    }
}
