using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private float rotationSpeed;
    private float verticalInput;
    private float horizontalInput;

    private bool havePowerUp;

    [SerializeField] private TeleportManager teleportManager;

    private GameObject[] childObjects;

    [SerializeField] private GameObject gameManager;
    protected GameManager gm;

    private StringData stringData = new StringData();
    private NumberData numberData = new NumberData();
    public bool HavePowerUp
    {
        get
        {
            return havePowerUp;
        }
        set
        {
            havePowerUp = value;
        }
    }
    private void Start()
    {
        movementSpeed = numberData.Speed;
        rotationSpeed = numberData.RotationSpeed;
        gm = gameManager.GetComponent<GameManager>();
        havePowerUp = false;
    }
    private void Update()
    {
        if (gm.IsGameOver == false)
        {
            ReadInput();
            Move();
        }
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
            if (havePowerUp)
            {
                KillEnemy(collision);
            }
        }
        else
        {
            movementSpeed = 5f;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !havePowerUp)
        {
            Death();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        movementSpeed = numberData.Speed;
    }
    private void Death()
    {
        if (havePowerUp)
        {
            return;
        }
        else
        {
            childObjects = new GameObject[gameObject.transform.childCount];
            for (int i = 0; i < childObjects.Length; i++)
            {
                childObjects[i] = gameObject.transform.GetChild(i).gameObject;
                if (childObjects[i].CompareTag("Camera"))
                {
                    break;
                }
                Material material = childObjects[i].GetComponent<MeshRenderer>().material;
                StartCoroutine(AnimateMaterial(material, stringData.RemapFloat, -1f, 1f, 1f));
            }
            gm.GameOver();
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
    private void KillEnemy(Collision enemy)
    {
        enemy.collider.enabled = false;
        MoveEnemy moveEnemy = enemy.gameObject.GetComponent<MoveEnemy>();
        moveEnemy.HasEaten();
        gm.KillGhost();
    }
    public IEnumerator PowerUpTimer()
    {
        float duration = 20f;
        havePowerUp = true;
        while (duration > 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }
        havePowerUp = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Teleporter"))
        {
            int teleportIndex = other.gameObject.GetComponent<TeleportPoint>().TeleportIndex;
            if (teleportIndex == 0)
            {
                teleportIndex = 1;
            }
            else
            {
                teleportIndex = 0;
            }

            teleportManager.Teleport(gameObject, teleportManager.Teleporters[teleportIndex]);
        }
    }
}
