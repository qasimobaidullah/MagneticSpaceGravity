using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	
     GameObject target;
    public Vector3 offset;
    public float followSmoothTime = 0.2f;
    public float rotationSpeed = 3f;
    public float rotationSmoothTime = 0.1f;

    private Vector3 veclocity = Vector3.zero;
    private float yaw = 0f;
    private float pitch = 0f;
    private float currentYaw = 0f;
    private float currentPitch = 0f;


    void LateUpdate()
    {
	    //HandleRotationInput();

        Vector3 targetPosition = target.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref veclocity, followSmoothTime);

        Quaternion targetRotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothTime);

    }

    private void HandleRotationInput()
    {

        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -20f, 60f);

        currentYaw = Mathf.Lerp(currentYaw, yaw, rotationSmoothTime);
        currentPitch = Mathf.Lerp(currentPitch, pitch, rotationSmoothTime);



    }
}
