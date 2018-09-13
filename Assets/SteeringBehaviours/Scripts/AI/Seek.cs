using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    public class Seek : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance;
        public override Vector3 GetForce()
        {
            //Get direction to target
            Vector3 direction = target.position - owner.transform.position;
            //Normalize direction (remove the magnitude(the distance between two vectors) part of vector
            direction.Normalize();
            //return velocity (direction x speed)
            return direction * owner.maxSpeed;
        }
    }
}
