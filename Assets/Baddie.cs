using UnityEngine;
using System.Collections;

public class Baddie : MonoBehaviour {
	public int colorIndex;
	
	private SpriteRenderer bodySprite;
	public Aura aura;

	// Use this for initialization
	void Start () {
		bodySprite = transform.Find ("Body").GetComponent<SpriteRenderer>();
		transform.parent = GameObject.Find ("Baddies").transform;
		Aura tempAura = transform.Find ("Aura").GetComponent<Aura>();
		tempAura.owner = gameObject;
		aura = tempAura;
		gameObject.name = "Baddy " + Random.Range (0,99999);
	}
	
	public void DestroyMe(){
		Destroy(gameObject);
	}
	
	public void OnTriggerEnter2D(Collider2D collider){
		Tank tank = collider.GetComponent<Tank>();
		if(tank){
			tank.TakeHit ();
			DestroyMe ();
		}
	}
	
}
