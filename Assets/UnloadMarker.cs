using UnityEngine;
using System.Collections;

public class UnloadMarker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = Tank.tank.transform.position;
		position.x -= 60;
		position.y = 0;
		transform.position = position;
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		LoadMarker loadMarker = collider.GetComponent<LoadMarker>();
		if(loadMarker){
			loadMarker.DestroyMe();
		}else{
			Baddie Baddie = collider.GetComponent<Baddie>();
			if(Baddie){
				Baddie.DestroyMe();
			}
		}
	}
}
