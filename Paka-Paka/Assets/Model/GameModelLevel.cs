﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// BounceModel.cs

// Contains all data related to the app.
public class GameModelLevel : ElementLevel {
	// Data
	public int timeLevel = 120;
	public int timeLevelDanger = 60;
	public string win = "Ganaste";
	public string lost = "Perdiste";
	public int Levels = 3;
	public int LevelActual = 0;
	public string record = "Nuevo Registro";
}