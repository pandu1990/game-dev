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
        this.gameObject.isStatic = true;
        gameStatus = FindObjectOfType<GameStatus>();
        tmproText.text = points.ToString();

        if(points>0){
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            tmproText.color = Color.black;
        }

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