using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

[System.Serializable]
public class Player
{
	public int level;
	public int [] points_level;

	public Player()
	{
		level = 0;
		points_level = new int[3];
	}

	public Player(int level)
	{
		this.level = level;
	}
}
// BounceModel.cs

// Contains all data related to the app.
public class GameModelMain : ElementMain {
	// Data
}