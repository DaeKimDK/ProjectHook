﻿using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public Vector3 velocity;
	Vector3 moveDir = Vector3.zero;
	float speed = 1f;
	private bool boosting = false;
	
	void Update(){
		moveDir.x = Input.GetAxis("Horizontal");
		transform.position += moveDir * speed * Time.deltaTime;

		if (Input.GetKey (KeyCode.Space)) 
		{
			Boost ();
		} 
		else 
		{
			boosting = false;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position += velocity * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Pick Up") && boosting)
		{
			other.gameObject.SetActive(false);
		}
	}

	void Boost()
	{
		boosting = true;
	}
}
