using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public PlayerController attachedPlayerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController bittenPlayerController = collision.gameObject.GetComponent<PlayerController>();
        if (bittenPlayerController == null)
            return;

        if (bittenPlayerController == attachedPlayerController)
            GameManager.Instance.playerLostId = bittenPlayerController.playerId;
        else
        {
            GameManager.Instance.playerLostId = attachedPlayerController.playerId;
            attachedPlayerController.GameOver();
        }
            

        bittenPlayerController.GameOver();

    }
}
