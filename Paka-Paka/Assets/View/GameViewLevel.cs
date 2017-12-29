using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// View .cs

// Contains all views related to the app.
public class GameViewLevel : ElementLevel
{
	// Reference Main Camera
	public AudioSource audioSourceCamera;
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
	// Reference Main Camera
	public Text newRecord;
	// List elements
	public GameObject [] elemets;
	//AudioSource
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		lost_win.gameObject.SetActive (false);
		newRecord.gameObject.SetActive (false);
		newRecord.GetComponent<Text>().text = app.model.record;
		time.text = app.model.timeLevel + "";
		audioSource = GetComponent<AudioSource> ();
	}
}