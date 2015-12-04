using UnityEngine;
using System.Collections;

public class ObstacleBear : MonoBehaviour {

	public Aura aura;

	void Start(){
		transform.parent = GameObject.Find ("Baddies").transform;
		Aura tempAura = transform.Find ("Aura").GetComponent<Aura>();
		tempAura.owner = gameObject;
		aura = tempAura;
		gameObject.name = "Bear " + Random.Range (0,99999);
	}
	
	public void OnTriggerEnter2D(Collider2D collider){
		Tank tank = collider.GetComponent<Tank>();
		if(tank){
			tank.TakeHit ();
		}
	}
	
	void Update(){
		transform.Translate (Vector3.left * Time.deltaTime);
	}
}
