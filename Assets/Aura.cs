using UnityEngine;
using System.Collections;

public class Aura : MonoBehaviour {

	public GameObject owner;
	private int attempts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay2D(Collider2D collider){
		if(owner != null){
			if(collider.GetComponent<Food>() || collider.GetComponent<TreasureGhost>()){
				MoveMe ();
			}else if(collider.GetComponent<Baddie>()){
				if(collider.GetComponent<Baddie>().gameObject != owner){
					MoveMe ();	
				}
			}
		}
	}
	
	void MoveMe(){
		if(attempts < 5){
			Vector3 newPosition = owner.transform.position;
			newPosition.y = Random.Range (-2f, 2f);
			owner.transform.position = newPosition;
			attempts++;
		}else{
			Destroy (owner);
		}
	}
}
