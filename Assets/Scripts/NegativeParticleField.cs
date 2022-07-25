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
        private float otherCharge;
        private float strength;

        protected override float GetCurrentStrength(Collider other)
        {
            // discard enabled stuff 
            // use actual formular for electric force between particles. 
            float distance = Vector3.Distance(other.transform.position, gameObject.transform.position);
            otherCharge = PlayerChargeScript.meCharge; 
            strength = (otherCharge * itCharge)/ (distance * distance);
            strength = Mathf.Abs(strength);
            Debug.Log("Test. force:" + strength); 
            if(strength > 0.6) {
                return 0.6f;
                }else 
            { 
                if(strength< -0.6 ) {return -0.6f;}else{ return strength;}
            }
        }

        protected override Vector3 GetCurrentForce(Collider other)
        {
            if(Mathf.Sign(itCharge) == Mathf.Sign(otherCharge)){
                return -(gameObject.transform.position - other.transform.position).normalized;
            }else{
                return (gameObject.transform.position - other.transform.position).normalized;
            }
        }
    }
}