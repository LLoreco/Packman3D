using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 15f;
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
