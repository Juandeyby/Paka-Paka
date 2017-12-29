using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Application.cs

// Base class for all elements in this application.
public class ElementLevel : MonoBehaviour
{
	// Gives access to the application and all instances.
	public GameApplicationLevel app { get { return GameObject.FindObjectOfType<GameApplicationLevel>(); }}
}

public class GameApplicationLevel : MonoBehaviour
{
	// Reference to the root instances of the MVC.
	public GameModelLevel model;
	public GameViewLevel view;
	public GameControllerLevel controller;

	// Init things here
	void Start() { }
}