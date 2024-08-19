using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsData : MonoBehaviour
{
    [SerializeField]private Transform[] waypoints;
    public Transform[] Waypoints
    {
        get
        {
            return waypoints;
        } 
    }
}
