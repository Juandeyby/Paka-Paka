using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

// BounceController.cs

// Controls the app workflow.
public class GameControllerMain : ElementMain {
	//Reference to jugador
	Player player;

	void Start()
	{
		for (int i = 0; i < app.view.canvas.Length; i ++) {
			if (i == 0) app.view.canvas [i].SetActive (true);
			else app.view.canvas [i].SetActive (false);
		}

		app.view.audioSource = app.view.GetComponent<AudioSource> ();
	}

	public void ActiveCanvas(int n) {
		for (int i = 0; i < app.view.canvas.Length; i ++) {
			if (i == n) {
				app.view.canvas [i].SetActive (true);
				app.view.audioSource.clip = app.view.buttonClip;
				app.view.audioSource.Play ();
			}
			else app.view.canvas [i].SetActive (false);
		}
	}

	public void ActiveNivels()
	{
		try {
			player = LoadPlayer ();
			if (player == null) {
				player = new Player();
			}
		} catch (Exception e) {
			player = new Player();
			Debug.Log (e);
		} finally {
			for (int i = 0; i <= player.level; i++) {
				GameObject tempLevel = app.view.nivels [i].transform.Find ("Points").gameObject;
				if (player.points_level[i] == 0)
					tempLevel.GetComponent<Text>().text = "-" + " Tiempo";
				else
					tempLevel.GetComponent<Text>().text = player.points_level[i] + " Tiempo";
				app.view.nivels [i].SetActive (true);
			}
			SavePlayer (player);
		}
	}

	public void LoadScene(string level)
	{
		app.view.audioSource.clip = app.view.buttonClip;
		app.view.audioSource.Play ();
		SceneManager.LoadScene(level);
	}

	public void Quit()
	{
		Application.Quit();
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