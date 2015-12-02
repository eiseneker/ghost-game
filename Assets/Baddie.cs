using UnityEngine;
using System.Collections;

public class Baddie : MonoBehaviour {
	public int colorIndex;
	
	private SpriteRenderer bodySprite;

	// Use this for initialization
	void Start () {
		bodySprite = transform.Find ("Body").GetComponent<SpriteRenderer>();
		transform.parent = GameObject.Find ("Baddies").transform;
		transform.Find ("Aura").GetComponent<Aura>().owner = gameObject;
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
