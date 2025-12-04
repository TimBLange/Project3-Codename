
using System;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            ID.instance.IDNumber();
        }
    }
}
