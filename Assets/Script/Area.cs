using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : Singleton<Area> {
    public Color drawColor;
    public Transform leftUpper, leftLower, rightUpper, rightLower;
    public void OnDrawGizmos()
    {
        if (leftUpper && rightUpper && leftLower && rightLower)
        {
            Debug.DrawLine(leftLower.position, leftUpper.position, drawColor);
            Debug.DrawLine(leftLower.position, rightLower.position, drawColor);
            Debug.DrawLine(rightUpper.position, leftUpper.position, drawColor);
            Debug.DrawLine(rightUpper.position, rightLower.position, drawColor);
        }
    }
    public Vector3 Clamp(Vector3 input)
    {
        Vector3 clamped = new Vector3(
            Mathf.Clamp(input.x, leftUpper.position.x, rightUpper.position.x),
            Mathf.Clamp(input.y, leftLower.position.y, rightUpper.position.y));
        return clamped;
    }
   
}
