using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    [RequireComponent(typeof(AIAgent))]
    public abstract class SteeringBehaviour : MonoBehaviour
    {
        public float weighting;
        public AIAgent owner;
        private void Awake() {}
        public virtual Vector3 GetForce()
        {
            return Vector3.zero;
        }
    }
}
