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

    private GameObject[] childObjects;

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Death();
        }
        else
        {
            movementSpeed = 5f;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        movementSpeed = numberData.Speed;
    }
    private void Death()
    {
        childObjects = new GameObject[gameObject.transform.childCount];
        for (int i = 0; i < childObjects.Length; i++)
        {
            childObjects[i] = gameObject.transform.GetChild(i).gameObject;
            Material material = childObjects[i].GetComponent<MeshRenderer>().material;
            StartCoroutine(AnimateMaterial(material, stringData.RemapFloat, -1f, 1f, 1f));
        }
    }
    private IEnumerator AnimateMaterial(Material material, string propertyName, float startValue, float endValue, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            float t = time / duration;
            material.SetFloat(propertyName, Mathf.Lerp(startValue, endValue, t));
            time += Time.deltaTime;
            yield return null;
        }
        material.SetFloat(propertyName, endValue);
    }
}
