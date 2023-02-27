using System;
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

    private Vector3 lastHeadPosition;

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
        if (horizontalInput > 0 && moveDirection != Vector2.left)
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
        if (moveDirection == Vector2.zero)
            return;
        MoveHead();
        MoveBody();

    }

    private void MoveHead()
    {
        Vector3 playerPosition = transform.position;
        lastHeadPosition = playerPosition;
        playerPosition.x += moveDirection.x;
        playerPosition.y += moveDirection.y;
        transform.position = playerPosition;
        Debug.Log("Last Position: "+ lastHeadPosition + " Current Head Position: "+transform.position);
    }

    private void MoveBody()
    {
        if (snakeSegments.Count == 1)
            return;

        Debug.Log("Move Body");
        Vector3 lastSegmentPostion = lastHeadPosition;
        for(int i = 1;i<snakeSegments.Count;i++)
        {
            Vector3 currentSegmentPostion = snakeSegments[i].position;
            snakeSegments[i].position = lastSegmentPostion;
            lastSegmentPostion = currentSegmentPostion;
        }
    }

    public void Grow()
    {
        Transform segment = Instantiate(snakeSegmentPrefab, lastHeadPosition, snakeSegments[^1].rotation,transform.parent);
        snakeSegments.Insert(1, segment);
    }


    public void GameOver()
    {
        Debug.Log("Dead");

        CancelInvoke(nameof(PlayerMovement));
        this.enabled = false;
    }


}
