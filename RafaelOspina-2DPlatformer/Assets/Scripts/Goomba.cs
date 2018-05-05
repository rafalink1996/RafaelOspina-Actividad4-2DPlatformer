using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour {

	int speed = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (speed * Time.deltaTime, 0, 0);
		
	}
	void OnTriggerEnter2D (Collider2D goomba) {
		if (goomba.gameObject.tag == "Left") {
			speed = 1;
		}
		if (goomba.gameObject.tag == "Right") {
			speed = -1;
		}
	}
}
