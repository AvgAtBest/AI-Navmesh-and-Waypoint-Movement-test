using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SteeringBehaviours
{
    public class AIAgentDirector : MonoBehaviour
    {
        public AIAgent agent;

        void FixedUpdate()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(camRay, out hit, 1000f))
            {
                agent.SetTarget(hit.point);
            }
        }
    }
}
