using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundry : MonoBehaviour
{
    private int xBoundry;
    private int yBoundry;
    private void Start()
    {
        xBoundry = GameManager.Instance.XBoundry;
        yBoundry = GameManager.Instance.YBoundry;
    }
    void Update()
    {

        Vector3 segmentPosition = transform.position;
        if (Mathf.Abs(segmentPosition.x) >= xBoundry)
        {
            segmentPosition.x = (segmentPosition.x - (1 * Mathf.Sign(segmentPosition.x))) * -1;
        }
        else if (Mathf.Abs(segmentPosition.y) >= yBoundry)
        {
            segmentPosition.y = (segmentPosition.y - (1 * Mathf.Sign(segmentPosition.y))) * -1;
        }
        transform.position = segmentPosition;
    }
}
