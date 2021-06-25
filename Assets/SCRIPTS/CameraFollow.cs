using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        
        //Vector3 targetPosition = target.position + offset;
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -6));
        
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        //transform.position = smoothedPosition;
        
        
        // Define a target position above and behind the target transform
        //Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
        
        
    }
}
