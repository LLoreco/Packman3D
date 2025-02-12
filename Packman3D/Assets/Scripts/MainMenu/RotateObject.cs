using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float rotationSpeed = 30.0f;
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.left, (rotationSpeed - 15) * Time.deltaTime);
    }
}
