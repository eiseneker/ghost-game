using UnityEngine;
using System.Collections;

public class Acorn : Baddie {
	public int colorIndex;
	
	private SpriteRenderer bodySprite;
	private bool moves = false;
	private bool movingUp = false;

	// Use this for initialization
	void Start () {
		base.Start ();
		bodySprite = transform.Find ("Body").GetComponent<SpriteRenderer>();
		transform.parent = GameObject.Find ("Baddies").transform;
		gameObject.name = "Baddy " + Random.Range (0,99999);
		if(Random.value < 0){
			moves = true;
			if(Random.value < .5f){
				movingUp = true;
			}
		}
	}
	
	
	void Update(){
		if(moves){
			if(movingUp){
				transform.Translate (Vector3.up * Time.deltaTime * 1 * .5f);
				if(transform.position.y > 2.5f) movingUp = false;
			}else{
				transform.Translate (Vector3.down * Time.deltaTime * 1 * .5f);
				if(transform.position.y < -2.5f) movingUp = true;
			}
		}
	}
	
	public void OnTriggerEnter2D(Collider2D collider){
		Tank tank = collider.GetComponent<Tank>();
		if(tank){
			tank.TakeHit ();
			DestroyMe ();
		}
	}
	
}
