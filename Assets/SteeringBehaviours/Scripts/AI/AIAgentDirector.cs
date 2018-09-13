using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    public class AIAgentDirector : MonoBehaviour
    {
        public AIAgent agent;
        public Transform placeHolder;
        private void OnDrawGizmosSelected()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(camRay.origin, camRay.origin + camRay.direction * 1000f);
        }
        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //attempts to get the seek component on the agent
                Seek seek = agent.GetComponent<Seek>();
                //if seek is not null
                if (seek)
                {
                    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(camRay, out hit, 1000f))
                    {
                        //update the transform's position
                        placeHolder.position = hit.point;
                        //update seek's target
                        seek.target = placeHolder;
                    }
                }
            }
        }
    }
}
