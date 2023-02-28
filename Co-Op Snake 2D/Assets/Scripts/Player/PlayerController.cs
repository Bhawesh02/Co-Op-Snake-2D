
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private float bufferMovementTime;
    private readonly float lowestMovementTime = 0.04f;
    private Vector2 moveDirection = Vector2.zero;

    public List<Transform> snakeSegments;

    [SerializeField]
    private Transform snakeSegmentPrefab;

    private Vector3 lastHeadPosition;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int currentScore = 0;

    [SerializeField]
    private int increaseScoreAmt = 5;

    [SerializeField]
    private float scoreUpdateTime;

    [SerializeField]
    private float shieldPowerupDuration = 3f;

    [SerializeField]
    private float ScoreBoostPowerupDuration = 7f;
    [SerializeField]
    private float SpeedBoostPowerupDuration = 5f;

    private bool shieldInUse = false;

    public int playerId;

    [SerializeField]
    private FoodSpawner foodSpawner;

    private void Awake()
    {
        snakeSegments = new List<Transform>();
        snakeSegments.Add(gameObject.transform);

    }



    private void Start()
    {
        InvokeRepeating(nameof(PlayerMovement), bufferMovementTime, bufferMovementTime);
        InvokeRepeating(nameof(ScoreUpdate), scoreUpdateTime, scoreUpdateTime);
    }

    private void ScoreUpdate()
    {
        currentScore += increaseScoreAmt;
        scoreText.text = "Score: " + currentScore;
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal " + playerId);
        verticalInput = Input.GetAxisRaw("Vertical " + playerId);
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
    }

    private void MoveBody()
    {
        if (snakeSegments.Count == 1)
            return;

        Vector3 lastSegmentPostion = lastHeadPosition;
        for (int i = 1; i < snakeSegments.Count; i++)
        {
            Vector3 currentSegmentPostion = snakeSegments[i].position;
            snakeSegments[i].position = lastSegmentPostion;
            lastSegmentPostion = currentSegmentPostion;
        }
    }

    public void Grow()
    {
        Transform segment = Instantiate(snakeSegmentPrefab, lastHeadPosition, snakeSegments[^1].rotation, transform.parent);
        segment.GetComponent<GameOver>().attachedPlayerController = this;
        snakeSegments.Insert(1, segment);
    }

    public void Srink()
    {
        if (snakeSegments.Count == 1)
            return;
        Transform lastSegment = snakeSegments[^1];
        snakeSegments.Remove(lastSegment);
        Destroy(lastSegment.gameObject);
    }
    public void Shield()
    {
        shieldInUse = true;
        Invoke(nameof(DisableShield), shieldPowerupDuration);
    }


    private void DisableShield()
    {
        shieldInUse = false;
    }

    public void ScoreBoost()
    {
        increaseScoreAmt *= 2;
        Invoke(nameof(DisableScoreBoost), ScoreBoostPowerupDuration);
    }

    private void DisableScoreBoost()
    {
        increaseScoreAmt /= 2;
    }

    public void SpeedBoost()
    {
        if (bufferMovementTime == lowestMovementTime)
            return;
        CancelInvoke(nameof(PlayerMovement));
        bufferMovementTime /= 2;
        InvokeRepeating(nameof(PlayerMovement), bufferMovementTime, bufferMovementTime);
        Invoke(nameof(DisableSpeedBoost), SpeedBoostPowerupDuration);
    }

    private void DisableSpeedBoost()
    {
        CancelInvoke(nameof(PlayerMovement));
        bufferMovementTime *= 2;
        InvokeRepeating(nameof(PlayerMovement), bufferMovementTime, bufferMovementTime);
    }
    public void GameOver()
    {
        if (shieldInUse)
            return;

        CancelInvoke();
        foodSpawner.CancelInvoke();
        this.enabled = false;
    }


}
