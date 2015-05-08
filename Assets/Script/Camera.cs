using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public Transform player;
	public float offset;

	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("PlayerInvis");
		player = player_go.transform;
		offset = transform.position.y - player.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.y = player.position.y + offset;
		transform.position = pos;
	
	}
}
