using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour {

    float sonarDelay = 3.0f;
    float delay;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<Collider>().enabled = true;
            //this.GetComponent<Light>().enabled = true;
            //transform.light.
            delay = sonarDelay;
        }
        if (delay <= 0)
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
        delay -= Time.deltaTime;
        
    }

}
