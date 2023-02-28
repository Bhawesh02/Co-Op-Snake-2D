using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

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
    private void Start()
    {

        xBoundry = GameManager.Instance.xBoundry;
        yBoundry = GameManager.Instance.yBoundry;
        float foodSpawnTimeInterval = Random.Range(foodSpawnTimeIntervalMin, foodSpawnTimeIntervalMax);
        Invoke(nameof(SpawnFood), foodSpawnTimeInterval);
        float powerUpSpawnTimeInterval = Random.Range(powerUpSpawnTimeIntervalMin, powerUpSpawnTimeIntervalMax);
        Invoke(nameof(SpawnPowerUp), powerUpSpawnTimeInterval);
    }

    private void SpawnPowerUp()
    {
        int randomPowerUpIndex = Random.Range(0, powerUps.Count);
        int randomXCoordinate = Random.Range(xBoundry * -1 + 1, xBoundry);
        int randomYCoordinate = Random.Range(yBoundry * -1 + 1, yBoundry);
        Vector3 randomPosition = new(randomXCoordinate, randomYCoordinate, 0f);
        GameObject randomPowerup = powerUps[randomPowerUpIndex];
        Instantiate(randomPowerup, randomPosition, randomPowerup.transform.rotation);
        float powerUpSpawnTimeInterval = Random.Range(powerUpSpawnTimeIntervalMin, powerUpSpawnTimeIntervalMax);
        Invoke(nameof(SpawnPowerUp), powerUpSpawnTimeInterval);
    }

    private void SpawnFood()
    {
        int randomFoodIndex = Random.Range(0, foods.Count);
        int randomXCoordinate = Random.Range(xBoundry * -1 + 1, xBoundry);
        int randomYCoordinate = Random.Range(yBoundry * -1 + 1, yBoundry);
        Vector3 randomPosition = new(randomXCoordinate, randomYCoordinate, 0f);
        GameObject randomFood = foods[randomFoodIndex];
        if (randomFood.GetComponent<FoodController>().type != FoodType.Srink || (playerController.snakeSegments.Count != 1))
            Instantiate(randomFood, randomPosition, randomFood.transform.rotation);
        float foodSpawnTimeInterval = Random.Range(foodSpawnTimeIntervalMin, foodSpawnTimeIntervalMax);
        Invoke(nameof(SpawnFood), foodSpawnTimeInterval);
    }


}
