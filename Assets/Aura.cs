using UnityEngine;
using System.Collections;

public class Aura : MonoBehaviour {

	public GameObject owner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay2D(Collider2D collider){
		print (owner.name + " collided with " + collider.gameObject.name);
		if(owner != null){
			if(collider.GetComponent<Food>()){
				print (owner.name + " move me elsewhere... ");
				Vector3 newPosition = owner.transform.position;
				newPosition.y = Random.Range (-2f, 2f);
				owner.transform.position = newPosition;
			}
		}
	}
}
