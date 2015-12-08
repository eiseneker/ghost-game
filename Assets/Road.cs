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
		SpawnFoods();
		SpawnObstacles();
		SpawnTreasure();
		SpawnBaddies();
	}
	
	void Update(){
		timeSinceBaddiesSpawned += Time.deltaTime;
		if(!baddiesSetInPlace && timeSinceBaddiesSpawned > 1){
			if(baddies.Count > 0){
				foreach(GameObject baddie in baddies){
					if(baddie != null) baddie.GetComponent<Baddie>().aura.canBeMoved = false;
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
		if(Tank.foodMeter * .1f > Random.value){
			Vector3 newPosition = transform.position;
			float xFactor = XRange();
			newPosition.x += SPAWN_CENTER_OFFSET + xFactor;
			newPosition.y = YRange ();
			Instantiate (Resources.Load ("TreasureGhost"), newPosition, Quaternion.identity);
		}
	}
	
	void SpawnBaddies(){
		int baddieCount = 0;
		int difficulty = GameController.Difficulty ();
		
		if(difficulty < 10){
			baddieCount = difficulty + 2;
		}else if (difficulty < 20){
			baddieCount = 18;
		}else{
			baddieCount = 30;
		}
		for(int i = 0; i < baddieCount; i++){
			print ("spawn baddie");
			Vector3 newPosition = transform.position;
			float xFactor = XRange();
			newPosition.x += SPAWN_CENTER_OFFSET + xFactor;
			newPosition.y = YRange ();
			GameObject baddie = Instantiate (Resources.Load ("Baddie"), newPosition, Quaternion.identity) as GameObject;
			baddies.Add (baddie);
		}
		timeSinceBaddiesSpawned = 0;
	}
	
	void SpawnObstacles(){
		if(Random.value > .7f){
			int baddieCount = 0;
			int difficulty = GameController.Difficulty ();
			Vector3 newPosition = transform.position;
			float xFactor = XRange();
			newPosition.x += SPAWN_CENTER_OFFSET + xFactor;
			newPosition.y = 0;
			GameObject baddie = Instantiate (Resources.Load ("ObstacleBear"), newPosition, Quaternion.identity) as GameObject;
		}		
	}
	
	void SpawnFoods(){
		float initialCenter = SPAWN_CENTER_OFFSET + XRange ();
		float lastY = YRange ();
		for(int i = 0; i < 4; i++){
			Vector3 newPosition = transform.position;
			
			newPosition.x += initialCenter + i;
			lastY = Mathf.Clamp (Random.Range (lastY - .2f, lastY + .2f), -2f, 2f);
			newPosition.y = lastY;

//			newPosition.x += SPAWN_CENTER_OFFSET + XRange ();
//			newPosition.y = YRange ();
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
