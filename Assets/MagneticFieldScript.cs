using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DualPantoFramework
{
public class MagneticFieldScript : ForceField
{
    public float fieldStrength = 1f;
    public Vector3 direction; 
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    private Vector3 movingDirection = new Vector3(0f,0f,0f);

    protected override float GetCurrentStrength(Collider other)
    {
        if(previousPosition == null){
            previousPosition = other.transform.position;
        }
        currentPosition = other.transform.position;

        float speed = Vector3.Distance(previousPosition , currentPosition)/Time.deltaTime;
        float meCharge = PlayerChargeScript.meCharge;
        float strength = meCharge * speed * fieldStrength;
        movingDirection = (previousPosition - currentPosition).normalized;
        previousPosition = currentPosition;
        Debug.Log(strength);
        if(strength > 0.5) {return 0.5f;} else { return strength;}
    }    
    
    protected override Vector3 GetCurrentForce(Collider other)
    {
        // Debug.Log(Vector3.Cross(movingDirection, direction));
        Vector3 forceDirection = Vector3.Cross(movingDirection, direction);
        return -(gameObject.transform.position - other.transform.position).normalized;
        // return new Vector3(0f,0f,-1f);
    }
}
}