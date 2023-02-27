using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private float bufferMovementTime;
    private Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        Time.fixedDeltaTime = bufferMovementTime;
    }
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if(horizontalInput > 0)
        {
            moveDirection = Vector2.right;
        }
        if (horizontalInput < 0)
        {
            moveDirection = Vector2.left;
        }
        if(verticalInput > 0)
        {
            moveDirection = Vector2.up;
        }
        if(verticalInput<0)
        {
            moveDirection = Vector2.down;
        }
        Vector3 playerPosition = transform.position;
        playerPosition.x += moveDirection.x;
        playerPosition.y += moveDirection.y;
        transform.position = playerPosition;
        moveDirection = Vector2.zero;
    }
}
