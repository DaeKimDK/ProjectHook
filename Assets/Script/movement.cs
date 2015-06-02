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
	public bool bounce = false;
	float bounce_vel = 5f;
	public Vector3 invisPlayerPos;
	public Vector3 tempPos;
	Sprite newsprite;
	public string bounceObj = "";
	public bool fall = false;
	float boostMul = 1f;
	public AudioClip clip;
	public int scoreMul = 1;
	public float scoreMulTime = 1.0f;
	public AudioClip crash;

	GameObject Player;                          // Reference to the player GameObject.


	void Update(){
		//Debug.Log (transform.position);
		scoreMulTime += Time.deltaTime;
		if (scoreMulTime >= 1)
			scoreMul = 1;
		if (bounce == true)
		{
			boosting = true;
			bouncing();
		}
		else
		{
			moveDir.x = Input.GetAxis("Horizontal");
			transform.position += moveDir * speed * Time.deltaTime * boostMul;
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
				boostMul = 1f;
				boosting = false;
				velocity.y = speed;
			}
		} 
		else if (bounce == false)
		{
			boostMul = 1f;
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
		if (bounce == false)
		{
			transform.position += velocity * speed * bounceSpeedY * Time.deltaTime;
		}
		if (transform.position.y < invisPlayerPos.y) 
		{
			tempPos = transform.position;
			tempPos.y = invisPlayerPos.y;
			bounceSpeedY = 1f;
			transform.position = tempPos;
			fall = false;
		}
	}
	void bouncing(){
		waitTime += Time.deltaTime;
		if (waitTime <= .9 && bounceObj == "border")
		{
			bounceSpeedY = 1.5f;
			bounceType1();
		}
		else if (waitTime <= .5 && bounceObj == "BotCol" && transform.position.y > invisPlayerPos.y)
		{
			bounceSpeedY = -1.2f;
			bounceType2();
		}
		else if (waitTime <= .5 && bounceObj == "TopCol")
		{
			bounceSpeedY = 1.4f;
			bounceType2();
		}
		else if (waitTime <= .5 && bounceObj == "LeftCol")
		{
			bounceSpeedY = 1.4f;
			bounceType2();
		}
		else if (waitTime <= .5 && bounceObj == "RightCol")
		{
			bounceSpeedY = 1.4f;
			bounceType2();
		}
		else
		{
			fall = true;
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
		transform.position += moveDir * bounce_vel * Time.deltaTime; //change in x
		transform.position += velocity * speed * bounceSpeedY * Time.deltaTime; //change in y
	}
	void bounceType2(){
		if (bounce_vel > 0.8f){	
			bounce_vel -= .9f;
		}
		else
		{
			bounce_vel = 0.8f;
		}
		transform.position += moveDir * bounce_vel * Time.deltaTime; //change in x
		transform.position += velocity * speed * bounceSpeedY * Time.deltaTime; //change in y
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Bomb"))
		{
			AudioSource.PlayClipAtPoint(crash, invisPlayerPos);
			gameObject.SetActive(false);
			speed = 0.3f;
		}
		else if (other.gameObject.CompareTag ("Pick Up") && boosting)
		{
			other.gameObject.SetActive(false);
			Draw_score.score += scoreMul;
			if (speed < 1.7f)
			{
				speed += 0.1f;
			}
		}
		else if (velocity.y > 0.8)
		{
			velocity.y -= 0.1f;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		scoreMulTime = 0;
		scoreMul += 1;
		if (col.gameObject.tag != "BotCol" || fall == true || bounce == true)
			AudioSource.PlayClipAtPoint(clip, invisPlayerPos); 
		if (col.gameObject.tag == "Border1"){
			//Debug.Log("border1");
			moveDir.x = 1;
			bounceObj = "border";
			bounce = true;
		}
		else if (col.gameObject.tag == "Border2") {
			//Debug.Log("border2");
			moveDir.x = -1;
			bounceObj = "border";
			bounce = true;
		}
		else if (col.gameObject.tag == "BotCol"){
			bounceObj = "BotCol";
			//Debug.Log("Bot");
			if (bounce == true)
			{
				waitTime = 0f;
				bounce_vel = 2f;
			}
			else if (fall == false && bounce == false)
			{
				AudioSource.PlayClipAtPoint(crash, invisPlayerPos);
				gameObject.SetActive(false);
				speed = .3f;
			}
			else{
				bounce = true;
			}
		}
		else if (col.gameObject.tag == "TopCol"){
			bounceObj = "TopCol";
			//Debug.Log("Top");
			if (bounce == true)
			{
				waitTime = 0f;
				bounce_vel = 4f;
			}
			else{
				bounce = true;
			}
		}
		else if (col.gameObject.tag == "LeftCol") {
			moveDir.x = -1;
			bounceObj = "LeftCol";
			if (bounce == true)
			{
				waitTime = 0f;
				bounce_vel = 4f;
			}
			bounce = true;
		}
		else if (col.gameObject.tag == "RightCol") {
			moveDir.x = 1;
			bounceObj = "RightCol";
			if (bounce == true)
			{
				waitTime = 0f;
				bounce_vel = 4f;
			}
			bounce = true;
		}
	}

	void Boost()
	{
		boosting = true;
		boostMul = 2.0f;
		//boostmeter.decreaseMeter (5);
		if (tempspeed == false)
		{
			velocity.y += 0.5f;
			tempspeed = true;
		}
	}
}
