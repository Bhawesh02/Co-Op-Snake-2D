
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private static FoodSpawner instance;
    public static FoodSpawner Instance { get { return instance; } }
    public List<Transform> foodsTransform;

    [SerializeField]
    private List<GameObject> foods;
    [SerializeField]
    private List<GameObject> powerUps;

    [SerializeField]
    private float foodSpawnTimeIntervalMin;
    [SerializeField]
    private float foodSpawnTimeIntervalMax;
    [SerializeField]
    private float powerUpSpawnTimeIntervalMin;
    [SerializeField]
    private float powerUpSpawnTimeIntervalMax;

    private int xBoundry;
    private int yBoundry;
    [SerializeField]
    private PlayerController playerController;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        xBoundry = GameManager.Instance.XBoundry;
        yBoundry = GameManager.Instance.YBoundry;
        float foodSpawnTimeInterval = Random.Range(foodSpawnTimeIntervalMin, foodSpawnTimeIntervalMax);
        Invoke(nameof(SpawnFood), foodSpawnTimeInterval);
        float powerUpSpawnTimeInterval = Random.Range(powerUpSpawnTimeIntervalMin, powerUpSpawnTimeIntervalMax);
        Invoke(nameof(SpawnPowerUp), powerUpSpawnTimeInterval);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = GenerateRandomPosition();
        while(foodsTransform.Exists(f => f.position == randomPosition))
        {
            randomPosition = GenerateRandomPosition();
        }
        return randomPosition;
    }

    private Vector3 GenerateRandomPosition()
    {
        int randomXCoordinate = Random.Range(xBoundry * -1 + 1, xBoundry);
        int randomYCoordinate = Random.Range(yBoundry * -1 + 1, yBoundry);
        return new(randomXCoordinate, randomYCoordinate, 0f);
    }

    private void SpawnPowerUp()
    {
        int randomPowerUpIndex = Random.Range(0, powerUps.Count);
        
        Vector3 randomPosition = GetRandomPosition();
        GameObject randomPowerup = powerUps[randomPowerUpIndex];
        Instantiate(randomPowerup, randomPosition, randomPowerup.transform.rotation);
        float powerUpSpawnTimeInterval = Random.Range(powerUpSpawnTimeIntervalMin, powerUpSpawnTimeIntervalMax);
        Invoke(nameof(SpawnPowerUp), powerUpSpawnTimeInterval);
    }

    private void SpawnFood()
    {
        int randomFoodIndex = Random.Range(0, foods.Count);
        Vector3 randomPosition = GetRandomPosition();
        GameObject randomFood = foods[randomFoodIndex];
        if (randomFood.GetComponent<FoodController>().type != FoodType.Srink || (playerController.snakeSegments.Count != 1))
        {
            Instantiate(randomFood, randomPosition, randomFood.transform.rotation);

        }
        float foodSpawnTimeInterval = Random.Range(foodSpawnTimeIntervalMin, foodSpawnTimeIntervalMax);
        Invoke(nameof(SpawnFood), foodSpawnTimeInterval);
    }

}
