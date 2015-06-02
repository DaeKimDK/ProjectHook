﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {
	public movement move;
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (move.speed <= .3f)
		{
			gameover();
		}
	}

	void gameover(){
		text.text = "GAME OVER";
	}
}
