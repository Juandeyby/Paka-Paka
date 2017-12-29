using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// View .cs

// Contains all views related to the app.
public class GameViewLevel : ElementLevel
{
	// Reference Main Camera
	public GameObject mainCamera;
	// Reference second sound
	public AudioClip secondClip;
	// Reference win and lost sounds
	public AudioClip winClip;
	public AudioClip lostClip;
	// Time Level
	public Text time;
	// Lost and Win
	public Text lost_win;
	// List elements
	public GameObject [] elemets;
	//AudioSource
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		time.text = app.model.timeLevel + "";
		audioSource = GetComponent<AudioSource> ();
	}
}