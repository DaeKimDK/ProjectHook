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
	public movement Movement;
	public float old_speed;
	
	void Start() 
	{
		old_speed = Movement.speed;
		Random.seed = spawnseed;
		timer = Time.time + spawntime;
	}

	void LateUpdate() 
	{
		Quaternion quat = new Quaternion (0, 0, 0, 0);
		
		Vector3 buildingspawnPoint = new Vector3 (transform.position.x, transform.position.y, -0.1F);

		float itemchoice = Random.value;

		if (Movement.speed > old_speed) 
		{
			spawntime = spawntime - (Movement.speed * 0.05f);
			old_speed = Movement.speed;
			if (spawntime < 0.1f)
			{
				spawntime = 0.1f;
			}
		}

		if (Movement.speed < old_speed) {
						spawntime = spawntime + (Movement.speed * 0.05f);
						old_speed = Movement.speed;
				}

		if (timer < Time.time)
		{
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
			timer = Time.time + spawntime;
		}
	}

}