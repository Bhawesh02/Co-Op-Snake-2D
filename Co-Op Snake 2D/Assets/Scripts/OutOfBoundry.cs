using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundry : MonoBehaviour
{
    [SerializeField]
    private float xBoundry = 16.0f;
    [SerializeField]
    private float yBoundry = 8.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 segmentPosition = transform.position;
        if (Mathf.Abs(segmentPosition.x) == xBoundry)
        {
            segmentPosition.x = (segmentPosition.x - (1 * Mathf.Sign(segmentPosition.x))) * -1;
        }
        else if (Mathf.Abs(segmentPosition.y) == yBoundry)
        {
            segmentPosition.y = (segmentPosition.y - (1 * Mathf.Sign(segmentPosition.y))) * -1;
        }
        transform.position = segmentPosition;
    }
}
