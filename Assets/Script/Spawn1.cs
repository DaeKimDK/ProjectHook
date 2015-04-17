using UnityEngine;
using System.Collections;

public class Spawn1 : MonoBehaviour {
	public GameObject thing;
	private float timer;
	public float spawntime;

	void Awake() 
	{
		timer = Time.time + spawntime;
	}

	void LateUpdate() 
	{
		if (timer < Time.time)
		{
			Instantiate(thing, transform.position, transform.rotation);
			timer = Time.time + spawntime;
		}
	}

}