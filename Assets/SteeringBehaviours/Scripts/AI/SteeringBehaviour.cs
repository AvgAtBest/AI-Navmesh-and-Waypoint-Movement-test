using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    //"SteeringBehavior" will only work if attached to AIAgent
    [RequireComponent(typeof(AIAgent))]
    public abstract class SteeringBehaviour : MonoBehaviour
    {
        public float weighting; //How much influence the behaviour has over other behaviours 
        public AIAgent owner; //Reference to AIAgent owner of behaviour
        private void Awake() // Awake runs before start, regardless whether or not the gameobject is enabled
        {
            owner = GetComponent<AIAgent>();
        }
        public virtual Vector3 GetForce()
        {
            return Vector3.zero;
        }
    }
}
