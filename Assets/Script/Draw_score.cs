using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Draw_score : MonoBehaviour {

	public static int score = 0;
	public movement mul;
	Text text;

	// Use this for initialization
	void Awake () {

		text = GetComponent<Text> ();

		score = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (score < 0) 
		{
			score = 0;
		}
		text.text = "Score: " + score +"\nMultiplier: " + mul.scoreMul;
	}
}
