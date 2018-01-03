using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchView : ElementLevel {
	public GameObject effect;
	public GameObject image;
	public AudioClip clip;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = clip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		// this object was clicked - do something
		StartCoroutine(app.controller.AudioClip(audioSource, clip, image, effect, this.gameObject));
		//app.controller.DisableObject(element);
		//app.controller.DestroyObject(this.gameObject);
	}
}
