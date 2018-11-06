using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mystery : MonoBehaviour {

    bool picked = false;

    GameStatus gameStatus;


    public enum MYSTERYDIRECTION{ 
        ReverseDirection,
        SpeedUp
    };

    public MYSTERYDIRECTION mysteryType;

    public void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!picked)
        {
            if(mysteryType == MYSTERYDIRECTION.ReverseDirection)
            {
                gameStatus.ReverseDirection();
            }
            else if (mysteryType == MYSTERYDIRECTION.SpeedUp)
            {
                gameStatus.SpeedUp();
            }
            Destroy(gameObject);
            picked = true;
        }
    }
}
