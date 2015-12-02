using UnityEngine;
using System.Collections;

public class LoadMarker : MonoBehaviour {

	public Road road;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.GetComponent<Tank>()){
			road.SpawnNewRoad();
		}
	}
	
	public void DestroyMe(){
		road.DestroyMe();
	}
}
