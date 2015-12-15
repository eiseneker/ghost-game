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
		if(transform.position.y < -1){
			transform.Translate (Vector3.up * Time.deltaTime * 2f * GameController.actionTimeScale);
		}
		transform.Translate (Vector3.left * Time.deltaTime * 2f * GameController.actionTimeScale);
	}
}
