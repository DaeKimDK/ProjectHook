using UnityEngine;
using System.Collections;

public class Spawner1 : MonoBehaviour {
	private float timer;
	public GameObject item;
	public float spawntime;
	public float spawnchance;
	public int spawnseed;

	void Start() 
	{
		Random.seed = spawnseed;
		InvokeRepeating ("addItem", spawntime, spawntime);
	}

	void addItem () {
		float x1 = transform.position.x - 0.45F;
		float x2 = transform.position.x + 0.45F;

		Vector2 spawnPoint = new Vector2 (Random.Range (x1, x2), transform.position.y);

		if (Random.value < spawnchance) 
		{
			Instantiate (item, spawnPoint, transform.rotation);
		}

	}
}
