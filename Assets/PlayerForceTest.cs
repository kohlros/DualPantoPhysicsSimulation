using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForceTest : MonoBehaviour
{
    public Vector3 force; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate(){
        gameObject.GetComponent<Rigidbody>().AddForce(force);
    }
}
