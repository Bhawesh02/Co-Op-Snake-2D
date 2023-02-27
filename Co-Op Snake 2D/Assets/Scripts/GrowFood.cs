
using UnityEngine;

public class GrowFood : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController == null)
            return;
        playerController.Grow();
        Destroy(gameObject);
    }
}
