using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DualPantoFramework
{
    /// <summary>
    /// Applies a electric force on any object with a "MeHandle" or "ItHandle" tag within its area.
    /// </summary>
    public class NegativeParticleField : ForceField
    {
     
        // charge of the it-Particle 
        public float itCharge = 1f;
        private float strength;

        protected override float GetCurrentStrength(Collider other)
        {
            // discard enabled stuff 
            // use actual formular for electric force between particles. 
            float distance = Vector3.Distance(other.transform.position, gameObject.transform.position);
            float meCharge = PlayerChargeScript.meCharge; 
            strength = (meCharge * itCharge)/ (distance * distance); 
            if(strength > 0.4) {return 0.4f;} else { return strength;}

        }

        protected override Vector3 GetCurrentForce(Collider other)
        {

            return -(gameObject.transform.position - other.transform.position).normalized;
        }
    }
}