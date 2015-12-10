using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public int maxHealth = 3;
	private float hitDelay;
	private float lifeTime;
	public static float foodMeter;
	private Vector3 originalScale;
	private float timeSinceLastEat;
	private IAbility ability;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		tank = this;
		points = 0;
		originalScale = transform.localScale;
		foodMeter = 0;
		GameObject abilityObject = Instantiate (Resources.Load ("Stopwatch"), transform.position, Quaternion.identity) as GameObject;
		abilityObject.transform.parent = GameObject.Find ("HUD").transform.Find ("PowerMeter").transform;
		GameObject.Find ("HUD").transform.Find ("PowerMeter").transform.Find ("Image").GetComponent<Image>().sprite = abilityObject.transform.Find ("Image").GetComponent<Image>().sprite;
		
		ability = abilityObject.GetComponent(typeof(IAbility)) as IAbility;
		
		ability.SetPlayer(this);
	}
	
	public float AbilityCooldownRatio(){
		return(ability.CooldownRatio());
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastEat += Time.deltaTime;
		hitDelay += Time.deltaTime;
		pointsDelay += Time.deltaTime * GameController.actionTimeScale;
		
		myRigidBody.AddForce(new Vector2(10, 0));
		
		
		
		if(pointsDelay > .02f){
			points += 1;
			pointsDelay = 0;
		}
		
//		float newGravityScale = foodMeter/4;
		
		myRigidBody.gravityScale = 2f;
		
		if(Input.GetMouseButton(0)){
			myRigidBody.AddForce (new Vector2(0, 50));
		}
		
		if(Input.GetMouseButton(1)){
			ability.Fire();
		}
		
		if(timeSinceLastEat > 2){
			UpdateFoodMeter (-Time.deltaTime/50);
		}
		
		
		Vector3 newPosition = transform.position;
		
//		if(transform.position.y < -3 && myRigidBody.velocity.y < 0){
//			newPosition.y = 3;
//		}else if(transform.position.y > 3 && myRigidBody.velocity.y > 0){
//			newPosition.y = -3;
//		}
		
		if(transform.position.y < -2.8f){
			myRigidBody.AddForce (new Vector2(0, 50));
		}else if(transform.position.y > 2.8f){
			myRigidBody.AddForce (new Vector2(0, -50));
		}
		
		transform.position = newPosition;
		
		myRigidBody.velocity = Vector2.ClampMagnitude(myRigidBody.velocity, 4 * GameController.actionTimeScale);
		
//		float foodScale = Mathf.Round(foodMeter/5 * 100f) / 100f;
		
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
		UpdateFoodMeter (.01f);
		timeSinceLastEat = 0;
	}
	
	private void UpdateFoodMeter(float value){
		foodMeter = Mathf.Clamp (foodMeter + value, 0, 1);
	}
	
	public void IncreaseLife(){
		if(health == maxHealth){
			if(maxHealth < 9){
				maxHealth++;
				health = maxHealth;
			}
		}else{
			health = maxHealth;
		}
	}
}
