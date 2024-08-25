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
    [SerializeField] private GameObject enemyBase;

    private Material defaultmaterial;
    [SerializeField] private Material hologramMaterial;
    [SerializeField] private GameObject body;

    private bool hasEaten;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerWasSeen = false;
        FindWaypoints();
        MakeFirtstWaypoint();
        defaultmaterial = body.GetComponent<MeshRenderer>().material;
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
                if (hasEaten)
                {
                    OnBase();
                }
                else
                {
                    GetWaypoint();
                }
            }
            agent.SetDestination(waypoint.position);
        }
    }
    private void CheckDistanceToPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= 50f && hasEaten == false)
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
    public void HasEaten()
    {
        hasEaten = true;
        playerWasSeen = false;
        body.GetComponent<MeshRenderer>().material = hologramMaterial;
        agent.SetDestination(enemyBase.transform.position);
    }
    private void OnBase()
    {
        hasEaten = false;
        body.GetComponent<MeshRenderer>().material = defaultmaterial;
        GetWaypoint();
        BoxCollider collider = gameObject.GetComponent<BoxCollider>();
        collider.enabled = true;
    }
}
