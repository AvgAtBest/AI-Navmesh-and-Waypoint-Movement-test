using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Allows for AI Functions in Unity
namespace Intro
{
    public class Enemy : MonoBehaviour
    {
        //Enumeration of AI "combat" states. Will switch between states with function is requested. So far Patrol is set to 0 (default, will patrol between), while seek is set to 1 (activated on trigger)
        public enum State
        {
            Patrol = 0,
            Seek = 1
        }


        public State currentState = State.Patrol;
        //References the current state the AI Agent starts off as. In this case, it is in Patrol by Default.
        public Transform target;
        //References the target's coordinates (Scale, Rotation and Position) the AI agent is set to engage
        public float seekRadius = 5f;
        //References the seekRadius of the AI Agent when in proximity to the target. It is set to 5f.
        public NavMeshAgent agent;
        //References the NavMeshAgent used to navigate the terrain. This access modifier will not work if UnityEngine.AI is not mentioned in the systems 
        public Transform waypointParent;
        //References the Parent waypoint coordinates (Scale, Rotation and Position) that the AI Agent will navigate to.
        public float moveSpeed;
        //References the moveSpeed of the AI Agent
        public float stoppingDistance = 1f;

        private Transform[] waypoints;
        //References the children waypoints coordinates (Scale, Rotation and Position) that the AI Agent will travel to after the Parent Waypoint
        private int currentIndex = 1;
        //References the numerical order. Current index is set to 1

        void Patrol()
        {
            Transform point = waypoints[currentIndex];

            float distance = Vector3.Distance(transform.position, point.position);
            //Distance on xyz axis between waypoints
            //AI Agent will move to the next waypoint if the distance between the current waypoint and next waypoint is close enough
            if (distance < 1.5f)
            {
                currentIndex++;
                //Adds 1 to currentIndex (which is 1) = 2
                if (currentIndex >= waypoints.Length)
                {
                    currentIndex = 1;
                }
            }
            agent.SetDestination(point.position);

            float distToTarget = Vector3.Distance(transform.position, target.position);
            if (distToTarget < seekRadius)
            {
                currentState = State.Seek;
            }
        }

        void Seek()
        {
            agent.SetDestination(target.position);

            float distToTarget = Vector3.Distance(transform.position, target.position);
            if (distToTarget > seekRadius)
            {
                currentState = State.Seek;
            }
        }
        // Use this for initialization
        void Start()
        {
            waypoints = waypointParent.GetComponentsInChildren<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            //Switch current state
            switch (currentState)
            {
                case State.Patrol:
                    //Patrol state
                    Patrol();
                    break;
                case State.Seek:
                    //Seek State
                    Seek();
                    break;
                default:
                    break;
            }
            {

            }
            //If we are in patrol
            //Call Patrol()
            //If we are in Seek
            //Call Seek()
        }
    }
}