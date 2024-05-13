using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    public bool rotateClockwise = true;

    public Vector3 direction = Vector3.up;

    void Update()
    {
        float rotationDirection = rotateClockwise ? -1.0f : 1.0f;

        transform.Rotate(direction, rotationDirection * rotationSpeed * Time.deltaTime);


    }
}
