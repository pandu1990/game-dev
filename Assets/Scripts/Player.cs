using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float speed = 10f;
    GameStatus gameStatus;

    private Rigidbody2D rb2d;
    private Vector2 startXY;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        gameStatus = FindObjectOfType<GameStatus>();
        startXY = new Vector2(Input.acceleration.x, Input.acceleration.y);
    }
	
    void FixedUpdate () {
        int direction = gameStatus.PlayerReverseDirection()? -1: 1;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //movement *= Time.deltaTime;
        rb2d.velocity = (movement * speed * direction);
    }

    private void Update()
    {
        int direction = gameStatus.PlayerReverseDirection() ? -1 : 1;
        var movement = new Vector2 (Input.acceleration.x, Input.acceleration.y) - startXY;
        if (movement.sqrMagnitude > 1)
        {
            movement.Normalize();
        }
        movement *= Time.deltaTime;
        transform.Translate(movement * speed * direction);
    }
}
