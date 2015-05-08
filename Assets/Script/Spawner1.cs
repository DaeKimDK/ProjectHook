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
		float x1 = transform.position.x - 0.70F;
		float x2 = transform.position.x + 0.70F;
		float y1 = transform.position.y - 0.50F;
		float y2 = transform.position.y + 0.50F;

		Vector2 spawnPoint = new Vector2 (Random.Range (x1, x2), Random.Range (y1, y2));

		if (Random.value <= spawnchance) 
		{
			Instantiate (item, spawnPoint, transform.rotation);
		}

	}
}
