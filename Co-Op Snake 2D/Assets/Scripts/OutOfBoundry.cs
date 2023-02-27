using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundry : MonoBehaviour
{
    [SerializeField]
    private float xBoundry;
    [SerializeField]
    private float yBoundry;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = transform.position;
        if (Mathf.Abs(playerPosition.x) == xBoundry)
        {
            playerPosition.x = (playerPosition.x - (1 * Mathf.Sign(playerPosition.x))) * -1;
        }
        else if (Mathf.Abs(playerPosition.y) == yBoundry)
        {
            playerPosition.y = (playerPosition.y - (1 * Mathf.Sign(playerPosition.y))) * -1;
        }
        transform.position = playerPosition;
    }
}
