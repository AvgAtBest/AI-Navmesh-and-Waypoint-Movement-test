using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SteeringBehaviours
{
    public class AIAgent : MonoBehaviour
    {
        public NavMeshAgent agent;
        //Public declaration for NavMeshAgent, used to navigate the terrain. Functions will not work if UnityEngine.AI is not mentioned in the system requirements

        private Vector3 point;
        //Co ordinates in scene for point

        void Update()
        {
            //agent.SetDestination(target.position);
            //Sets AI agent destitation on navmesh to point position value
            if (point.magnitude > 0)
            {
                agent.SetDestination(point);
            }
        }
        public void SetTarget(Vector3 point)
        {
            this.point = point;
        }
    }
}
