using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 32f;
    [SerializeField] float screenHeightInUnits = 20f;
    [SerializeField] float speed = 10f;

    private Rigidbody2D rb;
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = (movement * speed);
    }

    private void Update()
    {
        var dir = new Vector2 (Input.acceleration.x, Input.acceleration.y);
        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
    }
}
