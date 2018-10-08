using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mystery : MonoBehaviour {

    bool picked = false;

    GameStatus gameStatus;

    public void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!picked)
        {
            gameStatus.ReverseDirection();
            Destroy(gameObject);
            picked = true;
        }
    }
}
