using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SteeringBehaviours
{
    public class AIAgent : MonoBehaviour
    {
        public float maxSpeed = 10f;
        public float maxDistance = 5f;
        public bool updatePosition = true;
        public bool updateRotation = true;
        public Vector3 velocity;

        private NavMeshAgent agent;
        private SteeringBehaviour[] behaviours;
        private Vector3 force;

        private void Awake()
        {
            behaviours = GetComponents<SteeringBehaviour>();
            agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            ComputeForces();
            ApplyVelocity();
        }
        private void ComputeForces()
        {
            //Reset velocity
            velocity = Vector3.zero;
            //loop through each behaviour
            for(int i = 0; i < behaviours.Length; i++)
            {
                //Get force from behaviour
                Vector3 force = behaviours[i].GetForce();
                //Add it to velocity
                velocity += force;
            }
        }
        //apply total velocity to ai agent
        private void ApplyVelocity()
        {
            //Get an offset position as new target
            Vector3 point = transform.position + velocity * Time.deltaTime;
            //Apply velocity to transform
            agent.SetDestination(point);
        }
    }
}
