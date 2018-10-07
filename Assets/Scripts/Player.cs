using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float speed = 10f;
    GameStatus gameStatus;

    private Rigidbody2D rb2d;
    
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        gameStatus = FindObjectOfType<GameStatus>();
    }
	
    void FixedUpdate () {
        int direction = gameStatus.PlayerReverseDirection()? -1: 1;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = (movement * speed * direction);
    }

    private void Update()
    {
        int direction = gameStatus.PlayerReverseDirection() ? -1 : 1;
        var dir = new Vector2 (Input.acceleration.x, Input.acceleration.y);
        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        dir *= Time.deltaTime;
        transform.Translate(dir * speed * direction);
    }
}
