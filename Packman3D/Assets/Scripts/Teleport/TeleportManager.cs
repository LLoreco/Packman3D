using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    [SerializeField] private Teleporter[] teleporters;
    public Teleporter[] Teleporters 
    {
        get
        {
            return teleporters;
        } 
    }
    public void Teleport(GameObject player, Teleporter destination)
    {
        player.transform.position = destination.transform.position;
    }
    private void Initialize()
    {
        foreach(Teleporter teleporter in teleporters)
        {
            teleporter.Initialize();
        }
    }
}
