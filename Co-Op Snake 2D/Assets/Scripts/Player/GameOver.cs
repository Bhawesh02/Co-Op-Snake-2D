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
            Debug.Log("Player: "+attachedPlayerController.playerId+" Bit it self");
        else
        {
            Debug.Log("Player: "+ bittenPlayerController.playerId+" won");
            attachedPlayerController.GameOver();
        }
            

        bittenPlayerController.GameOver();

    }
}
