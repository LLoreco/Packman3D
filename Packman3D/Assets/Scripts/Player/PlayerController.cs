using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed;
    private float rotationSpeed;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rb;

    private StringData stringData = new StringData();
    private NumberData numberData = new NumberData();
    private void Start()
    {
        movementSpeed = numberData.Speed;
        rotationSpeed = numberData.RotationSpeed;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        ReadInput();
        Move();
    }
    private void ReadInput()
    {
        verticalInput = Input.GetAxis(stringData.VerticalInput) * -1;
        horizontalInput = Input.GetAxis(stringData.HorizontalInput);
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);
    }
    private void OnCollisionEnter(Collision collision)
    {
        movementSpeed = 5f;
    }
    private void OnCollisionExit(Collision collision)
    {
        movementSpeed = numberData.Speed;
    }
}
