using UnityEngine;
using System.Collections;

public class carMovement : MonoBehaviour {
	Vector3 carMoveDir = Vector3.zero;
	float randSpeed;

	void Start(){
		int rand = Random.Range(1, 3);
		randSpeed = Random.Range (.4f, 1.4f);
		//Debug.Log (randSpeed);
		if (rand == 1)
			carMoveDir.x = -(randSpeed);
		else
			carMoveDir.x = randSpeed;
	}
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= -0.6)
			carMoveDir.x = randSpeed;
		else if (transform.position.x >= 0.6)
			carMoveDir.x = -randSpeed;
		transform.position += carMoveDir * Time.deltaTime;
	}
}
