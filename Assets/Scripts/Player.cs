using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float speed = 10f;
    GameStatus gameStatus;

    private Rigidbody2D rb2d;
    private Vector2 startXY;
    private Quaternion calibrationQuaternion;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.drag = 2;
        gameStatus = FindObjectOfType<GameStatus>();
        // startXY = new Vector2(Input.acceleration.x, Input.acceleration.y);
        CalibrateAccelerometer();
    }

    void CalibrateAccelerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }
	
    void FixedUpdate () {
        int direction = gameStatus.PlayerReverseDirection()? -1: 1;
        int accelerate = gameStatus.PlayerSpeedUp() ? 2 : 1;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (movement.sqrMagnitude > 1)
        {
            movement.Normalize();
        }
        movement *= Time.deltaTime;
        rb2d.AddForce(movement * speed * direction * accelerate);
    }

    private void Update()
    {
        int direction = gameStatus.PlayerReverseDirection() ? -1 : 1;
        int accelerate = gameStatus.PlayerSpeedUp() ? 2 : 1;

        /* var movement = new Vector2 (Input.acceleration.x, Input.acceleration.y) - startXY;
        if (movement.sqrMagnitude > 1)
        {
            movement.Normalize();
        }*/
        Vector3 currentAcceleration = Input.acceleration;
        Vector3 fixedAcceleration = calibrationQuaternion * currentAcceleration;
        var movement = new Vector2(fixedAcceleration.x, fixedAcceleration.y);

        movement *= Time.deltaTime;
        rb2d.AddForce(movement * speed * direction * accelerate);
    }
}
