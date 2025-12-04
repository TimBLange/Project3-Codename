using System;
using UnityEngine;

public class ID : MonoBehaviour
{
    [Range(0,20)] public int id;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Waypoints.instance.WaypointUpdate();
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, transform.lossyScale);
    }

}
