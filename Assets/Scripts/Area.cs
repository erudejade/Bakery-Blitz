using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : Singleton<Area> {
    public Color drawColor;
    public Transform topLeft, bottomLeft, topRight, bottomRight;
    public void OnDrawGizmos()
    {
        if (topLeft && topRight && bottomLeft && bottomRight)
        {
            Debug.DrawLine(bottomLeft.position, topLeft.position, drawColor);
            Debug.DrawLine(bottomLeft.position, bottomRight.position, drawColor);
            Debug.DrawLine(topRight.position, topLeft.position, drawColor);
            Debug.DrawLine(topRight.position, bottomRight.position, drawColor);
        }
    }
    public Vector3 Clamp(Vector3 input)
    {
        Vector3 clamped = new Vector3(
            Mathf.Clamp(input.x, topLeft.position.x, topRight.position.x),
            Mathf.Clamp(input.y, bottomLeft.position.y, topRight.position.y));
        return clamped;
    }
   
}
