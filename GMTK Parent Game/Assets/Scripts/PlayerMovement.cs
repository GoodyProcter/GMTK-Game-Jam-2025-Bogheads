using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeedMult = 1.5f;
    public float acceleration = 10f;
    public float deceleration = 8f;

    public float playerMoveX;
    public float playerMoveY;
    //public float currentSpeed;

    private Rigidbody2D rb;
    private Vector2 inputDirection;
    private Vector2 currentVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {        
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector2(directionX, directionY).normalized;

        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= sprintSpeedMult;
        }

        Vector2 targetVelocity = inputDirection * speed;
        float lerpSpeed;

        if (inputDirection.magnitude > 0)
        {
            lerpSpeed = acceleration;
        }
        else
        {
            lerpSpeed = deceleration;
        }

        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, lerpSpeed * Time.deltaTime);

        playerMoveX = currentVelocity.x;
        playerMoveY = currentVelocity.y;

    }

    private void FixedUpdate()
    {
        if (currentVelocity != Vector2.zero)
        {
            rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime);
        }
    }
}
