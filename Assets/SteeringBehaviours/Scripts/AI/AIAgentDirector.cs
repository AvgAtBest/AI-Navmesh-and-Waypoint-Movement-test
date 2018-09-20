using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    public class AIAgentDirector : MonoBehaviour
    {
        public AIAgent[] agents;
        public Transform placeHolder;
        private void OnDrawGizmosSelected()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(camRay.origin, camRay.origin + camRay.direction * 1000f);
        }
        void FixedUpdate()
        {
            foreach (var agent in agents)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(camRay, out hit, 1000f))
                    {
                        //attempts to get the seek component on the agent
                        Seek seek = agent.GetComponent<Seek>();
                        Flee flee = agent.GetComponent<Flee>();
                        placeHolder.position = hit.point;
                        //update the transform's position

                        if (seek)
                            seek.target = placeHolder;

                        if (flee)
                            flee.target = placeHolder;


                    }
                }

            }
        }
    }
}
