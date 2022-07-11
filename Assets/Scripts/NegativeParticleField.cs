using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DualPantoFramework
{
    /// <summary>
    /// Applies a linear force on any object with a "MeHandle" or "ItHandle" tag within its area.
    /// </summary>
    public class NegativeParticleField : ForceField
    {
        public Vector3 direction;
        [Range(-1, 1)]
        public float strength;
        public bool enabled = true;
        protected override float GetCurrentStrength(Collider other)
        {
            if(enabled) {return strength;} else {return 0;}
        }

        protected override Vector3 GetCurrentForce(Collider other)
        {

            return -(gameObject.transform.position - other.transform.position).normalized;
        }
    }
}