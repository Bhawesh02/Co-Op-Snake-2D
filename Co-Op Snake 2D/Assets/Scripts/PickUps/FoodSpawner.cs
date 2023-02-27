using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> foods;

    [SerializeField]
    private float foodSpawnTimeIntervalMin;
    [SerializeField]
    private float foodSpawnTimeIntervalMax;

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
    }

    private void SpawnFood()
    {
        int randomFoodIndex = Random.Range(0, foods.Count);
        int randomXCoordinate = Random.Range(xBoundry * -1 + 1, xBoundry);
        int randomYCoordinate = Random.Range(yBoundry * -1 + 1, yBoundry);
        Vector3 randomPosition = new Vector3(randomXCoordinate, randomYCoordinate, 0f);
        GameObject randomFood = foods[randomFoodIndex];
        if (randomFood.GetComponent<FoodController>().type != FoodType.Srink || (playerController.snakeSegments.Count != 1))
            Instantiate(randomFood, randomPosition, randomFood.transform.rotation);
        float foodSpawnTimeInterval = Random.Range(foodSpawnTimeIntervalMin, foodSpawnTimeIntervalMax);
        Invoke(nameof(SpawnFood), foodSpawnTimeInterval);
    }


}
