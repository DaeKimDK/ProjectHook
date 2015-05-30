using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public Vector3 velocity;
	Vector3 moveDir = Vector3.zero;
	public float speed = 1f;
	public int boost_len = 0;
	bool boosting = false;
	public static bool tempspeed = false;
	float bounceSpeedY = 1f;
	float waitTime = 0f;
	bool bounce = false;
	float bounce_vel = 5f;
	public Vector3 invisPlayerPos;
	public Vector3 tempPos;
	Sprite newsprite;

	GameObject Player;                          // Reference to the player GameObject.


	void Update(){
		if (bounce == true)
		{
			boosting = true;
			bouncing();
		}
		else
		{
			moveDir.x = Input.GetAxis("Horizontal");
			transform.position += moveDir * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.Space) && bounce == false) 
		{
			if(BoostManage.IsZero==false)
			{
				if(speed>2.0)
				{
					velocity.y = speed;
				}
				else
				{
					Boost ();
				}
			}
			else
			{
				boosting = false;
				velocity.y = speed;
			}
		} 
		else if (bounce == false)
		{
			boosting = false;
			if (tempspeed == true)
			{
				tempspeed = false;
				velocity.y = speed;
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		invisPlayerPos = GameObject.FindGameObjectWithTag("PlayerInvis").transform.position;
		transform.position += velocity * speed * bounceSpeedY * Time.deltaTime;
		if (transform.position.y < invisPlayerPos.y) 
		{
			tempPos = transform.position;
			tempPos.y = invisPlayerPos.y;
			bounceSpeedY = 1f;
			transform.position = tempPos;
		}
	}
	void bouncing(){
		waitTime += Time.deltaTime;
		if (waitTime <= .5)
		{
			bounceSpeedY = 2f;
			bounceType1();
		}
		else
		{
			bounceSpeedY = .4f;
			bounce_vel = 5f;
			waitTime = 0;
			bounce = false;
		}
	}
	void bounceType1(){
		if (bounce_vel > 1.1f){	
			bounce_vel -= 1f;
		}
		else
		{
			bounce_vel = 1.1f;
		}
		transform.position += moveDir * bounce_vel * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Pick Up") && boosting)
		{
			other.gameObject.SetActive(false);
			Draw_score.score += 1;
			if (speed < 1.7f)
			{
				speed += 0.1f;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Border1"){
			Debug.Log("border1");
			bounce = true;
			moveDir.x = 1;
		}
		else if (col.gameObject.tag == "Border2") {
			Debug.Log("border2");
			bounce = true;
			moveDir.x = -1;
		}
	}

	void Boost()
	{
		boosting = true;
		//boostmeter.decreaseMeter (5);
		if (tempspeed == false)
		{
			velocity.y += 0.5f;
			tempspeed = true;
		}
	}
}
