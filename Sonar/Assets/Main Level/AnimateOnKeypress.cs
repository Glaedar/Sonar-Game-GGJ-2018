using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnKeypress : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	public KeyCode MyKey;
	public string MyTrigger;

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(MyKey))
		{
			GetComponent<Animator>().SetTrigger(MyTrigger);
		}
	}
}
