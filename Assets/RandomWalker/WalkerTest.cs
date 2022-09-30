using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IRandomWalker
{
	//returns the name of the walker, should be your name!
	string GetName();

	//returns the start position for the walker
	Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight);

	//updates the walker position
	//the walker is only allowed to take one step, left/right or up/down
	//If the walker moves diagonally or too long, it will be killed.
	Vector2 Movement();
}

public class WalkerTest : ProcessingLite.GP21
{
	//This file is only for testing your movement/behavior.
	//The Walkers will compete in a different program!

	IRandomWalker walker;
	Vector2 walkerPos;
	float scaleFactor = 0.05f;

	void Start()
	{
		//Some adjustments to make testing easier
		Application.targetFrameRate = 120;
		QualitySettings.vSyncCount = 0;

		//Create a walker from the class Example it has the type of WalkerInterface
		walker = new AndSty();

		//Get the start position for our walker.
		walkerPos = walker.GetStartPosition((int)(Width / scaleFactor), (int)(Height / scaleFactor));
	}

	void Update()
	{
		//Draw the walker
		Point(walkerPos.x * scaleFactor, walkerPos.y * scaleFactor);
		//Get the new movement from the walker.
		walkerPos += walker.Movement();
	}
}