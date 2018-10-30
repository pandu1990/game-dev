using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour {

    [SerializeField] TextMeshProUGUI tmproText;
    [SerializeField] public int points = 0;
    bool picked = false;

    GameStatus gameStatus;

	// Use this for initialization
	void Start () {
        gameStatus = FindObjectOfType<GameStatus>();
        tmproText.text = points.ToString();
	}

    public void OnTriggerEnter2D(Collider2D collision) { 
        if (!picked)
        {
            gameStatus.addToScore(points);
            Destroy(gameObject);
            picked = true;
        }
    }

}