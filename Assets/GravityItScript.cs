using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;

public class GravityItScript : MonoBehaviour
{
    public float mass= 1f;
    public Transform tf;
    private float g = 6.67E-11f;
    LowerHandle lowerHandle;
    GravityScript otherObject;

    void Start()
    {
        lowerHandle = GameObject.Find("Panto").GetComponent<LowerHandle>();
        otherObject = FindObjectOfType<GravityScript>();
        
    }

    void FixedUpdate()
    {
        Attract(otherObject);
    }

    void Attract (GravityScript objToAttract)
    {
        Vector3 direction = objToAttract.tf.position - gameObject.transform.position;
        float m2 = objToAttract.mass;
        float distance = direction.magnitude;
        float force = (g*m2*mass)/(distance * distance);

        lowerHandle.ApplyForce(direction.normalized, force);

    }

}
