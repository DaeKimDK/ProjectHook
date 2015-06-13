using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Button startGame;
	public Button exitGame;
	// Use this for initialization
	void Start () {
	
	}

	public void StartGame()
	{
		Application.LoadLevel (1);
	}
	// Update is called once per frame
	public void EndGame () 
	{
		Application.Quit ();
	}
}
