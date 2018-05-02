using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player; 
	public float offsetX;
	public float offsetY;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void LateUpdate () {
		//this.transform.position = player.position + offset;
		transform.position = new Vector3 ( player.transform.position.x + offsetX, offsetY, -10);
	}
}
