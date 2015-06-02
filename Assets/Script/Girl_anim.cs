using UnityEngine;
using System.Collections;

public class Girl_anim : MonoBehaviour {
	public Animation anim;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			Debug.Log("Hit");
		}
	}
}
