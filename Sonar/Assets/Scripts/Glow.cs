﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{

    float glowDelay;
    float delay;

    bool hasCollided = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            delay = glowDelay;
        }

        Behaviour halo = (Behaviour)GetComponent("Halo");
        if (delay <= 0)
        {
            halo.enabled = false;
            hasCollided = false;
        }

        if (hasCollided == true)
        {
            delay -= Time.deltaTime;
        }
 

    }

    // void OnTriggerEnter(Collider other)
    // {
    //    
    //     Behaviour halo = (Behaviour)GetComponent("Halo");
    //    // halo.enabled = false;
    //
    //     if (other.gameObject.name == "Sphere")
    //     {
    //         
    //
    //         halo.enabled = true;
    //     }
    //     else
    //     {
    //         Debug.LogError("Sphere not colliding");
    //
    //     }
    // }

    void OnTriggerStay(Collider other)
    {
        Debug.LogError("still here inside you");
        Behaviour halo = (Behaviour)GetComponent("Halo");
        // halo.enabled = false;

        if (other.gameObject.name == "EchoRing1")
        {
            halo.enabled = true;
            glowDelay = 4;
            hasCollided = true;
        }
        if (other.gameObject.name == "EchoRing2")
        {
            halo.enabled = true;
            glowDelay = 4;
            hasCollided = true;

        }
        if (other.gameObject.name == "EchoRing3")
        {
            halo.enabled = true;
            glowDelay = 4;
            hasCollided = true;

        }
        if (other.gameObject.name == "EchoRing4")
        {
            halo.enabled = true;
            glowDelay = 4;
            hasCollided = true;

        }

    }
}
//
//  void OnTriggerExit(Collider other)
//  {
//        Debug.LogError("exited");
//        Behaviour halo = (Behaviour)GetComponent("Halo");
//        if (other.gameObject.name == "Sphere")
//         {
//             halo.enabled = false;
//         }
//        else
//        {
//            halo.enabled = true;
// 
//        }
//    }
// 
//}
