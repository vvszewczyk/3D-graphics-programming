using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform lookAtTarget;
    public Vector3 offsetPosition = new Vector3(0, 3, -6);
    public bool lookAt = true;
    public float smoothSpeed = 0.5F;
    public Vector3 lookAtOffset;

    void FixedUpdate()
    {
        if (lookAtTarget == null)
        {
            Debug.LogWarning("Missing target ref!", this);
            return;
        }
        Vector3 desiredPosition = lookAtTarget.TransformPoint(offsetPosition);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        if (lookAt)
        {
            transform.LookAt(lookAtTarget.position + lookAtOffset);
        }
        else
        {
            transform.rotation = lookAtTarget.rotation;
        }
    }
}
