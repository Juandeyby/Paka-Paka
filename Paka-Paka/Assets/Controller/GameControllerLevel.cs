using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.Advertisements;

// BounceController.cs

// Controls the app workflow.
public class GameControllerLevel : ElementLevel {

	//Referense to Level Actual
	int actualLevel;
	//Refresh elements
	bool deactiveElements;
	bool refreshElements;

	void Start()
	{
		Advertisement.Initialize ("1654248");
		Advertisement.Show ();
		//Level actual
		actualLevel = app.model.LevelActual;
		//Refresh elements
		refreshElements = true;
	}

	public void LoadScene(string level)
	{
		app.view.audioSource.Play ();
		SceneManager.LoadScene(level);
	}

	public void Quit()
	{
		Application.Quit();
	}

	//Destruccion del object seleccionado
	public IEnumerator AudioClip (AudioSource audioSource, AudioClip clip, GameObject image, GameObject effect, GameObject element) {
		if (Vector3.Distance(element.transform.position, app.view.mainCamera.transform.position) < 6.0f) {
			app.view.audioSource.clip = clip;
			app.view.audioSource.Play ();
			effect.GetComponent<ForkParticleEffect>().PlayEffect();
			yield return new WaitForSeconds (audioSource.clip.length);
			Destroy (effect);
			DisableObject (image);
			DestroyObject (element);
		}
	}

	//Desabilita el object
	public void DisableObject (GameObject element) {
		element.SetActive (false);
	}

	//Destruye el object
	public void DestroyObject (GameObject element) {
		Destroy (element);
	}

	//Audio element
	public void AudioObject (GameObject element) {
		element.GetComponent<AudioSource> ().clip = element.GetComponent<TouchView>().clip;
		element.GetComponent<AudioSource> ().Play ();
	}

	private float tiempo_inicio = 0.0f;

	void Update()
	{
		//Time level while not win or lost
		if (refreshElements) {
			if (tiempo_inicio < 1.0f) {
				tiempo_inicio += Time.deltaTime;
			} else {
				tiempo_inicio = 0.0f;
				int newTime;
				int.TryParse (app.view.time.text, out newTime);
				if (newTime <= app.model.timeLevelDanger) {
					app.view.audioSource.clip = app.view.secondClip;
					app.view.audioSource.Play ();
					app.view.time.color = Color.red;
				}
				//Lost test
				if (newTime <= 0) {
					refreshElements = false;
					StartCoroutine (Lost_Win (app.view.lostClip, app.model.lost, false));
				} else {
					//Normal Time Count
					app.view.time.text = newTime - 1 + "";
				}
			}
		}

		//Refresh elements actives
		deactiveElements = false;
		for (int i = 0; i < app.view.elemets.Length && refreshElements; i++) {
			if (app.view.elemets [i].activeSelf)
				deactiveElements = true || deactiveElements;
		}
		if (!deactiveElements && refreshElements) {
			StartCoroutine (Lost_Win (app.view.winClip, app.model.win, true));
			refreshElements = false;
		}	 
	}
	//Reference to AudioClip, string name los_win, win (true) or lost bool (false)
	IEnumerator Lost_Win (AudioClip clip, string lost_win, bool lost_win_bool) {
		//Audio
		app.view.audioSource.clip = clip;
		app.view.lost_win.text = lost_win;
		app.view.lost_win.gameObject.SetActive (true);
		app.view.audioSourceCamera.Stop ();
		app.view.audioSource.Play ();
		//Save player WIN
		if (lost_win_bool) {
			Player player = LoadPlayer ();
			int newTime;
			int.TryParse(app.view.time.text, out newTime);
			// Nuevo Registro = Menor tiempo en busqueda
			if (player.points_level [actualLevel] < newTime ||
				player.points_level [actualLevel] == 0) {
				app.view.newRecord.gameObject.SetActive (true);
				player.points_level [actualLevel] = newTime;
			}
			player.level = actualLevel + 1;
			SavePlayer (player);
		}
		//Loading
		yield return new WaitForSeconds (app.view.audioSource.clip.length);
		if (lost_win_bool) {
			SceneManager.LoadSceneAsync("Level" + 2);
		} else {
			SceneManager.LoadSceneAsync("Level" + 1);
		}
	}

	public Player LoadPlayer()
	{
		if (File.Exists(Application.persistentDataPath + "/player.sav"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);

			Player player = bf.Deserialize(stream) as Player;
			stream.Close();
			return player;
		}
		return null;
	}

	public void SavePlayer(Player player)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create);
		bf.Serialize(stream, player);
		stream.Close();
	}
}