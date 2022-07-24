using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;

public class GravityScript : MonoBehaviour
{
    public float mass = 1f;
    public Transform tf;
    private float g = 6.67f;
    UpperHandle upperHandle;
    GravityItScript otherObject;
    
    void Start()
    {
        upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        otherObject = FindObjectOfType<GravityItScript>();
    }

    void FixedUpdate()
    {
        Attract (otherObject);
    }

    void Attract (GravityItScript objToAttract)
    {
        Vector3 direction = objToAttract.tf.position - gameObject.transform.position;
        float m2 = objToAttract.mass;
        float distance =Vector3.Distance(objToAttract.tf.position, gameObject.transform.position);
        float force = (g*m2*mass)/(distance * distance);

        if(force > 0.5) {force = 0.5f;}
        // Debug.Log("Test. force:" + force + "distance between:" + objToAttract.tf.position + "and" + gameObject.transform.position);
        Debug.Log("Test: force:" + force + "from" + g+ m2 + mass);
        upperHandle.ApplyForce(direction.normalized, force);
    }

}
