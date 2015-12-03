using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {

	private float SPAWN_CENTER_OFFSET = 33;
	private float ROAD_LENGTH = 9.5f;

	LoadMarker loadMarker;

	// Use this for initialization
	void Start () {
		loadMarker = transform.Find ("LoadMarker").GetComponent<LoadMarker>();
		loadMarker.road = this;
		SpawnBaddies();
		SpawnFoods();
	}
	
	public void SpawnNewRoad(){
		Vector3 position = transform.position;
		position.x += ROAD_LENGTH;
		GameObject newRoad = Instantiate (Resources.Load ("Road"), position, Quaternion.identity) as GameObject;
		newRoad.transform.parent = GameObject.Find ("Roads").transform;
	}
	
	public void DestroyMe(){
		Destroy(gameObject);
	}
	
	void SpawnBaddies(){
		int baddieCount = 0;
		int difficulty = GameController.Difficulty ();
		
		if(difficulty < 10){
			baddieCount = difficulty;
		}else if (difficulty < 20){
			baddieCount = 15;
		}else{
			baddieCount = 20;
		}
		for(int i = 0; i < baddieCount; i++){
			Vector3 newPosition = transform.position;
			float xFactor = XRange();
			newPosition.x += SPAWN_CENTER_OFFSET + xFactor;
			newPosition.y = YRange ();
			print("spawning a baddie at " + newPosition);
			Instantiate (Resources.Load ("Baddie"), newPosition, Quaternion.identity);
		}
	}
	
	void SpawnFoods(){
		float initialCenter = SPAWN_CENTER_OFFSET + XRange ();
		float lastY = YRange ();
		for(int i = 0; i < 5; i++){
			Vector3 newPosition = transform.position;
			
			newPosition.x += initialCenter + i;
			lastY = Mathf.Clamp (Random.Range (lastY - .2f, lastY + .2f), -2f, 2f);
			newPosition.y = lastY;
			Instantiate (Resources.Load ("Food"), newPosition, Quaternion.identity);
		}
	}
	
	float XRange(){
		return(Random.Range (-4f, 4f));
	}
	
	float YRange(){
		return(Random.Range (-2.5f, 2.5f));
	}
}
