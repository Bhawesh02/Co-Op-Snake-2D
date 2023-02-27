
using System;
using UnityEngine;
public enum FoodType
{
    Grow,
    Srink,
    Shield,
    Score
}

public class FoodController : MonoBehaviour
{
    [SerializeField]
    private FoodType type;
    PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController == null)
            return;
        switch(type)
        {
            case FoodType.Grow:
                playerController.Grow();
                break;
            case FoodType.Srink:
                playerController.Srink();
                break;
            case FoodType.Shield:
                playerController.Shield();
                break;
            case FoodType.Score:
                playerController.ScoreBoost();
                break;
        }
        Destroy(gameObject);
    }

    
}