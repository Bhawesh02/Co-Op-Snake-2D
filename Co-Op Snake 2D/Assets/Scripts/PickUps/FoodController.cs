
using System;
using UnityEngine;

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
                Grow();
                break;
            case FoodType.Srink:
                Srink();
                break;
        }
    }

    private void Srink()
    {
        return;
    }

    private void Grow()
    {
        playerController.Grow();
        Destroy(gameObject);
    }
}
