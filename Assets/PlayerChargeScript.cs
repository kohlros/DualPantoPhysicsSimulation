using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;

public class PlayerChargeScript : MonoBehaviour
{
    public static float meCharge = 1f;
    PantoHandle upperHandle;
    float zeroAngle; 
    float currentAngle;
    float angleDiff;

    void Start()
    {
        upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        zeroAngle = upperHandle.GetRotation();
    }

    void FixedUpdate(){
        // if(meCharge <= 4f){
        //     meCharge += 0.1f;
        // }
        // Debug.Log("meCharge:" + meCharge);
        currentAngle = upperHandle.GetRotation();
        angleDiff = zeroAngle - currentAngle; 
        meCharge = Mathf.Abs((angleDiff/360)*10);
    }

}
