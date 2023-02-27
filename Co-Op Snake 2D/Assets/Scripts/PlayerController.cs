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

    private List<Transform> snakeSegments;

    [SerializeField]
    private Transform snakeSegmentPrefab;
    private void Awake()
    {
        snakeSegments = new List<Transform>();
        snakeSegments.Add(gameObject.transform);

    }
    private void Start()
    {
        InvokeRepeating(nameof(PlayerMovement), bufferMovementTime, bufferMovementTime);
        
    }
    

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput > 0 && moveDirection!=Vector2.left)
        {
            moveDirection = Vector2.right;
        }
        if (horizontalInput < 0 && moveDirection != Vector2.right)
        {
            moveDirection = Vector2.left;
        }
        if (verticalInput > 0 && moveDirection != Vector2.down)
        {
            moveDirection = Vector2.up;
        }
        if (verticalInput < 0 && moveDirection != Vector2.up)
        {
            moveDirection = Vector2.down;
        }
        MoveBody();
        MoveHead();

    }

    private void MoveHead()
    {
        Vector3 playerPosition = transform.position;
        playerPosition.x += moveDirection.x;
        playerPosition.y += moveDirection.y;
        transform.position = playerPosition;
    }

    private void MoveBody()
    {
        if (moveDirection != Vector2.zero)
        {
            for (int i = snakeSegments.Count - 1; i > 0; i--)
            {
                snakeSegments[i].position = snakeSegments[i - 1].position;
            }
        }
    }

    public void Grow()
    {
        Transform segment = Instantiate(snakeSegmentPrefab);
        segment.parent = transform.parent;
        segment.position = snakeSegments[^1].position;
        snakeSegments.Add(segment);
    }
}
