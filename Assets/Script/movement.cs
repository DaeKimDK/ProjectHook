using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public Vector3 velocity;
	Vector3 moveDir = Vector3.zero;
	float speed = 1f;
	
	void Update(){
		moveDir.x = Input.GetAxis("Horizontal");
		transform.position += moveDir * speed * Time.deltaTime;
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position += velocity * Time.deltaTime;
	}
}
