using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// View .cs

// Contains all views related to the app.
public class GameViewMain : ElementMain
{
	//Reference to AudioSource
	public AudioSource audioSource;
	// Reference to nivels
	public GameObject [] nivels;
	// Reference to canvas
	public GameObject [] canvas;
	// Reference to clip
	public AudioClip buttonClip;
	bool touch;

	// Use this for initialization
	void Start () {
		touch = false;

		for (int i = 0; i < nivels.Length; i++) {
			app.view.nivels [i].SetActive (false);
		}
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown (0) && !touch) {
			app.controller.ActiveCanvas (1);
			touch = true;
		}
	}
}