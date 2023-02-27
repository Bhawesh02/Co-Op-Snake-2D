using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundry : MonoBehaviour
{
    private float xBoundry;
    private float yBoundry;

    private void Awake()
    {
        xBoundry = GameManager.Instance.xBoundry;
        yBoundry = GameManager.Instance.yBoundry;
    }
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
