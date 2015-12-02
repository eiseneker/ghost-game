using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	private Vector3  currentVelocity = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	void LateUpdate () {
		if(Tank.tank){
			Vector3 destination = new Vector3(Tank.tank.transform.position.x + 3, transform.position.y, transform.position.z);
			transform.position = destination;
		}
	}
	
}
