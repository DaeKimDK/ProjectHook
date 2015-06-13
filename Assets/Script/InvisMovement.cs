using UnityEngine;
using System.Collections;

public class InvisMovement : MonoBehaviour {
	public Vector3 velocity;
	movement playerScript;
	float playerSpeed;
	// Use this for initialization
	void Start(){
		velocity.y = 1;
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
	}
	void FixedUpdate () {
		playerSpeed = playerScript.speed;
		transform.position += playerScript.velocity * playerSpeed *Time.deltaTime;
	}
}
