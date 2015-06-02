using UnityEngine;
using System.Collections;

public class BuldingSpawner : MonoBehaviour {
	private float timer;
	public GameObject item;
	public GameObject item2;
	public GameObject item3;
	public float spawntime;
	public int spawnseed;
	public float itemchoice;
	
	void Start() 
	{
		Random.seed = spawnseed;
		InvokeRepeating ("addItem", spawntime, spawntime);
	}
	
	void addItem () {
		Quaternion quat = new Quaternion (0, 0, 0, 0);

		Vector3 buildingspawnPoint = new Vector3 (transform.position.x, transform.position.y, -0.1F); 
		
		Vector2 spawnPoint = new Vector2 (transform.position.x, transform.position.y);

		float itemchoice = Random.value;

		if (itemchoice <= .5) 
		{
			Instantiate (item, buildingspawnPoint, quat);
		}
		else if (itemchoice <= .8)
		{
			Instantiate (item2, buildingspawnPoint, quat);
		}
		else
		{
			Instantiate (item3, buildingspawnPoint, quat);
		}
		
	}
}
