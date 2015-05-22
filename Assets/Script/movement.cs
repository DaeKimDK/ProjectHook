using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public Vector3 velocity;
	Vector3 moveDir = Vector3.zero;
	float speed = 1f;
	public int boost_len = 0;
	private bool boosting = false;
	public static bool tempspeed = false;


	GameObject Player;                          // Reference to the player GameObject. 

	
	void Update(){
		moveDir.x = Input.GetAxis("Horizontal");
		transform.position += moveDir * speed * Time.deltaTime;

		if (Input.GetKey (KeyCode.Space)) 
		{
			if(BoostManage.IsZero==false)
			{
				Boost ();
				if(speed>2.0)
				{
					velocity.y = 2.0f;
				}
				else
				{
					velocity.y = speed;
				}
			}

			else
			{
				boosting = false;
				if(speed>2.0)
				{
					velocity.y = 2.0f;
					velocity.y -= 0.5f;
				}
				else
				{
					velocity.y = speed;
					velocity.y -= 0.5f;
				}
			}
		} 

		else
		{
			boosting = false;
			if (tempspeed == true)
			{
				tempspeed = false;
				if(speed>2.0)
				{
					velocity.y = 2.0f;
					velocity.y -= 0.5f;
				}
				else
				{
					velocity.y = speed;
					velocity.y -= 0.5f;
				}
			}
		}
	}


	// Update is called once per frame
	void FixedUpdate () {
		transform.position += velocity * Time.deltaTime;
		//Boost_len ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Pick Up") && boosting)
		{
			other.gameObject.SetActive(false);
			Draw_score.score += 1;
			speed += 0.1f;
		}
	}

	void Boost()
	{
		boosting = true;

		if (tempspeed == false) 
		{
			tempspeed = true;
			velocity.y += 0.5f;
		}
	}
}


