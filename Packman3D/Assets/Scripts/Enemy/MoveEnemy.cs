using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private Transform player;

    private NavMeshAgent agent;
    private bool playerWasSeen;

    private Transform waypoint;
    [SerializeField] private GameObject[] waypoints;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerWasSeen = false;
        FindWaypoints();
        MakeFirtstWaypoint();
    }

    private void Update()
    {
        CheckDistanceToPlayer();

        if (playerWasSeen)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (transform.position.x == waypoint.position.x && transform.position.z == waypoint.position.z)
            {
                GetWaypoint();
            }
            agent.SetDestination(waypoint.position);
        }
    }
    private void CheckDistanceToPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= 50f)
        {
            playerWasSeen = true;
        }
    }
    private void GetWaypoint()
    {
        int index = Random.Range(0, waypoints.Length);
        waypoint = waypoints[index].transform;
    }
    private void FindWaypoints()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }
    private void MakeFirtstWaypoint()
    {
        waypoint = GameObject.Find("ExitFromBase").transform;
    }
}
