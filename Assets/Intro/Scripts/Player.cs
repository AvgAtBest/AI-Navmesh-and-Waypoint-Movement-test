using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Intro
{
    public class Player : MonoBehaviour
    {
        public NavMeshAgent agent;
        //Allows agent to move around terrain on the navmesh
        public Transform waypointParent;
        //Coordinates of waypointParent 

        private Transform[] waypoints;
        //Coordinates of waypoints on scene
        private int currentIndex = 1;
        //amount of waympoints needed to move to before proceeding to next waypoint

        void Start()
        {
            waypoints = waypointParent.GetComponentsInChildren<Transform>();
            //On start up, obtains the waypointParent object and obtains children waypoints inside waypoint Parent
        }

        // Update is called once per frame
        void Update()
        {

            Transform point = waypoints[currentIndex];
            float distance = Vector3.Distance(transform.position, point.position);
            //Distance on xyz axis between waypoints
            if (distance < 1.5f)
            {
                currentIndex++;
                if (currentIndex >= waypoints.Length)
                //if waypoint is within a certain distance (set to be within 1.5f)
                {
                    currentIndex = 1;
                    //Moves to next waypoint
                }
            }
            agent.SetDestination(point.position);
        }
    }
}