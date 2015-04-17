using UnityEngine;
using System.Collections;

public class BGLoop : MonoBehaviour {
	int numOfBG = 2;
	void OnTriggerEnter2D (Collider2D col){
		Debug.Log ("Trigered: " + col.name);
		float heightOfBGObject = ((BoxCollider2D)col).size.y;
		Vector3 pos = col.transform.position;
		pos.y += heightOfBGObject * numOfBG;
		col.transform.position = pos;
	}
}
