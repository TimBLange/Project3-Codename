
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Waypoints instance;
    [SerializeField] public GameObject waypointMarker;
    private int WaypointID;
    private int currentIndex = 0;

    [SerializeField] GameObject[] objectIDList;
    void Start()
    {
        WaypointID = GameObject.FindGameObjectsWithTag("Waypoint").Length;
        Debug.Log($"{WaypointID} waypoints in scene");
        instance = this;
        objectIDList = GameObject.FindGameObjectsWithTag("Waypoint");
        WaypointList();
        foreach (var item in objectIDList)
        {
            item.SetActive(false);
        }
        objectIDList[0].SetActive(true);
        MoveToWaypoint();
    }
    
    

    public void WaypointUpdate()
    {
        objectIDList[currentIndex].SetActive(false);
        currentIndex++;
        if (currentIndex < objectIDList.Length)
        {
            objectIDList[currentIndex].SetActive(true);
            MoveToWaypoint();
        }
        else
        {
            waypointMarker.SetActive(false);
        }
    }

    private void WaypointList()
    {
        objectIDList = objectIDList.OrderByDescending(i => i.GetComponent<ID>().id).ToArray();
        Array.Reverse(objectIDList);
    }

    private void MoveToWaypoint()
    {
        waypointMarker.transform.position = objectIDList[currentIndex].transform.position;
    }
}
