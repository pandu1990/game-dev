using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour {

    [SerializeField] TextMeshProUGUI tmproText;
    [SerializeField] int points = 0;

    GameStatus gameStatus;

	// Use this for initialization
	void Start () {
        gameStatus = FindObjectOfType<GameStatus>();
        tmproText.text = points.ToString();
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        gameStatus.addToScore(points);
        Destroy(gameObject);
    }

}
