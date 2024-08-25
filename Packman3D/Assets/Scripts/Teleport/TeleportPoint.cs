using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : Teleporter
{
    [SerializeField] private Transform teleportPoint;
    [SerializeField] private int teleportIndex;
    public int TeleportIndex
    {
        get
        {
            return teleportIndex;
        } 
    }
    public override void Teleport(GameObject target)
    {
        target.transform.position = teleportPoint.position;
    }
    public override void Initialize()
    {
        teleportPoint = transform;
    }
}
