using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    private NavMeshAgent agent;
    private Vector3 randomDirection;
    private float changeDirectionTimer;
    private float minChange = 3f;
    private float maxChange = 8f;
    private bool playerWasSeen;
    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerWasSeen = false;
        ChangeDirection();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckDistanceToPlayer();

        if (playerWasSeen)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            changeDirectionTimer -= Time.deltaTime;
            if(changeDirectionTimer <= 0)
            {
                ChangeDirection();
            }
            agent.SetDestination(transform.position + randomDirection);
        }
    }
    private void ChangeDirection()
    {
        if (!playerWasSeen)
        {
            randomDirection = Random.insideUnitSphere * 5f;
            changeDirectionTimer = Random.Range(minChange, maxChange);
        }
    }
    private void CheckDistanceToPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= 50f)
        {
            playerWasSeen = true;
        }
    }
}
