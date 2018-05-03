﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public AudioClip clip;
	public float volume;
	AudioSource audio;
	bool alreadyPlayed = false;


	// Use this for initialization
	void Start () {
		audio = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		audio.Play ();
		/*if (alreadyPlayed == false) {
			sonido.PlayOneShot (clip, volume);
			alreadyPlayed = true;
		}*/
	}
}
