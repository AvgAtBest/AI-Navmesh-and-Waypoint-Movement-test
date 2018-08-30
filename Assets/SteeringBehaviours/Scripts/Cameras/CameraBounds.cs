using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    public class CameraBounds : MonoBehaviour
    {
        public Vector3 size = new Vector3(50f, 0f, 20f);
        public Vector3 GetAdjustedPosition(Vector3 incomingPos)
        {
            Vector3 pos = transform.position;
            Vector3 halfSize = size * 0.5f;
            //Is point of camera incoming greater than and + or - the half height of the bounds
            if(incomingPos.z > pos.z + halfSize.z)
            {
                incomingPos.z = pos.z + halfSize.z;
            }
        }
        // Use this for initialization
        void Start()
        {

        }

        void Update()
        {

        }
    }
}
