using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {

	private float SPAWN_CENTER_OFFSET = 33;
	private float ROAD_LENGTH = 9.5f;
	private ArrayList baddies = new ArrayList();
	private float timeSinceBaddiesSpawned;
	private bool baddiesSetInPlace;

	LoadMarker loadMarker;

	// Use this for initialization
	void Start () {
		loadMarker = transform.Find ("LoadMarker").GetComponent<LoadMarker>();
		loadMarker.road = this;
		SpawnObstacles();
		SpawnFoods();
		SpawnTreasure();
		SpawnBaddies();
	}
	
	void Update(){
		timeSinceBaddiesSpawned += Time.deltaTime;
		if(!baddiesSetInPlace && timeSinceBaddiesSpawned > 1){
			if(baddies.Count > 0){
				foreach(GameObject baddie in baddies){
					
					if(baddie != null) {
						baddie.GetComponent<Baddie>().aura.canBeMoved = false;
					}
				}
				baddiesSetInPlace = true;
			}
		}
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
	
	void SpawnTreasure(){
		if(true || Tank.foodMeter * .1f > Random.value){
			Vector3 newPosition = transform.position;
			float xFactor = XRange();
			newPosition.x += SPAWN_CENTER_OFFSET + xFactor;
			newPosition.y = YRange ();
			Instantiate (Resources.Load ("TreasureGhost"), newPosition, Quaternion.identity);
		}
	}
	
	void SpawnBaddies(){
		for(float i = -4f; i <= 4f; i += .5f){
			if(Random.value < .2f){
				Vector3 newPosition = transform.position;
				newPosition.x += SPAWN_CENTER_OFFSET + i;
				newPosition.y = YRange ();
				GameObject baddie = Instantiate (Resources.Load ("Hummingbird"), newPosition, Quaternion.identity) as GameObject;
				baddies.Add (baddie);
			}
		}
	
//		int baddieCount = 0;
//		int difficulty = GameController.Difficulty ();
//		
//		if(difficulty < 10){
//			baddieCount = difficulty + 2;
//		}else if (difficulty < 20){
//			baddieCount = 18;
//		}else{
//			baddieCount = 30;
//		}
//		
//		for(int i = 0; i < baddieCount; i++){
//			Vector3 newPosition = transform.position;
//			float xFactor = XRange();
//			newPosition.x += SPAWN_CENTER_OFFSET + xFactor;
//			newPosition.y = YRange ();
//			GameObject baddie = Instantiate (Resources.Load ("Baddie"), newPosition, Quaternion.identity) as GameObject;
//			baddies.Add (baddie);
//		}
//		timeSinceBaddiesSpawned = 0;
	}
	
	void SpawnObstacles(){
//		for(float i = -4f; i <= 4f; i += 2f){
		SpawnObstaclesInSection(-4, 1, 2);
		SpawnObstaclesInSection(-2, -1, -2);
		SpawnObstaclesInSection(0, -1, 1);
		SpawnObstaclesInSection(4, -1, -2);
		SpawnObstaclesInSection(2, 1, 2);
//		SpawnObstaclesInSection(2, -1, -2);
		
//		if(Random.value > .7f){
//			int baddieCount = 0;
//			int difficulty = GameController.Difficulty ();
//			Vector3 newPosition = transform.position;
//			float xFactor = XRange();
//			newPosition.x += SPAWN_CENTER_OFFSET + xFactor;
//			newPosition.y = 0;
//			GameObject baddie = Instantiate (Resources.Load ("ObstacleBear"), newPosition, Quaternion.identity) as GameObject;
//		}		
	}
	
	void SpawnObstaclesInSection(float x, float minY, float maxY){
		if(Random.value < .5f){
			float initialCenter = SPAWN_CENTER_OFFSET + XRange ();
			float lastY = Random.Range (minY, maxY);
			for(int v = 0; v < 4; v++){
				Vector3 newPosition = transform.position;
				newPosition.x += SPAWN_CENTER_OFFSET + (v * .75f) + x;
				lastY = Mathf.Clamp (Random.Range (lastY - .5f, lastY + .5f), minY, maxY);
				newPosition.y = lastY;
				
				GameObject baddie = Instantiate (Resources.Load ("Acorn"), newPosition, Quaternion.identity) as GameObject;
				baddies.Add (baddie);
			}
		}
	}
	
	void SpawnFoods(){
//		float initialCenter = SPAWN_CENTER_OFFSET + XRange ();
//		float lastY = YRange ();
//		for(int i = 0; i < 4; i++){
//			Vector3 newPosition = transform.position;
//			
//			newPosition.x += initialCenter + i;
//			lastY = Mathf.Clamp (Random.Range (lastY - .2f, lastY + .2f), -2f, 2f);
//			newPosition.y = lastY;
//
////			newPosition.x += SPAWN_CENTER_OFFSET + XRange ();
////			newPosition.y = YRange ();
//			Instantiate (Resources.Load ("Food"), newPosition, Quaternion.identity);
//		}

		for(float i = -3.75f; i <= 3.75f; i += 2f){
			if(Random.value < 1f){
				Vector3 newPosition = transform.position;
				newPosition.x += SPAWN_CENTER_OFFSET + i;
				newPosition.y = YRange ();
				Instantiate (Resources.Load ("Food"), newPosition, Quaternion.identity);
			}
		}
		
	}
	
	float XRange(){
		return(Random.Range (-4f, 4f));
	}
	
	float YRange(){
		return(Random.Range (-2.5f, 2.5f));
	}
}
