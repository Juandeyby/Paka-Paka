using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Application.cs

// Base class for all elements in this application.
public class ElementMain : MonoBehaviour
{
	// Gives access to the application and all instances.
	public GameApplicationMain app { get { return GameObject.FindObjectOfType<GameApplicationMain>(); }}
}

public class GameApplicationMain : MonoBehaviour
{
	// Reference to the root instances of the MVC.
	public GameModelMain model;
	public GameViewMain view;
	public GameControllerMain controller;

	// Init things here
	void Start() { }
}