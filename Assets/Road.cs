using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {

	LoadMarker loadMarker;

	// Use this for initialization
	void Start () {
		loadMarker = transform.Find ("LoadMarker").GetComponent<LoadMarker>();
		loadMarker.road = this;
		
		AddBackgroundElements();
	}
	
	public void SpawnNewRoad(){
		Vector3 position = transform.position;
		position.x += 35.6f;
		GameObject newRoad = Instantiate (Resources.Load ("Road"), position, Quaternion.identity) as GameObject;
		newRoad.transform.parent = GameObject.Find ("Roads").transform;
	}
	
	public void DestroyMe(){
		Destroy(gameObject);
	}
	
	public void AddBackgroundElements(){
		for(int i = 0; i < 40; i++){
			float scaleFactor = Random.Range (0.6f, 0.6f);
			Vector3 scale = new Vector3(scaleFactor, scaleFactor, 1);
			float xFactor = Random.Range (-20f, 20f);
			int zFactor = Random.Range (1, 30);
			
			GameObject tree = Instantiate (Resources.Load ("Tree"), transform.position, Quaternion.identity) as GameObject;
			tree.transform.localScale = scale;
			tree.transform.parent = transform;
			tree.transform.position = new Vector3(transform.position.x + xFactor, -1.5f, zFactor);
		}
	}
	
}
