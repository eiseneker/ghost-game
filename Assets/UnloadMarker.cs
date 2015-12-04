using UnityEngine;
using System.Collections;

public class UnloadMarker : MonoBehaviour {

	private int eliminated = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = Tank.tank.transform.position;
		position.x -= 10;
		position.y = 0;
		transform.position = position;
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		LoadMarker loadMarker = collider.GetComponent<LoadMarker>();
		if(loadMarker){
			loadMarker.DestroyMe();
		}else{
			Baddie baddie = collider.GetComponent<Baddie>();
			if(baddie){
				baddie.DestroyMe();
			}
			Food food = collider.GetComponent<Food>();
			if(food){
				eliminated++;
				food.DestroyMe();
			}
		}
	}
}
