using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeScript : MonoBehaviour
{
    public static float meCharge = 1f;


    void FixedUpdate(){
        if(meCharge <= 4f){
            meCharge += 0.1f;
        }
        Debug.Log("meCharge:" + meCharge);
    }

}
