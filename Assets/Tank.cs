﻿using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	Rigidbody2D myRigidBody;
	public static Tank tank;
	private float fireDelay;
	public static int points;
	private bool openBuffer = true;
	private float pointsDelay;
	private bool bufferRed;
	private bool bufferYellow;
	private bool bufferBlue;
	private float bufferDelay;
	public int health = 3;
	private float hitDelay;
	private float lifeTime;
	public static float foodMeter;
	private Vector3 originalScale;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		tank = this;
		points = 0;
		originalScale = transform.localScale;
		foodMeter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		hitDelay += Time.deltaTime;
		pointsDelay += Time.deltaTime;
		
		myRigidBody.AddForce(new Vector2(10, 0));
		
		myRigidBody.velocity = Vector2.ClampMagnitude(myRigidBody.velocity, 3);
		
		
		if(pointsDelay > .2f){
			points += 1;
			pointsDelay = 0;
		}
		
//		float newGravityScale = foodMeter/4;
		
		myRigidBody.gravityScale = 1f;
		
		if(Input.GetMouseButton(0)){
			myRigidBody.AddForce (new Vector2(0, 20));
		}
		
		UpdateFoodMeter (-Time.deltaTime/50);
		
		float foodScale = Mathf.Round(foodMeter/5 * 100f) / 100f;
		
//		transform.localScale = new Vector3(originalScale.x + foodScale, originalScale.y + foodScale, originalScale.z);
	}
	
	public void TakeHit(){
		if(hitDelay > 2){
			health -= 1;
			hitDelay = 0;
		}
	}
	
	public void EatFood(){
		points += 10;
		UpdateFoodMeter (.2f);
	}
	
	private void UpdateFoodMeter(float value){
		foodMeter = Mathf.Clamp (foodMeter + value, .25f, 1);
	}
}