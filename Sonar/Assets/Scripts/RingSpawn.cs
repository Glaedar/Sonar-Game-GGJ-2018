using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawn : MonoBehaviour {

    public float ringDelay;
    public float lightDelay;

    float lDelay;
    float rDelay;

    bool timeStart;
    bool isRingActive;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Behaviour halo = (Behaviour)GetComponent("Halo");

        if (Input.GetKeyDown(KeyCode.E))
        {
            //lDelay = lightDelay;
            //rDelay = ringDelay;
            //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            timeStart = true;

        }
        if (isRingActive == true)
        {
            if (rDelay >= ringDelay)
            {

                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
                //halo.enabled = true;
                this.gameObject.GetComponent<Collider>().enabled = true;

            }
        }

        if(timeStart == true)
        {
            isRingActive = true;

            rDelay += Time.deltaTime;

            if (rDelay >= ringDelay + 4)
            {
                isRingActive = false;
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                halo.enabled = false;
                this.gameObject.GetComponent<Collider>().enabled = false;
                timeStart = false;
                rDelay = 0;

            }
        }
        

        //Debug.LogError("Delay: " + rDelay);
    }
}
