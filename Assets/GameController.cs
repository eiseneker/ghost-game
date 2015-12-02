using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static float playTime;
	private float baddySpawnTime;
	private float foodSpawnTime;

	// Use this for initialization
	void Start () {
		playTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		playTime += Time.deltaTime;
		foodSpawnTime += Time.deltaTime;
		baddySpawnTime += Time.deltaTime;
		
		if(baddySpawnTime > 1){
			SpawnBaddies();
			baddySpawnTime = 0;
		}

		if(foodSpawnTime > 4){
			SpawnFoods ();
			foodSpawnTime = 0;
		}
		
		if(Tank.tank.health <= 0){
			ShowGameOver();
		}
	}
	
	public static int Difficulty(){
		int difficulty = Mathf.FloorToInt(Mathf.Clamp (playTime/10, 0, 10));
		return(difficulty);
	}
	
	void SpawnBaddies(){
		Vector3 newPosition = Tank.tank.transform.position;
		
		newPosition.x += 20;
		newPosition.y = Random.Range (-2f, 2f);
		Instantiate (Resources.Load ("Baddie"), newPosition, Quaternion.identity);
	}
	
	void SpawnFoods(){
		float lastY = Random.Range(-2f, 2f);
		for(int i = 0; i < 5; i++){
			Vector3 newPosition = Tank.tank.transform.position;
			
			newPosition.x += 20 + i;
			lastY = Mathf.Clamp (Random.Range (lastY - .2f, lastY + .2f), -2f, 2f);
			newPosition.y = lastY;
			Instantiate (Resources.Load ("Food"), newPosition, Quaternion.identity);
		}
	}
	
	void ShowGameOver(){
		GameObject.Find ("Canvas").transform.Find ("GameOver").gameObject.SetActive(true);
	}
	
	public void Replay(){
		Application.LoadLevel ("Game");
	}
}
