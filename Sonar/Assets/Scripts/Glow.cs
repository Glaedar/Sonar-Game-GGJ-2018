using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{

    float glowDelay;
    float delay;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            delay = glowDelay;
        }

        Behaviour halo = (Behaviour)GetComponent("Halo");
        if (delay <= 0)
        {
            halo.enabled = false;
        }

        delay -= Time.deltaTime;
        Debug.LogError("Delay: " + delay);

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

        if (other.gameObject.name == "Sphere")
        {
            halo.enabled = true;
            glowDelay = 3;
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
