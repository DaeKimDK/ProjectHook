using UnityEngine;
using System.Collections;

public class BoostMeter : MonoBehaviour {
	public int startingboost = 100;
	public int currentboost;
	public GameObject Player;

	void Awake () 
	{
		currentboost = startingboost;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (currentboost);
	
	}

	public void decreaseMeter(int amount)
	{
		currentboost -= amount;
	}
}
