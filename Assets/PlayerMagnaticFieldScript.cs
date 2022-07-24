using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;

public class PlayerMagnaticFieldScript : MonoBehaviour
{
    UpperHandle upperHandle;
    public Vector3 fieldDirection = new Vector3(0f,1f,0f);
    private Vector3 forceDirection  = new Vector3(0f,0f,-1f);
    private float forceStrength = 0.3f;
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    private Vector3 movementDirection;

    void Start()
    {
        upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        previousPosition = gameObject.transform.position;
    }
    

    void FixedUpdate()
    {
        currentPosition = gameObject.transform.position;
        forceStrength = Vector3.Distance(previousPosition,currentPosition) * 1f;
        // Debug.Log("Test:" + forceStrength);
        if(forceStrength > 0.5) {forceStrength = 0.5f;}
        movementDirection = previousPosition - currentPosition;
        forceDirection = Vector3.Cross(movementDirection, fieldDirection).normalized;
        Debug.Log("Test:" + forceDirection);
        previousPosition = currentPosition;
        upperHandle.ApplyForce(forceDirection, forceStrength);
    }

}
